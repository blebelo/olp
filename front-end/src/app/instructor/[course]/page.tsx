"use client"
import React from "react";
import { Layout, Typography, Button, Row, Col,Card } from "antd";
import { useStyles } from "./Style/style";
import InstructorHeader from "@/components/instructorNavbar/InstructorHeader";

const CourseDetails = () => {
    const { styles } = useStyles();
    const { Sider, Content } = Layout;

    return (
        <>
            <InstructorHeader />
            <Layout className={styles.Container}>

                <Layout>
                    <Sider className={styles.Sider} width="30%">
                        <Typography className={styles.Typography}>JavaScript Fundamentals</Typography>
                        <Button className={styles.Button}> Add Lesson</Button>
                        <Typography className={styles.CourseLesson}>Course Lessons</Typography>
                        <a className={styles.LessonItem} href="/instructor">1. Introduction to JavaScript</a>
                        <a className={styles.LessonItem} href="/instructor">2. Variables and Data Types</a>
                        <a className={styles.LessonItem} href="/instructor">3. Functions and Scope</a>
                    </Sider>
                    <Content className={styles.Content}>
                        <Typography className={styles.CourseDetailsTitle}>Course Details</Typography>
                        <Button className={styles.ManageButton}> Update Details</Button>
                        <Button className={styles.ManageButton}> View Student Progress</Button>
                        <Button className={styles.ManageButton}> Add Quiz</Button>
                        <Button className={styles.ManageButton}> Unpublish</Button>
                        <Row gutter={[16, 16]}>
                            <Col xs={22} sm={12} md={8} lg={6}>
                                <Card className={styles.CardContainer}>
                                    <Typography>45</Typography>
                                    <Typography>Enrolled</Typography>
                                </Card>
                            </Col>
                            <Col xs={22} sm={12} md={8} lg={6}>
                                <Card className={styles.CardContainer}>
                                    <Typography>12</Typography>
                                    <Typography>Completed</Typography>
                                </Card>
                            </Col>
                            <Col xs={22} sm={12} md={8} lg={6}>
                                <Card className={styles.CardContainer}>
                                    <Typography>3.2</Typography>
                                    <Typography>Rating</Typography>
                                </Card>
                            </Col>
                        </Row>
                    </Content>
                </Layout>
            </Layout>
        </>
    )
}

export default CourseDetails;