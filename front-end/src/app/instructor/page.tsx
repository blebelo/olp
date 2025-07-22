"use client";
import React, { useState } from "react";
import { Row, Col, Typography, Button, Form } from "antd";
import { useStyles } from "./style";
import { instructorCourses } from "@/utils/sample-courses/instructorCourses";
import CourseCard from "@/components/course-card/CourseCard";
import ReusableModalForm from "@/components/modal/ReusableModalForm";
import { useCourseActions, useCourseState } from "@/providers/course-provider";
import { ICourse } from "@/providers/course-provider/context";
import type { FieldConfig } from "@/components/modal/ReusableModalForm";

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


const Dashboard = () => {
    const { styles } = useStyles();
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [form] = Form.useForm();
    const { createCourse } = useCourseActions();
    const { isError } = useCourseState();

    const handleCreateCourse = () => {
        form.validateFields().then((values) => {

            const id = sessionStorage.getItem('userId');

            if (!id) {
                throw new Error("Instructor not found");
            }
            const newCourse: ICourse = {
                title: values.title,
                topic: values.topic,
                description: values.description,
                instructorId: id
            }
            createCourse(newCourse);
            console.log("Course created:", values);
            form.resetFields();
            setIsModalVisible(false);
        });

        if (isError) {
            return (<div>Error creating course</div>)
        }
    };

    const handleCancel = () => {
        form.resetFields();
        setIsModalVisible(false);
    };

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
                        Welcome to your dashboard
                    </Typography.Title>
                    <Button className={styles.primaryButton} onClick={() => setIsModalVisible(true)}>Create New Course</Button>
                    <ReusableModalForm
                        title="Create Course"
                        isVisible={isModalVisible}
                        onCancel={handleCancel}
                        onSubmit={handleCreateCourse}
                        fields={courseUpdateFields}
                        form={form}
                        
                    />
                </div>

                {instructorCourses.map((category) => (
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
                    </div>
                ))}
            </div>
        </div>
    );
};

export default Dashboard;