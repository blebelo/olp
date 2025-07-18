'use client'
import React from "react";
import type { FormProps } from "antd";
import { Button, Form, Input, Typography } from 'antd';
import { useStyles } from "./Style/style";
import { MailOutlined, LockOutlined } from "@ant-design/icons";
import { useAuthActions, useAuthState } from "@/providers/auth-provider";
import { IUser } from "@/providers/auth-provider/context";
import Link from "next/link";

const Login: React.FC = () => {

    const { styles } = useStyles();
    const { loginUser } = useAuthActions();
    const { isError } = useAuthState();

    if (isError) {
        return (<div>Login Error</div>)
    }

    const onFinish: FormProps<IUser>['onFinish'] = (values) => {
        const newUser: IUser = {
            userNameOrEmailAddress:values.userNameOrEmailAddress,
            password: values.password
        }
        loginUser(newUser);
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
                <Typography className={styles.Typography}>Login</Typography>
                <div className={styles.FormItems}>
                    <Form.Item<IUser>
                        name="userNameOrEmailAddress"
                        rules={[{ required: true, message: 'Please input your username or email' }]}
                    >
                        <Input placeholder="Email" className={styles.Input} prefix={<MailOutlined />} />
                    </Form.Item>
                    <Form.Item<IUser>
                        name="password"
                        rules={[{ required: true, message: 'Please input your password!' }]}
                    >
                        <Input.Password placeholder="Password" className={styles.Input} prefix={<LockOutlined />} />
                    </Form.Item>
                </div>

                <Form.Item>
                    <Button type="primary" htmlType="submit" className={styles.Submit}>
                        Login
                    </Button>
                </Form.Item>
                <Link href={'student-signup'}>
                    <Typography className={styles.Text}>Dont have an account? Signup</Typography>
                </Link>
            </Form>
        </div>


    )
}

export default Login;