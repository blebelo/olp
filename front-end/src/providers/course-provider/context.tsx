import { createContext } from "react";

export interface ICourse {
    id?: string,
    title?: string,
    topic?: string,
    description?: string,
    isPublished?: boolean,
    instructorId?: string,
    lessons?: ILesson[]
}

export interface ILesson{
    title?: string,
    description?: string,
    videoLink?: string,
    isCompleted?: boolean,
    studyMaterial?: string[]
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

    createLesson: (lesson: ILesson) => void;
    // getInstructorCourses: () => void;
    getCourse: (id: string) => void;
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