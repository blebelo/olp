'use client';
import { useState } from 'react';
import { Button, Typography, Form, Upload } from 'antd';
import { CheckCircleFilled, FileTextOutlined, UploadOutlined } from '@ant-design/icons';
import { useStyles } from './Style/style';
import { initialLessons } from '@/utils/sample-courses/lessons';
import type { FieldConfig } from "@/components/modal/ReusableModalForm";
import ReusableModalForm from '@/components/modal/ReusableModalForm';
import QuizModalForm, { QuizQuestion } from '@/components/modal/quiz-modal/QuizModalForm';
import { useParams } from 'next/navigation';
import { useCourseActions, useCourseState } from '@/providers/course-provider';
import { ILesson } from '@/providers/course-provider/context';
const { Title, Paragraph } = Typography;

const ManageCoursePage = () => {
    const { styles } = useStyles();
    const [activeLesson, setActiveLesson] = useState(initialLessons[0]);
    const {isError} = useCourseState();
    const {createLesson} = useCourseActions();
    const [isAddLesson, setIsAddLesson] = useState(false);
    const [form] = Form.useForm();
    const lessons = initialLessons;
    const [isAddQuiz, setIsAddQuiz] = useState(false);

    const params = useParams();
    const courseId = params?.course as string;
    console.log(courseId);

    const [quizQuestions, setQuizQuestions] = useState([
        {
            question: "",
            options: ["", "", "", ""],
            correctAnswer: 0,
        },
    ]);

    const handleCreateQuiz = (questions: QuizQuestion[]) => {
        console.log("Quiz submitted:", questions);
        setIsAddQuiz(false);
    }

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
            rules: [{ required: true, message: "Please enter description" }],
            type: "textarea",
        },
         {
            label: "Material",
            name: "tempMaterial",
            rules: [{ required: true, message: "Please enter description" }],
            type: "textarea",
        },
        // {
        //     label: "Video Upload",
        //     name: "video",
        //     type: "custom",
        //     component: (
        //         <Upload
        //             name="video"
        //             maxCount={1}
        //             beforeUpload={() => false}
        //         >
        //             <Button icon={<UploadOutlined />}>Upload Video</Button>
        //         </Upload>
        //     ),
        // },
        // {
        //     label: "Additional Content",
        //     name: "additionalContent",
        //     type: "custom",
        //     component: (
        //         <Upload
        //             name="documents"
        //             multiple
        //             beforeUpload={() => false}
        //         >
        //             <Button icon={<UploadOutlined />}>Upload Documents</Button>
        //         </Upload>
        //     ),
        // },
    ];

    const handleAddLesson = () => {
        form.validateFields().then((values) => {
          const newLesson: ILesson = {
                title: values.title,
                description: values.description,
                videoLink: values.tempVideo,
                studyMaterial: values.tempMaterial,
                isCompleted: false
          }
          createLesson(newLesson, courseId);
            setIsAddLesson(false);
        });
    };

    const handleCancelAdd = () => {
        form.resetFields();
        setIsAddLesson(false);
    };

    if(isError){return<>Error adding lesson</>}

    return (
        <div className={styles.pageContainer}>
            <div className={styles.decorativeCircle} />
            <div className={styles.decorativeSquare} />
            <h2 className={styles.header}>Manage Course</h2>
            <h1 className={styles.secondary}>Course Name: React Fundamentals</h1>

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

                    >
                        Publish Course
                    </Button>
                </main>
            </div>
        </div>
    );
}

export default ManageCoursePage;