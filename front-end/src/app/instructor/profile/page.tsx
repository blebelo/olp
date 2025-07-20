"use client";
import React, { useState } from "react";
import { Card, Layout, Typography, Skeleton, Alert, Button, Form, notification } from "antd";
import InstructorHeader from "@/components/instructorNavbar/InstructorHeader";
import { useStyles } from "../style";
import { useInstructorProfileState, useInstructorProfileActions } from "@/providers/instructorProvider";
import ReusableModalForm, { FieldConfig } from "@/components/modal/ReusableModalForm";

const { Content } = Layout;
const { Title, Paragraph } = Typography;


export default function InstructorProfilePage() {
  const { profile, isPending: profilePending, error: profileError } = useInstructorProfileState();
  const { updateProfile } = useInstructorProfileActions();
  const { styles } = useStyles();
  const [isEditModalVisible, setIsEditModalVisible] = useState(false);
  const [editForm] = Form.useForm();
  const [editLoading, setEditLoading] = useState(false);
  const [editError, setEditError] = useState<string | null>(null);
  
  console.log('Instructor profile:', profile);

  const editProfileFields: FieldConfig[] = [
    { label: "Name", name: "name", rules: [{ required: true, message: "Enter name" }], type: "input" },
    { label: "Surname", name: "surname", rules: [{ required: true, message: "Enter surname" }], type: "input" },
    { label: "Bio", name: "bio", type: "textarea" },
    { label: "Profession", name: "profession", type: "input" }
  ];

  const handleUpdateProfile = async () => {
    setEditError(null);
    setEditLoading(true);
    try {
      const values = await editForm.validateFields();
      if (!profile) {
        setEditLoading(false);
        setEditError("Profile data not loaded.");
        return;
      }
      
      const payload = {
        id: profile.id,
        name: values.name,
        surname: values.surname,
        userName: profile.userName,
        bio: values.bio,
        profession: values.profession,
        email: profile.email
      };
      await updateProfile(payload);
      setIsEditModalVisible(false);
      notification.success({ message: "Profile updated successfully!" });
    } catch (err: any) {
      const msg = err?.message || "Failed to update profile.";
      setEditError(msg);
      notification.error({ message: msg });
    } finally {
      setEditLoading(false);
    }
  };

  const handleCancelEdit = () => setIsEditModalVisible(false);

let content;
if (profilePending) {
  content = <Skeleton active paragraph={{ rows: 4 }} title />;
} else if (profile) {
  content = (
    <>
      <Card
        className={styles.CardContainer}
        title={`${profile.name} ${profile.surname}`}
      >
        <Paragraph>
          <strong>Username:</strong> {profile.userName}
        </Paragraph>
        <Paragraph>
          <strong>Email:</strong> {profile.email}
        </Paragraph>
        <Paragraph>
          <strong>Profession:</strong> {profile.profession}
        </Paragraph>
        <Paragraph>
          <strong>Bio:</strong> {profile.bio}
        </Paragraph>
      </Card>
      <Button
        type="default"
        onClick={() => setIsEditModalVisible(true)}
        style={{ marginTop: 16 }}
        disabled={profilePending || editLoading}
      >
        Edit My Profile
      </Button>
      {isEditModalVisible && (
        <ReusableModalForm
          title="Edit Profile"
          isVisible={isEditModalVisible}
          onCancel={handleCancelEdit}
          onSubmit={handleUpdateProfile}
          fields={editProfileFields}
          form={editForm}
          initialValues={profile}
        />
      )}
      {editError && <Alert type="error" message={editError} showIcon style={{ marginTop: 8 }} />}
      {profileError && <Alert type="error" message={profileError} showIcon style={{ marginTop: 8 }} />}
    </>
  );
} else if (profileError) {
  content = <Alert type="error" message={profileError} />;
} else {
  content = <Alert type="info" message="No profile data found." />;
}

  return (
    <Layout>
      <InstructorHeader />
      <Content className={styles.Container}>
        <Title className={styles.Heading}>My Profile</Title>
        {content}
      </Content>
    </Layout>
  );
}
