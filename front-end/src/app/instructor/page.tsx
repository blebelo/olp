"use client";
import React, { useState, useEffect } from "react";
import { Row, Col, Typography, Button, Form } from "antd";
import { useStyles } from "./style";
import CourseCard, { CourseType } from "@/components/course-card/CourseCard";
import ReusableModalForm from "@/components/modal/ReusableModalForm";
import { useCourseActions, useCourseState } from "@/providers/course-provider";
import { useInstructorProfileState } from "@/providers/instructorProvider";
import { ICourse } from "@/providers/course-provider/context";
import type { FieldConfig } from "@/components/modal/ReusableModalForm";
import Link from "next/link";

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
    const { createCourse, getAllCourses, setCoursePublished } = useCourseActions();
    const { profile } = useInstructorProfileState();
    const { isError } = useCourseState();
    const { courses } = useCourseState();

    useEffect(() => {
        getAllCourses();
    }, [getAllCourses]);
    if (profile?.id) {
        sessionStorage.setItem('userId', profile.id);
    }

    const mappedCourses: CourseType[] = (courses || []).map((course: ICourse) => ({
        id: course.id ?? 'unknown-id',
        name: course.title ?? 'Untitled Course',
        topic: course.topic ?? 'General',
        description: course.description ?? 'No description provided.',
        thumbnail: "/images/image2.jpg",
        isPublished: course.isPublished ?? false,
        onPublishToggle: async (courseId: string, newStatus: boolean) => {
            // Optimistically update UI
            if (Array.isArray(courses)) {
                const idx = courses.findIndex(c => c.id === courseId);
                if (idx !== -1) {
                    courses[idx].isPublished = newStatus;
                }
            }
            await setCoursePublished(courseId, newStatus);
            getAllCourses();
        }
    }));

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

                <Row gutter={[16, 16]}>
                    {mappedCourses.slice(0, 5).map((course) => (
                        <Col xs={24} sm={12} md={8} lg={6} key={course.id}>
                            <Link href={`/instructor/course/${course.id}`} style={{ display: 'block' }}>
                                <CourseCard course={course} />
                            </Link>
                        </Col>
                    ))}
                </Row>
            </div>
        </div>
    );
};

export default Dashboard;