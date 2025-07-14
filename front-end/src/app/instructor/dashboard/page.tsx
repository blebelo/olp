"use client"
import React from "react";
import { Card, Button, Layout, Typography } from "antd";
import { useStyles } from "./style/style";
import InstructorHeader from "@/components/instructorNavbar/InstructorHeader";


const Dashboard = () => {
    const { styles } = useStyles();
    const { Content } = Layout;
    const { Title } = Typography;

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
                <Title  className={styles.Heading}>My Courses</Title>
                <Button className={styles.Button} type="primary">Create Course</Button>
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