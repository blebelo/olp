'use client';
import React from 'react';
import { Typography, Button, Row, Col, Space } from 'antd';
import { SearchOutlined, PlayCircleOutlined } from '@ant-design/icons';
import styles from './LandingPage.module.css';
import { useRouter } from 'next/navigation';

const { Title, Paragraph } = Typography;

const LandingPage: React.FC = () => {

  const router = useRouter();

  const handleInstructor = () => {
    router.push('/instructor-signup');
  }

    const handleStudent = () => {
    router.push('/student-signup');
  }

  return (
    <div className={styles.heroContainer}>

    <div className={styles.navbar}>
        <div className={styles.navContent}>
          <div className={styles.logo}>
            <img src="/globe.svg" alt="Logo" className={styles.logoImage} />
            <span className={styles.siteName}>DevAcademy</span>
          </div>
        </div>
      </div>

      <div className={styles.decorativeCircleLarge}></div>
      <div className={styles.decorativeCircleSmall}></div>

      <Row justify="center" align="middle" className={styles.contentRow}>
        <Col xs={24} sm={24} md={12} lg={11} xl={10}>
          <div className={styles.textContainer}>
            <Title level={1} className={styles.mainTitle}>
              Learn with Us Anytime, Anywhere!
            </Title>
            
            <Paragraph className={styles.subtitleText}>
              Continue as an Instructor or Student
            </Paragraph>
            
            <Space size="large" wrap>
              <Button 
                type="primary" 
                size="large"
                icon={<SearchOutlined />}
                className={styles.primaryButton}
                onClick={handleInstructor}
              >
                Instructor
              </Button>
              
              <Button 
                size="large"
                icon={<PlayCircleOutlined />}
                className={styles.secondaryButton}
                onClick={handleStudent}
              >
                Student
              </Button>
            </Space>
          </div>
        </Col>
        
        <Col xs={24} sm={24} md={12} lg={13} xl={14}>
          <div className={styles.imageContainer}>
            <div className={styles.personPlaceholder}>
              👨‍💻
            </div>
          </div>
        </Col>
      </Row>
    </div>
  );
};

export default LandingPage;