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

    const {styles} = useStyles();
    const { registerStudent } = useAuthActions();
    const {isError } = useAuthState();

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
            interest: values.interest,
            academicLevel: values.academicLevel

        }
        registerStudent(newUser);
    };

    const onFinishFailed: FormProps<IUser>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return (
        <div className={styles.Container}>
            <Form
                name="basic"
                className={styles.Form}
                initialValues={{ remember: true }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <Typography className={styles.Typography}>Student Sign Up</Typography>
                <div className={styles.FormItems}>
                    <Form.Item<IUser>
                        name="name"
                        rules={[{ required: true, message: 'Please input your Name' }]}
                    >
                        <Input placeholder="Name" className={styles.Input} prefix={<UserOutlined/>} />
                    </Form.Item>
                    <Form.Item<IUser>
                        name="surname"
                        rules={[{ required: true, message: 'Please input your surname' }]}
                    >
                        <Input placeholder="Surname" className={styles.Input} prefix={<MailOutlined />}/>
                    </Form.Item>
                    <Form.Item<IUser>
                        name="userName"
                        rules={[{ required: true, message: 'Please input your username' }]}
                    >
                        <Input placeholder="Username" className={styles.Input} prefix={<MailOutlined />}/>
                    </Form.Item>
                    <Form.Item<IUser>
                        name="email"
                        rules={[{ required: true, message: 'Please input your email' }]}
                    >
                        <Input placeholder="Email" className={styles.Input} prefix={<MailOutlined />}/>
                    </Form.Item>
                    <Form.Item<IUser>
                        name="password"
                        rules={[{ required: true, message: 'Please input your password!' }]}
                    >
                        <Input.Password placeholder="Password" className={styles.Input} prefix={<LockOutlined />} />
                    </Form.Item>
                    <Form.Item<IUser>
                        name="interest"
                        rules={[{ required: true, message: 'Please input your interests' }]}
                    >
                        <Input placeholder="interests" className={styles.Input} prefix={<FormOutlined />}/>
                    </Form.Item>
                    <Form.Item<IUser>
                        name="academicLevel"
                        rules={[{ required: true, message: 'Please input your academicLevel' }]}
                    >
                        <Input placeholder="academicLevel" className={styles.Input} prefix={<FormOutlined />}/>
                    </Form.Item>
                    {/* <Form.Item
                        name="confirmPassword"
                        rules={[{ required: true, message: 'Please confirm password!' }]}
                    >
                        <Input.Password placeholder="Confirm Password" className={styles.Input} prefix={<LockOutlined />} />
                    </Form.Item> */}
                </div>

                <Form.Item>
                    <Button type="primary" htmlType="submit" className={styles.Submit}>
                        Sign Up
                    </Button>
                </Form.Item>
                <Link href={'login'}>
                    <Typography className={styles.Text}>Already have an account? Login</Typography>
                </Link>
            </Form>
        </div>


    )
}

export default StudentSignUp;