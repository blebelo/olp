
"use client";
import React, { useEffect, useContext } from "react";
import { IStudent } from "@/providers/types";
import { useStyles } from "../Styles/style";

import { StudentProfileStateContext, StudentProfileActionContext } from "@/providers/studentProvider/context";
import { Card, Spin, Typography, Button, Input, Form, message } from "antd";

const StudentProfilePage: React.FC = () => {
  const { styles } = useStyles();

  const { profile, isPending, isError } = useContext(StudentProfileStateContext);
  const { getProfile, updateProfile } = useContext(StudentProfileActionContext) || {};
  const [editMode, setEditMode] = React.useState(false);
  const [form] = Form.useForm();
  const [saving, setSaving] = React.useState(false);

  useEffect(() => {
    getProfile?.();
  }, []);





  if (isError) {
    return (
      <div className={styles.heroContainer}>
        <Typography.Title level={3} style={{ color: 'white' }}>Failed to load profile</Typography.Title>
      </div>
    );
  }

  const handleEdit = () => {
    if (profile) {
      form.setFieldsValue(profile);
    }
    setEditMode(true);
  };
  const handleCancel = () => {
    setEditMode(false);
  };

  const handleSave = async (values: Partial<IStudent>) => {
    setSaving(true);
    try {
      const payload = { ...values, id: profile?.id };
      await updateProfile?.(payload);
      await getProfile?.();
      message.success("Profile updated successfully");
      setEditMode(false);
    } catch {
      message.error("Failed to update profile");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className={styles.heroContainer}>
      <div className={styles.contentRow}>
        <Card className={styles.courseCard} style={{ maxWidth: 500, margin: '0 auto', background: 'rgba(255,255,255,0.95)', position: 'relative' }}>
          {(isPending || saving) && (
            <div style={{
              position: 'absolute',
              top: 0,
              left: 0,
              width: '100%',
              height: '100%',
              background: 'rgba(255,255,255,0.7)',
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
              zIndex: 10
            }}>
              <Spin size="large" />
            </div>
          )}
          <Typography.Title level={2} style={{ color: '#44a08d', textAlign: 'center' }}>Student Profile</Typography.Title>
          {editMode ? (
            <Form
              form={form}
              layout="vertical"
              initialValues={profile ?? {}}
              onFinish={handleSave}
              disabled={isPending || saving}
            >
              {[
                { label: "Name", name: "name", rules: [{ required: true, message: 'Please input your name' }] },
                { label: "Surname", name: "surname", rules: [{ required: true, message: 'Please input your surname' }] },
                { label: "Username", name: "userName", rules: [{ required: true, message: 'Please input your username' }] },
                { label: "Academic Level", name: "academicLevel" },
                { label: "Interests", name: "interests" }
              ].map(field => (
                <Form.Item
                  key={field.name}
                  label={field.label}
                  name={field.name}
                  rules={field.rules}
                >
                  <Input id={field.name} />
                </Form.Item>
              ))}
              <Form.Item>
                <Button type="primary" htmlType="submit" style={{ marginRight: 8 }}>Save</Button>
                <Button onClick={handleCancel}>Cancel</Button>
              </Form.Item>
            </Form>
          ) : (
            <>
              <Typography.Paragraph><b>Name:</b> {profile?.name}</Typography.Paragraph>
              <Typography.Paragraph><b>Surname:</b> {profile?.surname}</Typography.Paragraph>
              <Typography.Paragraph><b>Username:</b> {profile?.userName}</Typography.Paragraph>
              <Typography.Paragraph><b>Academic Level:</b> {profile?.academicLevel}</Typography.Paragraph>
              <Typography.Paragraph><b>Interests:</b> {profile?.interests ?? "-"}</Typography.Paragraph>
              <Button type="primary" onClick={handleEdit} style={{ marginTop: 16 }}>Edit</Button>
            </>
          )}
        </Card>
      </div>
      {/* Decorative elements */}
      <div className={styles.decorativeCircleLarge}></div>
      <div className={styles.decorativeCircleSmall}></div>
      <div className={styles.decorativeCircleMedium}></div>
      <div className={styles.decorativeSquareLarge}></div>
      <div className={styles.decorativeSquareSmall}></div>
    </div>
  );
};

export default StudentProfilePage;


