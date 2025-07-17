"use client"
import React, { useState } from "react";
import { Layout, Typography, Button, Row, Col, Card, Form, Upload } from "antd";
import { useStyles } from "./Style/style";
import Link from "next/link";
import InstructorHeader from "@/components/instructorNavbar/InstructorHeader";
import ReusableModalForm from "@/components/modal/ReusableModalForm";
import type { FieldConfig } from "@/components/modal/ReusableModalForm";
import { UploadOutlined } from "@ant-design/icons";


const CourseDetails = () => {
    const { styles } = useStyles();
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [isAddLesson, setIsAddLesson] = useState(false);
    const [form] = Form.useForm();
    const { Sider, Content } = Layout;

    const handleUpdateCourse = () => {
        form.validateFields().then((values) => {
            console.log("Course updated:", values);
            form.resetFields();
            setIsModalVisible(false);
        });
    };

    const handleAddLesson = () => {
        form.validateFields().then((values) => {
            console.log("Lesson Added:", values);
            form.resetFields();
            setIsAddLesson(false);
        });
    };

    const handleCancel = () => {
        form.resetFields();
        setIsModalVisible(false);
    };
    const handleCancelAdd = () => {
        form.resetFields();
        setIsAddLesson(false);
    };

    const courseUpdateFields: FieldConfig[] = [
        {
            label: "Course Title",
            name: "title",
            rules: [{ required: true, message: "Please enter course title" }],
            type: "input",
        },
        {
            label: "Topic",
            name: "topic",
            rules: [{ required: true, message: "Please enter course description" }],
            type: "input",
        },
        {
            label: "Course Description",
            name: "description",
            rules: [{ required: true, message: "Please enter course description" }],
            type: "input",
        },

    ];

    const lessonFields: FieldConfig[] = [
        {
            label: "Lesson Name",
            name: "lessonName",
            rules: [{ required: true, message: "Please enter lesson name" }],
            type: "input",
        },
        {
            label: "Description",
            name: "description",
            rules: [{ required: true, message: "Please enter description" }],
            type: "textarea",
        },
        {
            label: "Video Upload",
            name: "video",
            type: "custom",
            component: (
                <Upload
                    name="video"
                    maxCount={1}
                    beforeUpload={() => false}
                >
                    <Button icon={<UploadOutlined />}>Upload Video</Button>
                </Upload>
            ),
        },
        {
            label: "Additional Content",
            name: "additionalContent",
            type: "custom",
            component: (
                <Upload
                    name="documents"
                    multiple
                    beforeUpload={() => false}
                >
                    <Button icon={<UploadOutlined />}>Upload Documents</Button>
                </Upload>
            ),
        },
    ];

    return (
        <>
            <InstructorHeader />
            <Layout className={styles.Container}>

                <Layout>
                    <Sider className={styles.Sider} width="30%">
                        <Typography className={styles.Typography}>JavaScript Fundamentals</Typography>
                        <Button className={styles.Button} onClick={() => setIsAddLesson(true)}> Add Lesson</Button>
                        <ReusableModalForm
                            title="Add Lesson"
                            isVisible={isAddLesson}
                            onCancel={handleCancelAdd}
                            onSubmit={handleAddLesson}
                            fields={lessonFields}
                            form={form}
                        />
                        <Typography className={styles.CourseLesson}>Course Lessons</Typography>
                        <Link href={"/instructor"} className={styles.LessonItem}>
                            1. Introduction to JS
                        </Link>
                        <Link href={"/instructor"} className={styles.LessonItem}>
                            2. Variables and Data Types
                        </Link>
                        <Link href={"/instructor"} className={styles.LessonItem}>
                            3. Functions and Scope
                        </Link>
                    </Sider>
                    <Content className={styles.Content}>
                        <Typography className={styles.CourseDetailsTitle}>Course Details</Typography>
                        <Button className={styles.ManageButton} onClick={() => setIsModalVisible(true)}> Update Details</Button>
                        <ReusableModalForm
                            title="Update Course"
                            isVisible={isModalVisible}
                            onCancel={handleCancel}
                            onSubmit={handleUpdateCourse}
                            fields={courseUpdateFields}
                            form={form}
                        />
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