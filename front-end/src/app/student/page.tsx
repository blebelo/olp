"use client";
import React, {useState} from "react";
import { Row, Col, Typography, Button, message } from "antd";
import { useStyles } from "./Styles/style";
import { sampleCourses } from "@/utils/sample-courses/sampleCourse";
import CourseCard from "@/components/course-card/CourseCard";
import CourseModal, {Course} from "@/components/modal/course-modal/CourseModal";
import { axiosInstance } from "@/utils/axiosInstance";

const HomePage = () => {
    const { styles } = useStyles();
    const [selectedCourse, setSelectedCourse] = useState<Course | null>(null);
    const [isModalVisible, setIsModalVisible] = useState(false);

    const handleCourseClick = (course: Course) => {
        setSelectedCourse(course);
        setIsModalVisible(true);
    };

    const handleCancelModal = () => {
        setSelectedCourse(null);
        setIsModalVisible(false);
    };

    const handleEnroll = async (courseId: string) => {
        try{
            await axiosInstance.post(`/api/app/student/enroll?courseId=${courseId}`);
            message.success("Enrolled successfully!");
            setIsModalVisible(false);
        }catch(error: unknown){
            if(error instanceof Error){
                message.error(error.message); 
            } else{
                message.error("Enrollment failed");
            }
        };
    }
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

                {sampleCourses.map((category) => (
                    <div key={category.category}>
                        <Typography.Title level={3} className={styles.sectionTitle}>
                            {category.category}
                        </Typography.Title>
                        <Row gutter={[16, 16]}>
                            {category.courses.slice(0, 5).map((course) => (
                                <Col xs={24} sm={12} md={8} lg={6} key={course.id} onClick={() => 
                                handleCourseClick({
                                    id: course.id.toString(),
                                    title: course.name,
                                    topic: course.topic,
                                    description: course.description,
                                    instructorName: "N/A",
                                    lessons: [],
                                })}>
                                    <CourseCard course={course} />
                                </Col>
                            ))}
                        </Row>
                        <Button
                            type="default"
                            ghost
                            className={styles.viewMoreBtn}
                        >
                            View More
                        </Button>
                    </div>
                ))}
            </div>
            <CourseModal visible={isModalVisible} course={selectedCourse} onCancel={handleCancelModal} onEnroll={handleEnroll}/>
        </div>
    );
};

export default HomePage;