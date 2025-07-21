'use client';
import { useStyles } from './Style/style';
import { Button, Progress, Typography } from 'antd';
import { courses } from '@/utils/sample-courses/courses';


export default function StudentProgressPage() {
    const { styles } = useStyles();
    const { Title, Paragraph } = Typography;
    return (
        <div className={styles.pageContainer}>
            <div className={styles.decorativeCircle} />
            <div className={styles.decorativeSquare} />
            <Title className={styles.pageTitle}>My Course Progress</Title>

            <div className={styles.courseList}>
                {courses.map((course) => (
                    <div key={course.id} className={styles.courseCard}>
                        <div className={styles.courseDetails}>
                            <Title level={4} className={styles.courseTitle}>{course.title}</Title>
                            <Paragraph className={styles.courseDescription}>{course.description}</Paragraph>

                            <div className={styles.progressContainer}>
                                <Progress
                                    percent={course.completion}
                                    status={course.completion === 100 ? 'success' : 'active'}
                                    className={styles.progressBar}
                                />
                                <span className={styles.completionText}>
                                    {course.completion === 100 && <span className={styles.completed}>Completed</span>}
                                </span>
                            </div>
                        </div>

                        <div className={styles.actionSection}>
                            <Button type="primary" className={styles.actionButton}>
                                {course.completion === 100 ? 'View Course' : 'Continue Learning'}
                            </Button>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}
