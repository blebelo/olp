"use client";
import React, { useState, useEffect } from "react";
import { Modal, Space, Input, Form, Button } from "antd";
import { useStyles } from "./Style/style";
import {ICourse} from "@/providers/course-provider/context";

const { TextArea } = Input;

interface EditCourseModalProps {
  visible: boolean;
  course: ICourse | null;
  onCancel: () => void;
  onSubmit: (updatedCourse: ICourse) => void;
}

const EditCourseModal: React.FC<EditCourseModalProps> = ({
  visible,
  course,
  onCancel,
  onSubmit,
}) => {
  const { styles } = useStyles();
  const [form] = Form.useForm();
  const [initialValues, setInitialValues] = useState<ICourse | null>(null);

  useEffect(() => {
    if (course) {
      setInitialValues(course);
      form.setFieldsValue({
        title: course.title,
        topic: course.topic,
        description: course.description,
      });
    }
  }, [course, form]);

  const handleFinish = (values: Pick<ICourse, 'title' | 'topic' | 'description'>) => {
    if (course) {
      onSubmit({ ...course, ...values });
    }
  };

  return (
    <Modal
      title="Edit Course"
      open={visible}
      onCancel={onCancel}
      footer={null}
      className={styles.Container}
      width={600}
      onOk={() => form.submit()}
      okText="Save Changes"
    >
      <Form
        form={form}
        layout="vertical"
        initialValues={initialValues || {}}
        onFinish={handleFinish}
      >
        <Form.Item
          label="Course Title"
          name="title"
          rules={[{ required: true, message: "Please enter the course title" }]}
        >
          <Input placeholder="Enter course title" />
        </Form.Item>

        <Form.Item
          label="Topic"
          name="topic"
          rules={[{ required: true, message: "Please enter the course topic" }]}
        >
          <Input placeholder="Enter topic" />
        </Form.Item>

        <Form.Item
          label="Description"
          name="description"
          rules={[{ required: true, message: "Please enter the description" }]}
        >
          <TextArea rows={4} placeholder="Enter course description" />
        </Form.Item>

        <Form.Item>
          <Space>
            <Button onClick={onCancel}>Cancel</Button>
            <Button type="primary" htmlType="submit">
              Save Changes
            </Button>
          </Space>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default EditCourseModal;
