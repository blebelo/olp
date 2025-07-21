'use client';

import { useState } from 'react';
import { Button, Typography } from 'antd';
import { CheckCircleFilled, FileTextOutlined } from '@ant-design/icons';
import { useStyles } from './Style/style';
import { initialLessons } from '@/utils/sample-courses/lessons';
const { Title, Paragraph } = Typography;



export default function CourseLessonsPage() {
  const { styles } = useStyles();
  const [lessons, setLessons] = useState(initialLessons);
  const [activeLesson, setActiveLesson] = useState(initialLessons[0]);

  const markLessonComplete = (id: number) => {
    setLessons(prev =>
      prev.map(lesson =>
        lesson.id === id ? { ...lesson, isCompleted: true } : lesson
      )
    );
  };

  return (
    <div className={styles.pageContainer}>
      <div className={styles.decorativeCircle} />
      <div className={styles.decorativeSquare} />

      <h1 className={styles.header}>Course Name: React Fundamentals</h1>

      <div className={styles.content}>
        <aside className={styles.sidebar}>
          <div>
            {lessons.map((lesson) => (
              <Button
                key={lesson.id}
                type="primary"
                className={`${styles.lessonItem} ${activeLesson.id === lesson.id ? styles.activeLesson : ''
                  }`}
                onClick={() => setActiveLesson(lesson)}
              >
                <span>{lesson.title}</span>
                {lesson.isCompleted && <CheckCircleFilled className={styles.completedIcon} />}
              </Button>
            ))}
          </div>

          <div className={styles.quizButton}>Take Quiz</div>
        </aside>

        <main className={styles.mainContent}>
          <Title level={3} className={styles.lessonTitle}>
            {activeLesson.title}
          </Title>
          <Paragraph className={styles.lessonDescription}>
            {activeLesson.description}
          </Paragraph>

          <div className={styles.videoWrapper}>
            <iframe
              src={activeLesson.videoUrl}
              style={{ border: 'none' }}
              allow="autoplay; encrypted-media"
              allowFullScreen
              title="video"
            />
          </div>

          <div className={styles.materialWrapper}>
            <strong>Materials:</strong>
            <div className={styles.materialLink}>
              {activeLesson.materials.map((material, i) => (
                <a key={i} href="https://olp-six.vercel.app/" className={styles.materialLink}>
                  <FileTextOutlined />
                  {material}
                </a>
              ))}
            </div>
          </div>

          {!activeLesson.isCompleted && (
            <Button
              type="primary"
              className={styles.completeButton}
              onClick={() => markLessonComplete(activeLesson.id)}
            >
              Mark as Complete
            </Button>
          )}
        </main>
      </div>
    </div>
  );
}
