import { createContext } from "react";

export interface IStudentEnrollment{
    studentId?: string;
    courseId?: string;
}
export interface ICourseDtos{
    id?: string;
    title?: string;
    topic?: string;
    description?: string;
    isPublished?: boolean;
    instructor?: string;
}
export interface IStudentEnrollmentStateContext {
    isPending: boolean;
    isSuccess: boolean;
    isError: boolean;
    enrolledCourses?: ICourseDtos[];
}
export interface IStudentEnrollmentActionContext{
    enrollStudentInCourse: (studentId: string, courseId: string) => void;
    unenrollStudentFromCourse: (studentId: string, courseId: string) => void;
    getStudentEnrolledCourses: (studentId: string) => void;
}
export const INITIAL_STATE: IStudentEnrollmentStateContext = {
    isPending: false,
    isSuccess: false,
    isError: false,
    enrolledCourses: []
}
export const StudentEnrollmentStateContext = createContext<IStudentEnrollmentStateContext>(INITIAL_STATE);
export const StudentEnrollmentActionContext = createContext<IStudentEnrollmentActionContext>(undefined!);