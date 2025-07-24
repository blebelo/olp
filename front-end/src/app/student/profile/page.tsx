
"use client";
import React, { useEffect, useContext } from "react";
import { IStudent } from "@/providers/types";
import { useStyles } from "../Styles/style";
import { useProfileFieldStyles } from "../../shared/profileFieldStyles";

import { StudentProfileStateContext, StudentProfileActionContext } from "@/providers/studentProvider/context";
import { Card, Spin, Typography, Button, Input, Form, message, Avatar } from "antd";
import { UserOutlined, BookOutlined, IdcardOutlined, BulbOutlined, SolutionOutlined } from '@ant-design/icons';

const StudentProfilePage: React.FC = () => {
  const { styles } = useStyles();
  const { styles: fieldStyles } = useProfileFieldStyles();

  const { profile, isPending, isError } = useContext(StudentProfileStateContext);
  const { getProfile, updateProfile } = useContext(StudentProfileActionContext) || {};
  const [editMode, setEditMode] = React.useState(false);
  const [form] = Form.useForm();
  const [saving, setSaving] = React.useState(false);

  useEffect(() => {
    getProfile?.();
  }, [getProfile]);





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
        <Card className={styles.courseCard} style={{ maxWidth: 500, margin: '0 auto', background: 'rgba(255,255,255,0.95)', position: 'relative', boxShadow: '0 4px 32px rgba(68,160,141,0.12)', borderRadius: 20, padding: 24 }}>
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
          <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', marginBottom: 24 }}>
            <Avatar size={96} style={{ background: '#44a08d', fontSize: 36, marginBottom: 12 }}>
              {profile?.name?.[0]?.toUpperCase() || 'S'}
            </Avatar>
            <Typography.Title level={2} style={{ color: '#44a08d', textAlign: 'center', marginBottom: 0 }}>Student Profile</Typography.Title>
          </div>
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
            <div style={{ width: '100%', marginTop: 16 }}>
              <div style={{ background: '#f6faf9', borderRadius: 12, padding: 20, boxShadow: '0 2px 8px rgba(68,160,141,0.06)' }}>
                {[
                  { icon: <UserOutlined />, label: 'Name', value: profile?.name },
                  { icon: <IdcardOutlined />, label: 'Surname', value: profile?.surname },
                  { icon: <BookOutlined />, label: 'Academic Level', value: profile?.academicLevel },
                  { icon: <BulbOutlined />, label: 'Interests', value: profile?.interests ?? '-' },
                  { icon: <SolutionOutlined />, label: 'Username', value: profile?.userName }
                ].map((field, idx, arr) => (
                  <div
                    key={field.label}
                    className={fieldStyles.profileFieldRow}
                    style={{ borderBottom: idx !== arr.length - 1 ? '1px solid #e6e6e6' : 'none', padding: '10px 0' }}
                  >
                    <span className={fieldStyles.profileFieldLabel} style={{ minWidth: 120 }}>
                      <Avatar icon={field.icon} style={{ background: '#44a08d', marginRight: 10 }} size={24} />
                      {field.label}
                    </span>
                    <span className={fieldStyles.profileFieldValue}>
                      {field.value || <span style={{ color: '#bbb' }}>-</span>}
                    </span>
                  </div>
                ))}
              </div>
              <Button type="primary" onClick={handleEdit} style={{ marginTop: 24, width: '100%' }}>Edit</Button>
            </div>
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


