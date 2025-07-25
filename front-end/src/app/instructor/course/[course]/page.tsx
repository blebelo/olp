'use client';
import { useState, useEffect } from 'react';
import { Button, Typography, Form, Spin, message } from 'antd';
import { CheckCircleFilled, FileTextOutlined } from '@ant-design/icons';
import { useStyles } from './Style/style';
import type { FieldConfig } from "@/components/modal/ReusableModalForm";
import ReusableModalForm from '@/components/modal/ReusableModalForm';
import QuizModalForm, { QuizQuestion } from '@/components/modal/quiz-modal/QuizModalForm';
import { useParams } from 'next/navigation';
import { useCourseActions, useCourseState } from '@/providers/course-provider';
import { ICourse, ILesson } from '@/providers/course-provider/context';
import EditCourseModal from '@/components/modal/course-modal/EditCourseModal';

const { Title, Paragraph } = Typography;

const ManageCoursePage = () => {
    const [saving, setSaving] = useState(false);
    const { styles } = useStyles();
    const { isError, course, isPending } = useCourseState();
    const { getCourse, createLesson, setCoursePublished, getCourseById, updateCourse } = useCourseActions();
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

    const [isEditModalVisible, setIsEditModalVisible] = useState(false);

    useEffect(() => {
        if (courseId) {
            getCourse(courseId);
        }
    }, [courseId, getCourse]);

    useEffect(() => {
        if (courseId) {
            getCourseById(courseId);
        }
    }, [courseId, getCourseById]);

    useEffect(() => {
        if (course?.lessons?.length) {
            setActiveLesson(course.lessons[0]);
        }
    }, [course]);

    const handleSaveChanges = async (updatedCourse: ICourse) => {
    try {
      await updateCourse({ ...updatedCourse, id: courseId });
      message.success('Course updated successfully');
      setIsEditModalVisible(false);
      getCourseById(courseId); // Refresh UI
    } catch (error) {
        console.error(error);
      message.error('Failed to update course');
    }
  };

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
        if (!course) {
            return <Spin fullscreen />;
        }
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
                        {course.lessons?.map((lesson: ILesson) => (
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
                                <strong>Github Links:</strong>
                                <div className={styles.materialLink}>
                                    {Array.isArray(activeLesson.studyMaterial)
                                        ? activeLesson.studyMaterial.map((material) => (
                                            <a key={material} href={material} target="_blank" rel="noopener noreferrer" className={styles.materialLink}>
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
                        loading={saving}
                        onClick={async () => {
                            setSaving(true);
                            try {
                                await setCoursePublished(courseId, !course.isPublished);
                                await getCourseById(courseId); // refetch course to update state
                                message.success(`Course ${!course.isPublished ? 'published' : 'unpublished'} successfully.`);
                            } catch (error) {
                                console.error(error);
                                message.error('Failed to update course publish status.');
                            } finally {
                                setSaving(false);
                            }
                        }}
                    >
                        {course.isPublished ? 'Unpublish' : 'Publish'}
                    </Button>
                     <Button type="primary" className={styles.completeButton} onClick={() => setIsEditModalVisible(true)} style={{ marginTop: 20 }}>
                        Edit Course
                    </Button>

                    <EditCourseModal
                        visible={isEditModalVisible}
                        course={course}
                        onCancel={() => setIsEditModalVisible(false)}
                        onSubmit={handleSaveChanges}
                    />
                </main>
            </div>
        </div>
    );
};

export default ManageCoursePage;
