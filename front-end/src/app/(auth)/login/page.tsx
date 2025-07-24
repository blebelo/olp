'use client'
import React from "react";
import type { FormProps } from "antd";
import { Button, Form, Input, Typography } from 'antd';
import { useStyles } from "./Style/style";
import { MailOutlined, LockOutlined } from "@ant-design/icons";
import { useAuthActions, useAuthState } from "@/providers/auth-provider";
import { useInstructorProfileState, useInstructorProfileActions } from "@/providers/instructorProvider";
import { IUser } from "@/providers/auth-provider/context";
import Link from "next/link";

const Login: React.FC = () => {
  const { styles } = useStyles();
  const { profile } = useInstructorProfileState();
  const { getProfile } = useInstructorProfileActions();
  const { loginUser } = useAuthActions();
  const { isError } = useAuthState();

  if (profile?.id) sessionStorage.setItem('userId', profile.id);
  if (isError) return <div>Login Error</div>;

  const onFinish: FormProps<IUser>['onFinish'] = async (values) => {
    const newUser: IUser = {
      userNameOrEmailAddress: values.userNameOrEmailAddress,
      password: values.password
    };
    await loginUser(newUser);
    await getProfile();
    if (profile?.id) sessionStorage.setItem('userId', profile.id);
  };

  return (
    <div className={styles.container}>
      {/* Decorative Circles */}
      <div className={`${styles.decorativeCircle} ${styles.circleTopLeft}`} />
      <div className={`${styles.decorativeCircle} ${styles.circleBottomRight}`} />

      <Form
        name="loginForm"
        className={styles.formWrapper}
        onFinish={onFinish}
        autoComplete="off"
      >
        <Typography className={styles.title}>Login</Typography>

        <Form.Item<IUser>
          name="userNameOrEmailAddress"
          className={styles.formItem}
          rules={[{ required: true, message: 'Please input your username or email' }]}
        >
          <Input
            placeholder="Email"
            prefix={<MailOutlined />}
            className={styles.input}
          />
        </Form.Item>

        <Form.Item<IUser>
          name="password"
          className={styles.formItem}
          rules={[{ required: true, message: 'Please input your password!' }]}
        >
          <Input.Password
            placeholder="Password"
            prefix={<LockOutlined />}
            className={styles.input}
          />
        </Form.Item>

        <Form.Item>
          <Button type="primary" htmlType="submit" className={styles.submitButton}>
            Login
          </Button>
        </Form.Item>

        <Link href={'/student-signup'}>
          <Typography className={styles.linkText}>Dont have an account? Sign up</Typography>
        </Link>
      </Form>
    </div>
  );
};

export default Login;