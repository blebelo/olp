'use client';
import { useEffect } from 'react';
import { useStyles } from './Style/style';
import { Button, Typography } from 'antd';
import { useStudentEnrollmentActions, useStudentEnrollmentState } from "@/providers/enrollment-provider";
import { useRouter } from "next/navigation";
import { ICourseDtos } from '@/providers/enrollment-provider/context';

export default function StudentProgressPage() {
    const { styles } = useStyles();
    const { getStudentEnrolledCourses } = useStudentEnrollmentActions();
    const { enrolledCourses } = useStudentEnrollmentState();
    const router = useRouter();


    useEffect(() => {
        const storedId = sessionStorage.getItem("Id");
        if (storedId !== null) {
            const numericId = parseInt(storedId, 10);
            if (!isNaN(numericId)) {
                getStudentEnrolledCourses(numericId);
            }
        }
    }, []);

    const handleCourseClick = (course: ICourseDtos) => {

        const isEnrolled = enrolledCourses?.some((enrolled) => enrolled.id === course.id);
        if (isEnrolled) {
            router.push(`/student/enrolled-course/${course.id}`);

            return;
        }
    }

    const { Title, Paragraph } = Typography;
    return (
        <div className={styles.pageContainer}>
            <div className={styles.decorativeCircle} />
            <div className={styles.decorativeSquare} />
            <Title className={styles.pageTitle}>My Course Progress</Title>

            <div className={styles.courseList}>
                {enrolledCourses?.map((course) => (
                    <div key={course.id} className={styles.courseCard}>
                        <div className={styles.courseDetails}>
                            <Title level={4} className={styles.courseTitle}>{course.title}</Title>
                            <Paragraph className={styles.courseDescription}>{course.description}</Paragraph>
                        </div>
                            <Button type="primary" className={styles.actionButton} onClick={() => handleCourseClick(course)}>
                                {/* {course.completion === 100 ? 'View Course' : 'Continue Learning'} */}
                                Continue
                            </Button>                   
                    </div>
                ))}
            </div>
        </div>
    );
}
