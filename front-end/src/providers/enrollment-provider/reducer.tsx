import { handleActions } from "redux-actions";
import { INITIAL_STATE, IStudentEnrollmentStateContext } from "./context";
import { StudentEnrollmentActionEnum } from "./actions";

export const StudentEnrollmentReducer = handleActions<IStudentEnrollmentStateContext, IStudentEnrollmentStateContext>({
    //enroll student in course
    [StudentEnrollmentActionEnum.enrollStudentInCoursePending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [StudentEnrollmentActionEnum.enrollStudentInCourseSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [StudentEnrollmentActionEnum.enrollStudentInCourseError]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    // Unenroll Student From Course
    [StudentEnrollmentActionEnum.unenrollStudentFromCoursePending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [StudentEnrollmentActionEnum.unenrollStudentFromCourseSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [StudentEnrollmentActionEnum.unenrollStudentFromCourseError]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    // Get Student Enrolled Courses
     [StudentEnrollmentActionEnum.getStudentEnrolledCoursesPending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [StudentEnrollmentActionEnum.getStudentEnrolledCoursesSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [StudentEnrollmentActionEnum.getStudentEnrolledCoursesError]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
}, INITIAL_STATE)