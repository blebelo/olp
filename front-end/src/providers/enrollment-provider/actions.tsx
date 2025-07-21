import { createAction } from "redux-actions";
import { ICourseDtos, IStudentEnrollmentStateContext } from "./context";

export enum StudentEnrollmentActionEnum {
    //Enroll student
    enrollStudentInCoursePending = "ENROLL_STUDENT_IN_COURSE_PENDING",
    enrollStudentInCourseSuccess = "ENROLL_STUDENT_IN_COURSE_SUCCESS",
    enrollStudentInCourseError = "ENROLL_STUDENT_IN_COURSE_ERROR",

    //Unenroll student
    unenrollStudentFromCoursePending = "UNENROLL_STUDENT_FROM_COURSE_PENDING",
    unenrollStudentFromCourseSuccess = "UNENROLL_STUDENT_FROM_COURSE_SUCCESS",
    unenrollStudentFromCourseError = "UNENROLL_STUDENT_FROM_COURSE_ERROR",
    
    //Get Enrolled Courses
    getStudentEnrolledCoursesPending = "GET_STUDENT_ENROLLED_COURSES_PENDING",
    getStudentEnrolledCoursesSuccess = "GET_STUDENT_ENROLLED_COURSES_SUCCESS",
    getStudentEnrolledCoursesError = "GET_STUDENT_ENROLLED_COURSES_ERROR",
}
export const enrollStudentInCoursePending = createAction<IStudentEnrollmentStateContext>(
    StudentEnrollmentActionEnum.enrollStudentInCoursePending, () => ({
        isPending: true,
        isSuccess: false,
        isError: false
    })
)
export const enrollStudentInCourseSuccess = createAction<IStudentEnrollmentStateContext>(
    StudentEnrollmentActionEnum.enrollStudentInCourseSuccess, () => ({
        isPending: false,
        isSuccess: true,
        isError: false
    })
)

export const enrollStudentInCourseError = createAction<IStudentEnrollmentStateContext>(
    StudentEnrollmentActionEnum.enrollStudentInCourseError, () => ({
        isPending: false,
        isSuccess: false,
        isError: true,
    })
)

//unenroll student actions
export const unenrollStudentFromCoursePending = createAction<IStudentEnrollmentStateContext>(
    StudentEnrollmentActionEnum.unenrollStudentFromCoursePending, () => ({
        isPending: true,
        isSuccess: false,
        isError: false
    })
)

export const unenrollStudentFromCourseSuccess = createAction<IStudentEnrollmentStateContext>(
    StudentEnrollmentActionEnum.unenrollStudentFromCourseSuccess, () => ({
        isPending: false,
        isSuccess: true,
        isError: false
    })
)

export const unenrollStudentFromCourseError = createAction<IStudentEnrollmentStateContext>(
    StudentEnrollmentActionEnum.unenrollStudentFromCourseError, () => ({
        isPending: false,
        isSuccess: false,
        isError: true,
    })
)
// Get Enrolled Courses Actions
export const getStudentEnrolledCoursesPending = createAction<IStudentEnrollmentStateContext>(
    StudentEnrollmentActionEnum.getStudentEnrolledCoursesPending, () => ({
        isPending: true,
        isSuccess: false,
        isError: false
    })
)

export const getStudentEnrolledCoursesSuccess = createAction<IStudentEnrollmentStateContext, ICourseDtos[]>(
    StudentEnrollmentActionEnum.getStudentEnrolledCoursesSuccess, (enrolledCourses: ICourseDtos[]) => ({
        isPending: false,
        isSuccess: true,
        isError: false,
        enrolledCourses
    })
)
export const getStudentEnrolledCoursesError = createAction<IStudentEnrollmentStateContext>(
    StudentEnrollmentActionEnum.getStudentEnrolledCoursesError, () => ({
        isPending: false,
        isSuccess: false,
        isError: true,
    })
)