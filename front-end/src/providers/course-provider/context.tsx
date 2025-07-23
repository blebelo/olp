import { createContext } from "react";

export interface ICourse {
    id?: string,
    title?: string,
    topic?: string,
    description?: string,
    isPublished?: boolean,
    instructorId?: string
}

export interface Lesson{
    name?: string,
}

export interface ICourseStateContext {
    isPending: boolean;
    isSuccess: boolean;
    isError: boolean;
    course?: ICourse;
    courses?: ICourse[];
    totalCount?: number;
   
}

export interface ICourseActionContext {
    createCourse: (course: ICourse) => void;
    getAllCourses: () => void;
    updateCourse: (course: ICourse) => void;
}

export const INITIAL_STATE: ICourseStateContext = {
    isPending: false,
    isSuccess: false,
    isError: false,
    courses: [], //just added now
}

export const CourseStateContext = createContext<ICourseStateContext>(INITIAL_STATE);
export const CourseActionContext = createContext<ICourseActionContext>(undefined!);