'use client';
import { useEffect, useState, useContext } from "react";
import { Typography, Row, Col, message } from "antd";
import { useStyles } from "./Styles/style";
import CourseCard, { CourseType } from "@/components/course-card/CourseCard";
import { useCourseActions, useCourseState } from "@/providers/course-provider";
import { ICourse } from "@/providers/course-provider/context";
import CourseModal, { Course } from "@/components/modal/course-modal/CourseModal";
import { StudentProfileActionContext, StudentProfileStateContext } from "@/providers/studentProvider/context";
import { useStudentEnrollmentActions, useStudentEnrollmentState } from "@/providers/enrollment-provider";
import { useRouter } from "next/navigation";

const HomePage = () => {
    const { styles } = useStyles();
    const { getAllCourses, getCourse } = useCourseActions();
    const { courses, course } = useCourseState();
    const {getProfile} = useContext(StudentProfileActionContext)|| {};
    const { enrollStudentInCourse, getStudentEnrolledCourses } = useStudentEnrollmentActions();
    const {profile} = useContext(StudentProfileStateContext);
    const {enrolledCourses} = useStudentEnrollmentState();
    const router = useRouter();
    const studentId = sessionStorage.getItem("userId") ?? '';
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [selectedCourse, setSelectedCourse] = useState<Course | null>(null);

    useEffect(() => {
        getAllCourses();
    }, []);

    useEffect(() => {
        getProfile?.();
        if (profile?.id) sessionStorage.setItem('userId', profile.id);
    }, []);

  useEffect(() => {
        const storedId = sessionStorage.getItem("Id");
        if (storedId !== null) {
            const numericId = parseInt(storedId, 10);
            if (!isNaN(numericId)) {
                getStudentEnrolledCourses(numericId);
            }
        }
    }, []);

  const handleCourseClick = (course: CourseType) => {

    const isEnrolled = enrolledCourses?.some((enrolled) => enrolled.id === course.id);
    if(isEnrolled){
        router.push(`/student/enrolled-course/${course.id}`); 

        return;
    }
        setSelectedCourse({
            id: course.id,
            title: course.name,
            topic: course.topic,
            description: course.description,
            instructorName: "N/A",
            lessons: [], 
        });
        getCourse(course.id);
        setIsModalVisible(true);
        };
        
    const handleCancelModal = () => {
        setIsModalVisible(false);
        setSelectedCourse(null);
    };
    
    const handleEnroll = (courseId: string) => {
            console.log("courseId front: ", courseId);
            console.log("StudentId front: ", studentId);
           enrollStudentInCourse(studentId, course?.id);
           message.success("Enrolled successfully!");
    };


    const mappedCourses: CourseType[] = (courses || [])
        .filter((course: ICourse) => course.isPublished)
        .map((course: ICourse) => ({
            id: course.id ?? 'unknown-id',
            name: course.title ?? 'Untitled Course',
            topic: course.topic ?? 'General',
            description: course.description ?? 'No description provided.',
            thumbnail: "/images/image2.jpg",
        }));

const modalCourse: Course | null = course && selectedCourse?.id === course.id
  ? {
      id: course.id ?? '',
      title: course.title ?? '',
      topic: course.topic ?? '',
      description: course.description ?? '',
      instructorName: course.instructorId ?? 'N/A', 
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
                </div>

                {/* only displays enrolled courses */}

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
