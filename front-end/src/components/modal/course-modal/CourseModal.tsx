"use client";
import React from "react"; 
import { Modal, Typography, Space, List } from "antd";
import { useStyles } from "./Style/style"

const { Title, Text, Paragraph } = Typography;

export interface Lesson {
    title: string;
}
export interface Course{
    id: string;
    title: string;
    topic: string;
    description: string;
    instructorName: string;
    lessons: Lesson[];
}
interface CourseModalProps{
    visible: boolean;
    course: Course | null;
    onCancel: () => void;
    onEnroll: (courseId: string) => void;
}
const CourseModal: React.FC<CourseModalProps> = ({
    visible, course, onCancel, onEnroll,
}) => {
    const { styles } = useStyles();

    if(!course) return null;

    return(
        <Modal title="Course Overview"
                open={visible}
                onCancel={onCancel}
                onOk={() => onEnroll(course.id)}
                okText="Enroll"
                className={styles.Container}
                width={600}>
                    <Space direction="vertical" size="middle" style={{width: "100%"}}>
                        <Title level={4}>{course.title}</Title>

                        <Text strong>Topic: </Text>
                        <Text>{course.topic}</Text>

                        <Text strong>Instructor: </Text>
                        <Paragraph>{course.instructorName}</Paragraph>

                        {course.lessons?.length > 0 && (
                            <>
                            <Text strong>Lessons Overview</Text>
                            <List size="small" bordered dataSource={course.lessons} renderItem={(lesson, index) => (
                                <List.Item>{`${index + 1}. ${lesson.title}`}</List.Item>
                            )}
                            />
                            </>
                        )}
                    </Space>
        </Modal>
    );
}
export default CourseModal;