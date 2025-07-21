"use client"
import { useContext, useReducer } from "react"
import { axiosInstance } from "@/utils/axiosInstance";
import { INITIAL_STATE, StudentEnrollmentActionContext, StudentEnrollmentStateContext } from "./context";
import { StudentEnrollmentReducer } from "./reducer";
import {
    enrollStudentInCoursePending,
    enrollStudentInCourseSuccess,
    enrollStudentInCourseError,
    unenrollStudentFromCoursePending,
    unenrollStudentFromCourseSuccess,
    unenrollStudentFromCourseError,
    getStudentEnrolledCoursesPending,
    getStudentEnrolledCoursesSuccess,
    getStudentEnrolledCoursesError
} from "./actions";

export const StudentEnrollmentProvider = ({children}: {children: React.ReactNode}) => {
    const [state, dispatch] = useReducer(StudentEnrollmentReducer, INITIAL_STATE);
    const instance = axiosInstance();

    const enrollStudentInCourse = async (studentId: string, courseId: string) => {
        dispatch(enrollStudentInCoursePending());

        //matching endpoints with frontend
        const endpoint: string = `/services/app/Student/EnrollStudentInCourse?studentId=${studentId}&courseId=${courseId}`;
        await instance.post(endpoint)
        .then((response) => {
            dispatch(enrollStudentInCourseSuccess());
            console.log('Student enrolled successfully', response);
        }).catch((error) => {
            dispatch(enrollStudentInCourseError());
            console.error('Enrollment failed:', error);
        })
    }
     const unenrollStudentFromCourse = async (studentId: string, courseId: string) => {
        dispatch(unenrollStudentFromCoursePending());

        const endpoint: string = `/services/app/Student/UnenrollStudentFromCourse?studentId=${studentId}&courseId=${courseId}`;
        await instance.post(endpoint)
        .then((response) => {
            dispatch(unenrollStudentFromCourseSuccess());
            console.log('Student unenrolled successfully', response);
        }).catch((error) => {
            dispatch(unenrollStudentFromCourseError());
            console.error('Unenrollment failed:', error);
        })
    }
      const getStudentEnrolledCourses = async (studentId: string) => {
        dispatch(getStudentEnrolledCoursesPending());

        const endpoint: string = `/services/app/Student/GetStudentEnrolledCourses?studentId=${studentId}`;
        await instance.get(endpoint)
        .then((response) => {
            dispatch(getStudentEnrolledCoursesSuccess(response.data.result || response.data));
        }).catch((error) => {
            dispatch(getStudentEnrolledCoursesError());
            console.error('Failed to get enrolled courses:', error);
        })
    } 
    
    return (
        <StudentEnrollmentStateContext.Provider value={state}>
            <StudentEnrollmentActionContext.Provider value={{
                enrollStudentInCourse,unenrollStudentFromCourse,getStudentEnrolledCourses
            }}>
                {children}
            </StudentEnrollmentActionContext.Provider>
        </StudentEnrollmentStateContext.Provider>
    )
}
export const useStudentEnrollmentState = () => {
    const context = useContext(StudentEnrollmentStateContext);
    if (!context) {
        throw new Error('useStudentEnrollmentState must be used within a StudentEnrollmentProvider');
    }
    return context;
}

export const useStudentEnrollmentActions = () => {
    const context = useContext(StudentEnrollmentActionContext);
    if (!context) {
        throw new Error('useStudentEnrollmentActions must be used within a StudentEnrollmentProvider');
    }
    return context;
}