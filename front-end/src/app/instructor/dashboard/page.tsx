"use client"
import React, { useState } from "react";
import { Card, Button, Layout, Typography, Form } from "antd";
import { useStyles } from "./style/style";
import InstructorHeader from "@/components/instructorNavbar/InstructorHeader";
import ReusableModalForm from "@/components/modal/ReusableModalForm";
import type { FieldConfig } from "@/components/modal/ReusableModalForm";


const Dashboard = () => {
    const { styles } = useStyles();
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [form] = Form.useForm();

    const { Content } = Layout;
    const { Title } = Typography;

    const courseFormFields: FieldConfig[] = [
        {
            label: "Course Title",
            name: "title",
            rules: [{ required: true, message: "Please enter course title" }],
            type: "input",
        },
        {
            label: "Course Description",
            name: "description",
            rules: [{ required: true, message: "Please enter course description" }],
            type: "input",
        },
        
    ];

    const handleCreateCourse = () => {
        form.validateFields().then((values) => {
            console.log("Course created:", values);
            form.resetFields();
            setIsModalVisible(false);
        });
    };

    const handleCancel = () => {
        form.resetFields();
        setIsModalVisible(false);
    };


    const courses = [
        {
            id: 1,
            title: "JavaScript Fundamentals",
            students: 25,
            lessons: 8,
            status: "Published"
        },
        {
            id: 2,
            title: "React Essentials",
            students: 30,
            lessons: 10,
            status: "Published"
        },
        {
            id: 3,
            title: "Node.js Basics",
            students: 18,
            lessons: 6,
            status: "Unpublished"
        }
    ];

    return (
        <Layout>
            <InstructorHeader />
            <Content className={styles.Container}>
                <Title className={styles.Heading}>My Courses</Title>
                <Button className={styles.Button} onClick={() => setIsModalVisible(true)} type="primary">Create Course</Button>
                <ReusableModalForm
                    title="Create New Course"
                    isVisible={isModalVisible}
                    onCancel={handleCancel}
                    onSubmit={handleCreateCourse}
                    fields={courseFormFields}
                    form={form}
                />
                {courses.map((course) => (
                    <Card
                        key={course.id}
                        title={course.title}
                        className={styles.CardContainer}
                        variant="borderless"
                    >
                        <p>{course.students} Students • {course.status} • {course.lessons} Lessons</p>
                        <Button className={styles.Button} type="primary">Manage Course</Button>
                        <Button className={styles.Button} type="primary">View Analytics</Button>
                    </Card>
                ))}
            </Content>
        </Layout>
    )
}

export default Dashboard;