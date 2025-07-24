'use client';
import { useStyles } from './Style/style';
import { Button, Typography } from 'antd';
// import { courses } from '@/utils/sample-courses/courses';
import { useCourseActions, useCourseState } from '@/providers/course-provider';
// import { ICourse } from '@/providers/course-provider/context';
import { useEffect } from 'react';
import Link from 'next/link';

const StudentProgressPage = () => {
    const { styles } = useStyles();
    const { Title, Paragraph } = Typography;

    const { getStudentCourses, getCourse } = useCourseActions();
    const { courses } = useCourseState();


    useEffect(() => {
        const storedId = sessionStorage.getItem("Id");
        if (storedId !== null) {
            const numericId = parseInt(storedId, 10);
            if (!isNaN(numericId)) {
                getStudentCourses(numericId);
            }
        }
    }, []);


    return (
        <div className={styles.pageContainer}>
            <div className={styles.decorativeCircle} />
            <div className={styles.decorativeSquare} />
            <Title className={styles.pageTitle}>My Course Progress</Title>

            <div className={styles.courseList}>
                {courses?.map((course) => (
                    <div key={course.id} className={styles.courseCard}>
                        <div className={styles.courseDetails}>
                            <Title level={4} className={styles.courseTitle}>{course.title}</Title>
                            <Paragraph className={styles.courseDescription}>{course.description}</Paragraph>

                            <div className={styles.progressContainer}>
                                {/* <Progress
                                    percent={course.completion}
                                    status={course.completion === 100 ? 'success' : 'active'}
                                    className={styles.progressBar}
                                /> */}
                                {/* <span className={styles.completionText}>
                                    {course.completion === 100 && <span className={styles.completed}>Completed</span>}
                                </span> */}
                            </div>
                        </div>

                        <div className={styles.actionSection}>
                            
                            <Link href={`/student/enrolled-course/${course.id}`} style={{ display: 'block' }}>
                                <Button type="primary" className={styles.actionButton} onClick={() => {
                                if (course?.id) getCourse(course.id);
                            }}>
                                {/* {course.completion === 100 ? 'View Course' : 'Continue Learning'} */}
                                Continue Learning
                            </Button>
                            </Link>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}
export default StudentProgressPage;