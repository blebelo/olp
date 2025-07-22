import { createAction } from "redux-actions";
import { ICourse, ICourseStateContext } from "./context";

export enum CourseActionEnum {
    //Create Course
    createCoursePending = "CREATE_COURSE_PENDING",
    createCourseSuccess = "CREATE_COURSE_SUCCESS",
    createCourseError = "CREATE_COURSE_COURSE",

    //Get Course
    getCoursePending = "GET_COURSE_PENDING",
    getCourseSuccess = "GET_COURSE_SUCCESS",
    getCourseError = "GET_COURSE_ERROR",

    //Get All Courses
    getAllCoursesPending = "GET_ALL_COURSES_PENDING",
    getAllCoursesSuccess = "GET_ALL_COURSES_SUCCESS",
    getAllCoursesError = "GET_ALL_COURSES_ERROR",

    //Update Course
    updateCoursePending = "UPDATE_COURSE_PENDING",
    updateCourseSuccess = "UPDATE_COURSE_SUCCESS",
    updateCourseError = "UPDATE_COURSE_ERROR",

    //Delete course
    deleteCoursePending = "DELETE_COURSE_PENDING",
    deleteCourseSuccess = "DELETE_COURSE-SUCCESS",
    deleteCourseError = "DELETE_COURSE_ERROR",
}


//Create Course
export const createCoursePending = createAction<ICourseStateContext>(
    CourseActionEnum.createCoursePending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false
        }
    )
)

export const createCourseSuccess = createAction<ICourseStateContext, ICourse>(
    CourseActionEnum.createCourseSuccess, (course: ICourse) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            course
        }
    )
)

export const createCourseError = createAction<ICourseStateContext>(
    CourseActionEnum.createCourseError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true,
        }
    )
)

//Get Course
export const getCoursePending = createAction<ICourseStateContext>(
    CourseActionEnum.getCoursePending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false,
        }
    )
)

export const getCourseSuccess = createAction<ICourseStateContext, ICourse>(
    CourseActionEnum.getCourseSuccess, (course: ICourse) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            course
        }
    )
)

export const getCourseError = createAction<ICourseStateContext>(
    CourseActionEnum.getCourseError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true,
        }
    )
)

//Get All Courses
export const getAllCoursesPending = createAction<ICourseStateContext>(
    CourseActionEnum.getAllCoursesPending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false,
        }
    )
)

export const getAllCoursesSuccess = createAction<ICourseStateContext, { items: ICourse[]; totalCount: number }>(
    CourseActionEnum.getAllCoursesSuccess, ({ items, totalCount }) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            courses:items,
            totalCount
        }
    )
)

export const getAllCoursesError = createAction<ICourseStateContext>(
    CourseActionEnum.getAllCoursesError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true,
        }
    )
)

//Delete Course

export const deleteCoursePending = createAction<ICourseStateContext>(
    CourseActionEnum.deleteCoursePending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false,
        }
    )
)

export const deleteCourseSuccess = createAction<ICourseStateContext, ICourse>(
    CourseActionEnum.deleteCourseSuccess, (course: ICourse) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            course
        }
    )
)


export const deleteCourseError = createAction<ICourseStateContext>(
    CourseActionEnum.deleteCourseError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true,
        }
    )
)