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

export interface IQuiz {
  name: string;
  description: string;
  duration: string;
  passingScore: number;
  courseId: string;
  questions: string[];
  answerOptions: {
    correctIndex: number;
    possibleAnswers: string[];
  }[];
}

export interface ILesson{
    id?: string,
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
    createLesson: (lesson: ILesson, courseId:string) => void;
    getCourse: (id: string) => void;
    updateCourse: (course: ICourse) => void;
    setCoursePublished: (courseId: string, isPublished: boolean) => Promise<unknown>;
    getCourseById: (courseId: string) => void;
    createQuiz: (quiz: IQuiz, courseId: string) => void
}

export const INITIAL_STATE: ICourseStateContext = {
    isPending: false,
    isSuccess: false,
    isError: false,
}

export const CourseStateContext = createContext<ICourseStateContext>(INITIAL_STATE);
export const CourseActionContext = createContext<ICourseActionContext>(undefined!);