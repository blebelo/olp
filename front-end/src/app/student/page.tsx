"use client";
import React from "react";
import { Row, Col, Typography, Button } from "antd";
import { useStyles } from "./Styles/style";
import { sampleCourses } from "@/utils/sample-courses/sampleCourse";
import CourseCard from "@/components/course-card/CourseCard";
import StudentNavbar from "@/components/student-nabvar/page";

const HomePage = () => {
    const { styles } = useStyles();

    return (
       <>
            <StudentNavbar/>
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
                                <Col xs={24} sm={12} md={8} lg={6} key={course.id}>
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
        </div>
       </>
    );
};

export default HomePage;