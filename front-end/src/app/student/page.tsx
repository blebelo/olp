'use client';
import { useEffect, useState } from "react";
import { Typography, Button, Row, Col, message } from "antd";
import { useStyles } from "./Styles/style";
import CourseCard, { CourseType } from "@/components/course-card/CourseCard";
import { useCourseActions, useCourseState } from "@/providers/course-provider";
import { ICourse } from "@/providers/course-provider/context";
import CourseModal, { Course } from "@/components/modal/course-modal/CourseModal";
import { axiosInstance } from "@/utils/axiosInstance";
import { useStudentEnrollmentActions } from "@/providers/enrollment-provider";

const HomePage = () => {
    const { styles } = useStyles();
    const { getAllCourses, getCourseById } = useCourseActions();
    const {  courses, course } = useCourseState();

    const { enrollStudentInCourse } = useStudentEnrollmentActions();

    const [isModalVisible, setIsModalVisible] = useState(false);
    //const [selectedCourse, setSelectedCourse] = useState<Course | null>(null);
    const [selectedCourseId, setSelectedCourseId] = useState<string | null>(null);
    //const [isLoadingCourse, setIsLoadingCourse] = useState(false);

    useEffect(() => {
        getAllCourses();
    }, []);

    useEffect(() => {
        if(selectedCourseId){
            getCourseById(selectedCourseId);
        }
    }, [selectedCourseId, getCourseById]);

    const currentStudentId = "student_id";
    
   const handleCourseClick = (course: { id?: string }) => {
    if (course.id) {
      setSelectedCourseId(course.id);
      setIsModalVisible(true);
    }
  };
        
    const handleCancelModal = () => {
        setIsModalVisible(false);
        setSelectedCourseId(null);
    };
    const handleEnroll = async (courseId: string) => {
        try{
           const studentId = currentStudentId;
           await enrollStudentInCourse(studentId, courseId);
           message.success("Enrolled successfully!");
        }catch (error: unknown) {
            console.error(error);
    }
    };

    const mappedCourses: CourseType[] = (courses || [])
    .filter(course => course.isPublished)
    .map((course: ICourse) => ({
        id: course.id ?? 'unknown-id',
        name: course.title ?? 'Untitled Course',
        topic: course.topic ?? 'General',
        description: course.description ?? 'No description provided.',
        thumbnail: "/images/image2.jpg",
    }));
    // Right before return statement, inside HomePage component:

const modalCourse: Course | null = course && selectedCourseId === course.id
  ? {
      id: course.id ?? '',
      title: course.title ?? '',
      topic: course.topic ?? '',
      description: course.description ?? '',
      instructorName: course.instructorId ?? 'N/A',  // or replace with actual name if you get it
      lessons: (course.lessons ?? []).map(lesson => ({
        title: lesson.title ?? 'Untitled Lesson',
      })),
    }
  : null;

    return (
        <div className={styles.heroContainer}>
            <div className={styles.decorativeCircleLarge} />
            <div className={styles.decorativeCircleSmall} />
            <div className={styles.decorativeCircleMedium} />
            <div className={styles.decorativeSquareLarge} />
            <div className={styles.decorativeSquareSmall} />
            <div className={styles.contentRow}>
                <div className={styles.textContainer}>
                    <Typography.Title className={styles.mainTitle}>
                        Explore Top Courses
                    </Typography.Title>
                    <Typography.Paragraph className={styles.subtitleText}>
                        Learn from expert instructors. Build your future today.
                    </Typography.Paragraph>
                    <Button className={styles.primaryButton}>Browse All Courses</Button>
                </div>

                <Typography.Title level={3} className={styles.sectionTitle}>
                    All Courses
                </Typography.Title>

                <Row gutter={[16, 16]}>
                    {mappedCourses.slice(0, 5).map((course) => (
                        <Col xs={24} sm={12} md={8} lg={6} key={course.id}>
                            <CourseCard course={course} onClick={handleCourseClick}/>
                        </Col>
                    ))}
                </Row>
            </div>
        <CourseModal visible={isModalVisible} course={modalCourse} onCancel={handleCancelModal} onEnroll={handleEnroll} />
        </div>

    );
};

export default HomePage;
