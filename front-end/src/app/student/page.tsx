'use client';
import { useEffect } from "react";
import { Typography, Button, Row, Col } from "antd";
import { useStyles } from "./Styles/style";
import CourseCard, { CourseType } from "@/components/course-card/CourseCard";
import { useCourseActions, useCourseState } from "@/providers/course-provider";
import { ICourse } from "@/providers/course-provider/context";
const HomePage = () => {
    const { styles } = useStyles();
    const { getAllCourses } = useCourseActions();
    const { isError, courses } = useCourseState();

    useEffect(() => {
        getAllCourses();
    }, []);

    const mappedCourses: CourseType[] = (courses || []).map((course: ICourse) => ({
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
                            <CourseCard course={course} />
                        </Col>
                    ))}
                </Row>
            </div>
        </div>
    );
};

export default HomePage;
