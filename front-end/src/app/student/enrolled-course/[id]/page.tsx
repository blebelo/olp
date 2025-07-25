'use client';

import { useState, useEffect, useContext } from 'react';
import { useParams } from 'next/navigation';
import { Button, Typography } from 'antd';
import { CheckCircleFilled, FileTextOutlined } from '@ant-design/icons';
import { useStyles } from '../Style/style';
import { initialLessons } from '@/utils/sample-courses/lessons';
import { StudentEnrollmentStateContext } from '@/providers/enrollment-provider/context';
import { useCourseActions, useCourseState } from '@/providers/course-provider';
const { Title, Paragraph } = Typography;

export default function CourseLessonsPage() {
  const { styles } = useStyles();
  const { id } = useParams();
  const { getCourseById } = useCourseActions();
  const { course } = useCourseState();
  const [ activeLessonIndex, setActiveLessonIndex ] = useState(0);
  const [ completedLessons, setCompletedLessons ] = useState<number[]>([]);

  const {enrolledCourses} = useContext(StudentEnrollmentStateContext);
  
 // const [lessons, setLessons] = useState(initialLessons);
  //const [activeLesson, setActiveLesson] = useState(initialLessons[0]);
  const [selectdCourseTitle, setSelectedCourseTitle] = useState('');

useEffect(() => {
  if (id) {
    getCourseById(id.toString());
  }
}, [id]);

 // Mark a lesson as completed
  const markLessonComplete = (index: number) => {
    setCompletedLessons(prev => [...prev, index]);
  };
  const lessons = course?.lessons || [];
  const activeLesson = lessons[activeLessonIndex];
  
  // const markLessonComplete = (id: number) => {
  //   setLessons(prev =>
  //     prev.map(lesson =>
  //       lesson.id === id ? { ...lesson, isCompleted: true } : lesson
  //     )
  //   );
  // };

  return (
    <div className={styles.pageContainer}>
      <div className={styles.decorativeCircle} />
      <div className={styles.decorativeSquare} />

      <h1 className={styles.header}>Course Name: {selectdCourseTitle ?? 'Loading...'}</h1>

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
              src={activeLesson?.videoLink}
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
