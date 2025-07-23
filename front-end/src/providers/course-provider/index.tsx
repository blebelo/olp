"use client"
import { useContext, useReducer } from "react";
import { axiosInstance } from "@/utils/axiosInstance";
import { INITIAL_STATE, ICourse, CourseActionContext, CourseStateContext, ILesson} from "./context";
import { CourseReducer } from "./reducer";
import { useRouter } from "next/navigation";
import { 
    createCoursePending,
    createCourseSuccess,
    createCourseError,
    getAllCoursesPending,
    getAllCoursesSuccess,
    getAllCoursesError,

    createLessonPending,
    createLessonSuccess,
    createLessonError,
    getCoursePending,
    getCourseSuccess,
    getCourseError
    updateCoursePending,
    updateCourseSuccess,
    updateCourseError
} from "./actions";

export const CourseProvider = ({children}: {children: React.ReactNode}) => {
    const [state, dispatch] = useReducer(CourseReducer, INITIAL_STATE);
    const instance = axiosInstance;
    const router = useRouter();

    const updateCourse = async (course: ICourse) => {
    dispatch(updateCoursePending());
    const endpoint: string = '/services/app/Course/Update';
    await instance.put(endpoint, course)
        .then(() => {
            dispatch(updateCourseSuccess());
            router.push('/instructor');
        })
        .catch((error) => {
            dispatch(updateCourseError());
            console.error(error);
        });
}

    const createCourse = async (course: ICourse) => {
        dispatch(createCoursePending());

        const endpoint:string = '/services/app/Course/Create';
        await instance.post(endpoint, course)
        .then((response) => {
            dispatch(createCourseSuccess(response.data))
            router.push('/instructor');
        }).catch((error) =>{
            dispatch(createCourseError());
            console.error(error)
        })
    }

    const getAllCourses = async() => {
        dispatch(getAllCoursesPending());

        const endpoint:string = '/services/app/Course/GetAllMinimal';
        await instance.get(endpoint)
        .then((response)=>{
            dispatch(getAllCoursesSuccess(response.data.result));
            console.log("Courses:", response.data);
        }).catch((error)=>{
            dispatch(getAllCoursesError());
            console.error(error);
        })
    }

    const createLesson = async(lesson: ILesson) => {
        dispatch(createLessonPending());

        const endpoint : string = '/services/app/Course/AddLesson';

        await instance.post(endpoint, lesson)
        .then((response) => {
            dispatch(getCourseSuccess(response.data))
            console.log(response.data)
        }).catch((error)=>{
            dispatch(getCourseError());
            console.error(error)
        })
    }

    const getCourse = async(courseId: string) => {
        dispatch(getCoursePending());

        const endpoint : string = '/services/app/Course/Get';

        await instance.post(endpoint, courseId)
        .then((response) => {
            dispatch(createLessonSuccess(response.data))
            console.log(response.data)
        }).catch((error)=>{
            dispatch(createLessonError());
            console.error(error)
        })

    }
    
    return (
        <CourseStateContext.Provider value={state}>

            <CourseActionContext.Provider value={{createCourse, getAllCourses, updateCourse, createLesson, getCourse}}>
                {children}
            </CourseActionContext.Provider>
        </CourseStateContext.Provider>
    )
}

export const useCourseState = () => {
    const context = useContext(CourseStateContext);
    if (!context) {
        throw new Error('useCourseState must be used within a CourseProvider');
    }
    return context;
}

export const useCourseActions = () => {
    const context = useContext(CourseActionContext);
    if (!context) {
        throw new Error('useCourseActions must be used within a CourseProvider');
    }
    return context;
}