'use client';

import { useState, useEffect } from 'react';
import { useParams } from 'next/navigation';
import { Button, Typography } from 'antd';
import { CheckCircleFilled, FileTextOutlined } from '@ant-design/icons';
import { useStyles } from '../Style/style';
import { useCourseActions, useCourseState } from '@/providers/course-provider';
const { Title, Paragraph } = Typography;

const getEmbeddedURL = (url: string) : string => {
  if(!url) return '';

  // YouTube standard format
  const youtubeMatch = url.match(/(?:https?:\/\/)?(?:www\.)?youtube\.com\/watch\?v=([^&]+)/);
  if (youtubeMatch?.[1]) {
    return `https://www.youtube.com/embed/${youtubeMatch[1]}`;
  }

  // YouTube short link format
  const shortMatch = url.match(/(?:https?:\/\/)?youtu\.be\/([^?&]+)/);
  if (shortMatch?.[1]) {
    return `https://www.youtube.com/embed/${shortMatch[1]}`;
  }

  return url;
}

export default function CourseLessonsPage() {
  const { styles } = useStyles();
  const { id } = useParams();
  const { getCourseById } = useCourseActions();
  const { course } = useCourseState();
  const [ activeLessonIndex, setActiveLessonIndex ] = useState(0);
  const [ completedLessons, setCompletedLessons ] = useState<number[]>([]);
  const [selectedCourseTitle, setSelectedCourseTitle] = useState('');

useEffect(() => {
  if (id) {
    getCourseById(id.toString());
  }
}, [id]);

useEffect(() => {
  if (course?.title) {
    setSelectedCourseTitle(course.title);
  }
}, [course]);
 // Mark a lesson as completed
  const markLessonComplete = (index: number) => {
    setCompletedLessons(prev => [...prev, index]);
  };
  const lessons = course?.lessons || [];
  const activeLesson = lessons[activeLessonIndex];
  

  return (
    <div className={styles.pageContainer}>
      <div className={styles.decorativeCircle} />
      <div className={styles.decorativeSquare} />

      <h1 className={styles.header}>Course Name: {selectedCourseTitle ?? 'Loading...'}</h1>

      <div className={styles.content}>
        <aside className={styles.sidebar}>
          <div>
            {lessons.map((lesson, index) => (
              <Button
                key={lesson.id}
                type="primary"
                className={`${styles.lessonItem} ${index === activeLessonIndex ? styles.activeLesson : ''}`}
                onClick={() => setActiveLessonIndex(index)}
                >
                  <span>{lesson.title}</span>
                  {completedLessons.includes(index) && (
                    <CheckCircleFilled className={styles.completedIcon} />
                  )}
                </Button>
            ))}
          </div>

          <div className={styles.quizButton}>Take Quiz</div>
        </aside>

        <main className={styles.mainContent}>
          <Title level={3} className={styles.lessonTitle}>
            {activeLesson?.title}
          </Title>
          <Paragraph className={styles.lessonDescription}>
            {activeLesson?.description}
          </Paragraph>

          <div className={styles.videoWrapper}>
            <iframe
              src={getEmbeddedURL(activeLesson?.videoLink || '')}
              style={{ border: 'none' }}
              allow="autoplay; encrypted-media"
              allowFullScreen
              title="video"
            />
          </div>

          <div className={styles.materialWrapper}>
            <strong>Materials:</strong>
            <div className={styles.materialLink}>
              {(activeLesson?.studyMaterial ?? []).map((material: string, i: number) => (
                <a key={i} href={material} target='_blank' className={styles.materialLink}>
                  <FileTextOutlined />
                  {material}
                </a>
              ))}
            </div>
          </div>

          {!completedLessons.includes(activeLessonIndex) && (
            <Button
              type="primary"
              className={styles.completeButton}
              onClick={() => markLessonComplete(activeLessonIndex)}
            >
              Mark as Complete
            </Button>
          )}
        </main>
      </div>
    </div>
  );
}
