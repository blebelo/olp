'use client';
import { useEffect, useState } from "react";
import { Typography, Button, Row, Col, message } from "antd";
import { useStyles } from "./Styles/style";
import CourseCard, { CourseType } from "@/components/course-card/CourseCard";
import { useCourseActions, useCourseState } from "@/providers/course-provider";
import { ICourse } from "@/providers/course-provider/context";
import CourseModal, { Course } from "@/components/modal/course-modal/CourseModal";
import { axiosInstance } from "@/utils/axiosInstance";

const HomePage = () => {
    const { styles } = useStyles();
    const { getAllCourses } = useCourseActions();
    const {  courses } = useCourseState();

    const [isModalVisible, setIsModalVisible] = useState(false);
    const [selectedCourse, setSelectedCourse] = useState<Course | null>(null);

    useEffect(() => {
        getAllCourses();
    }, []);
    
    const handleCourseClick = (course: CourseType) => {
        setSelectedCourse({
            id: course.id,
            title: course.name,
            topic: course.topic,
            description: course.description,
            instructorName: "N/A", // Optional
            lessons: [], // Optional
        });
        setIsModalVisible(true);
        };
        
    const handleCancelModal = () => {
        setIsModalVisible(false);
        setSelectedCourse(null);
    };
    const handleEnroll = async (courseId: string) => {
        try{
            await axiosInstance.post(`/api/app/student/enroll?courseId=${courseId}`);
            message.success("Enrolled successfully!");
            setIsModalVisible(false);
        }catch (error: unknown) {
            console.error(error);
    }
    };

    const mappedCourses: CourseType[] = (courses || [])
    .filter(course => course.isPublished)
    .map((course: ICourse) => ({
        id: course.id ?? 'unknown-id',
        name: course.title ?? 'Untitled Course',
        topic: course.topic ?? 'General',
        description: course.description ?? 'No description provided.',
        thumbnail: "/images/image2.jpg",
    }));

    return (
        <div className={styles.heroContainer}>
            <div className={styles.decorativeCircleLarge} />
            <div className={styles.decorativeCircleSmall} />
            <div className={styles.decorativeCircleMedium} />
            <div className={styles.decorativeSquareLarge} />
            <div className={styles.decorativeSquareSmall} />
            <div className={styles.contentRow}>
                <div className={styles.textContainer}>
                    <Typography.Title className={styles.mainTitle}>
                        Explore Top Courses
                    </Typography.Title>
                    <Typography.Paragraph className={styles.subtitleText}>
                        Learn from expert instructors. Build your future today.
                    </Typography.Paragraph>
                    <Button className={styles.primaryButton}>Browse All Courses</Button>
                </div>

                <Typography.Title level={3} className={styles.sectionTitle}>
                    All Courses
                </Typography.Title>

                <Row gutter={[16, 16]}>
                    {mappedCourses.slice(0, 5).map((course) => (
                        <Col xs={24} sm={12} md={8} lg={6} key={course.id}>
                            <CourseCard course={course} onClick={handleCourseClick}/>
                        </Col>
                    ))}
                </Row>
            </div>
        <CourseModal visible={isModalVisible} course={selectedCourse} onCancel={handleCancelModal} onEnroll={handleEnroll} />
        </div>

    );
};

export default HomePage;
