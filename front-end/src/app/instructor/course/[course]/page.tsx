'use client';
import { useState, useEffect } from 'react';
import { Button, Typography, Form, Spin } from 'antd';
import { CheckCircleFilled, FileTextOutlined } from '@ant-design/icons';
import { useStyles } from './Style/style';
import type { FieldConfig } from "@/components/modal/ReusableModalForm";
import ReusableModalForm from '@/components/modal/ReusableModalForm';
import QuizModalForm, { QuizQuestion } from '@/components/modal/quiz-modal/QuizModalForm';
import { useParams } from 'next/navigation';
import { useCourseActions, useCourseState } from '@/providers/course-provider';
import { ILesson } from '@/providers/course-provider/context';

const { Title, Paragraph } = Typography;

const ManageCoursePage = () => {
    const { styles } = useStyles();
    const { isError, course, isPending } = useCourseState();
    const { getCourse, createLesson, setCoursePublished } = useCourseActions();
    const [isAddLesson, setIsAddLesson] = useState(false);
    const [form] = Form.useForm();
    const [isAddQuiz, setIsAddQuiz] = useState(false);
    const [activeLesson, setActiveLesson] = useState<ILesson | null>(null);
    const [quizQuestions, setQuizQuestions] = useState<QuizQuestion[]>([
        {
            question: "",
            options: ["", "", "", ""],
            correctAnswer: 0,
        },
    ]);

    const params = useParams();
    const courseId = params?.course as string;

    // Dummy data for testing
    const dummyCourses = [
        {
            id: 'dummy-1',
            title: 'React Basics',
            isPublished: true,
            lessons: [
                { id: 'l1', title: 'Intro', description: 'React intro', videoLink: '', studyMaterial: [], isCompleted: true },
                { id: 'l2', title: 'JSX', description: 'JSX lesson', videoLink: '', studyMaterial: [], isCompleted: false }
            ]
        },
        {
            id: 'dummy-2',
            title: 'Node Fundamentals',
            isPublished: false,
            lessons: [
                { id: 'l3', title: 'Setup', description: 'Node setup', videoLink: '', studyMaterial: [], isCompleted: false }
            ]
        },
        {
            id: 'dummy-3',
            title: 'CSS Mastery',
            isPublished: true,
            lessons: [
                { id: 'l4', title: 'Selectors', description: 'CSS selectors', videoLink: '', studyMaterial: [], isCompleted: true }
            ]
        }
    ];

    useEffect(() => {
        if (courseId) {
            getCourse(courseId);
        }
    }, [courseId]);

    useEffect(() => {
        if (course?.lessons?.length) {
            setActiveLesson(course.lessons[0]);
        }
    }, [course]);

    const handleCreateQuiz = (questions: QuizQuestion[]) => {
        console.log("Quiz submitted:", questions);
        setIsAddQuiz(false);
    };

    const handleAddLesson = () => {
        form.validateFields().then((values) => {
            const newLesson: ILesson = {
                title: values.lessonName,
                description: values.description,
                videoLink: values.tempVideo,
                studyMaterial: values.tempMaterial,
                isCompleted: false
            };
            createLesson(newLesson, courseId);
            setIsAddLesson(false);
        });
    };

    const handleCancelAdd = () => {
        form.resetFields();
        setIsAddLesson(false);
    };

    const lessonFields: FieldConfig[] = [
        {
            label: "Lesson Name",
            name: "lessonName",
            rules: [{ required: true, message: "Please enter lesson name" }],
            type: "input",
        },
        {
            label: "Description",
            name: "description",
            rules: [{ required: true, message: "Please enter description" }],
            type: "textarea",
        },
        {
            label: "Video",
            name: "tempVideo",
            rules: [{ required: true, message: "Please enter video link" }],
            type: "textarea",
        },
        {
            label: "Material",
            name: "tempMaterial",
            rules: [{ required: true, message: "Please enter material" }],
            type: "textarea",
        },
    ];

    if (isPending || !course) {
        // For testing
        if (!course) {
            return (
                <div className={styles.pageContainer}>
                    <h2 className={styles.header}>Manage Courses (Dummy Data)</h2>
                    {dummyCourses.map((c) => (
                        <div key={c.id} style={{ marginBottom: '2rem', border: '1px solid #eee', padding: '1rem', borderRadius: '8px' }}>
                            <h1 className={styles.secondary}>Course Name: {c.title}</h1>
                            <div>
                                <Button type="primary" onClick={async () => {
                                    await setCoursePublished(c.id, !c.isPublished);
                                    c.isPublished = !c.isPublished;
                                    alert(`Course is now ${c.isPublished ? 'published' : 'unpublished'}`);
                                }}>
                                    {c.isPublished ? 'Unpublish' : 'Publish'}
                                </Button>
                            </div>
                            <div style={{ marginTop: '1rem' }}>
                                <strong>Lessons:</strong>
                                <ul>
                                    {c.lessons.map(lesson => (
                                        <li key={lesson.id}>{lesson.title} - {lesson.description}</li>
                                    ))}
                                </ul>
                            </div>
                        </div>
                    ))}
                </div>
            );
        }
        return <Spin fullscreen />;
    }

    if (isError) {
        return <>Error fetching course</>;
    }

    return (
        <div className={styles.pageContainer}>
            <div className={styles.decorativeCircle} />
            <div className={styles.decorativeSquare} />
            <h2 className={styles.header}>Manage Course</h2>
            <h1 className={styles.secondary}>Course Name: {course.title}</h1>

            <div className={styles.content}>
                <aside className={styles.sidebar}>
                    <div>
                        {course.lessons?.map((lesson) => (
                            <Button
                                key={lesson.id}
                                type="primary"
                                className={`${styles.lessonItem} ${activeLesson?.id === lesson.id ? styles.activeLesson : ''}`}
                                onClick={() => setActiveLesson(lesson)}
                            >
                                <span>{lesson.title}</span>
                                {lesson.isCompleted && <CheckCircleFilled className={styles.completedIcon} />}
                            </Button>
                        ))}
                    </div>

                    <Button className={styles.quizButton} onClick={() => setIsAddLesson(true)}>Add Lesson</Button>

                    <ReusableModalForm
                        title="Add Lesson"
                        isVisible={isAddLesson}
                        onCancel={handleCancelAdd}
                        onSubmit={handleAddLesson}
                        fields={lessonFields}
                        form={form}
                    />
                </aside>

                <main className={styles.mainContent}>
                    {activeLesson ? (
                        <>
                            <Title level={3} className={styles.lessonTitle}>
                                {activeLesson.title}
                            </Title>
                            <Paragraph className={styles.lessonDescription}>
                                {activeLesson.description}
                            </Paragraph>

                            <div className={styles.videoWrapper}>
                                <iframe
                                    src={activeLesson.videoLink || ""}
                                    style={{ border: 'none' }}
                                    allow="autoplay; encrypted-media"
                                    allowFullScreen
                                    title="video"
                                />
                            </div>

                            <div className={styles.materialWrapper}>
                                <strong>Materials:</strong>
                                <div className={styles.materialLink}>
                                    {Array.isArray(activeLesson.studyMaterial)
                                        ? activeLesson.studyMaterial.map((material, i) => (
                                            <a key={i} href={material} target="_blank" rel="noopener noreferrer" className={styles.materialLink}>
                                                <FileTextOutlined /> {material}
                                            </a>
                                        ))
                                        : <span>No materials</span>
                                    }
                                </div>
                            </div>
                        </>
                    ) : (
                        <Paragraph>No lesson selected</Paragraph>
                    )}

                    <Button
                        type="primary"
                        className={styles.completeButton}
                    >
                        Edit Lesson
                    </Button>
                    <Button
                        type="primary"
                        className={styles.completeButton}
                        onClick={() => setIsAddQuiz(true)}
                    >
                        Add Quiz
                    </Button>

                    <QuizModalForm
                        visible={isAddQuiz}
                        onCancel={() => setIsAddQuiz(false)}
                        onSubmit={handleCreateQuiz}
                        questions={quizQuestions}
                        setQuestions={setQuizQuestions}
                    />

                    <Button
                        type="primary"
                        className={styles.completeButton}
                        onClick={async () => {
                            await setCoursePublished(courseId, !course.isPublished);
                            getCourse(courseId); // refetch course to update state
                        }}
                    >
                        {course.isPublished ? 'Unpublish' : 'Publish'}
                    </Button>
                </main>
            </div>
        </div>
    );
};

export default ManageCoursePage;
