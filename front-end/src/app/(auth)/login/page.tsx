'use client'
import React from "react";
import type { FormProps } from "antd";
import { Button, Form, Input, Typography } from 'antd';
import { useStyles } from "./Style/style";
import { MailOutlined, LockOutlined } from "@ant-design/icons";
// import Image from "next/image";
import Link from "next/link";

const Login: React.FC = () => {

    const {styles} = useStyles();

    interface IUser{
        name:string,
        email: string,
        password: string,
        confirmPassword: string,
        role:string,
        contactNumber: string,
    }

    // const onFinish: FormProps<IUser>['onFinish'] = (values) => {
    //     const newUser: IUser = {
    //         name: values.name,
    //         email: values.email,
    //         password: values.password,
    //         confirmPassword: values.confirmPassword,
    //         role: "admin",
    //         contactNumber: values.contactNumber,
    //     }
    //     signUpStudent(newUser)
    // };

    const onFinishFailed: FormProps<IUser>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return (
        <div className={styles.Container}>
            <Form
                name="basic"
                className={styles.Form}
                initialValues={{ remember: true }}
                // onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                {/* <Image
                    src="/logo.png"
                    alt="NutriCoach"
                    width={50}
                    height={50}
                    priority
                /> */}
                <Typography className={styles.Typography}>Login</Typography>
                <div className={styles.FormItems}>
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