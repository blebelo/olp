'use client'
import React from "react";
import type { FormProps } from "antd";
import { Button, Form, Input, Typography } from 'antd';
import { useStyles } from "./Style/style";
import { UserOutlined, MailOutlined, LockOutlined, FormOutlined } from "@ant-design/icons";
import { useAuthActions, useAuthState } from "@/providers/auth-provider";
import { IUser } from "@/providers/auth-provider/context";
import Link from "next/link";

const StudentSignUp: React.FC = () => {

    const { styles } = useStyles();
    const { registerStudent } = useAuthActions();
    const { isError } = useAuthState();

    if (isError) {
        return (<div>Error registering instructor</div>)
    }

    const onFinish: FormProps<IUser>['onFinish'] = (values) => {
        const newUser: IUser = {
            name: values.name,
            surname: values.surname,
            userName: values.userName,
            email: values.email,
            password: values.password,
            interests: values.interests,
            academicLevel: values.academicLevel

        }
        registerStudent(newUser);
    };

    const onFinishFailed: FormProps<IUser>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return (
        <div className={styles.container}>
            <div className={`${styles.decorativeCircle} ${styles.circleTopLeft}`} />
            <div className={`${styles.decorativeCircle} ${styles.circleBottomRight}`} />
            <Form
                name="studentSignup"
                className={styles.formWrapper}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <Typography className={styles.brandName}>Dev Academy</Typography>
                <Typography className={styles.title}>Student Sign Up</Typography>

                <Form.Item<IUser> name="name" rules={[{ required: true, message: 'Please input your Name' }]} className={styles.formItem}>
                    <Input placeholder="Name" className={styles.input} prefix={<UserOutlined />} />
                </Form.Item>

                <Form.Item<IUser> name="surname" rules={[{ required: true, message: 'Please input your surname' }]} className={styles.formItem}>
                    <Input placeholder="Surname" className={styles.input} prefix={<MailOutlined />} />
                </Form.Item>

                <Form.Item<IUser> name="userName" rules={[{ required: true, message: 'Please input your username' }]} className={styles.formItem}>
                    <Input placeholder="Username" className={styles.input} prefix={<MailOutlined />} />
                </Form.Item>

                <Form.Item<IUser> name="email" rules={[{ required: true, message: 'Please input your email' }]} className={styles.formItem}>
                    <Input placeholder="Email" className={styles.input} prefix={<MailOutlined />} />
                </Form.Item>

                <Form.Item<IUser> name="password" rules={[{ required: true, message: 'Please input your password!' }]} className={styles.formItem}>
                    <Input.Password placeholder="Password" className={styles.input} prefix={<LockOutlined />} />
                </Form.Item>

                <Form.Item<IUser> name="interests" rules={[{ required: true, message: 'Please input your interests' }]} className={styles.formItem}>
                    <Input placeholder="Interests" className={styles.input} prefix={<FormOutlined />} />
                </Form.Item>

                <Form.Item<IUser> name="academicLevel" rules={[{ required: true, message: 'Please input your academic level' }]} className={styles.formItem}>
                    <Input placeholder="Academic Level" className={styles.input} prefix={<FormOutlined />} />
                </Form.Item>

                <Form.Item>
                    <Button type="primary" htmlType="submit" className={styles.submitButton}>
                        Sign Up
                    </Button>
                </Form.Item>

                <Link href="/login">
                    <Typography className={styles.linkText}>Already have an account? Login</Typography>
                </Link>
            </Form>

        </div>


    )
}

export default StudentSignUp;