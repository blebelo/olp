import { createAction } from "redux-actions";
import { ICourse, ICourseStateContext, ILesson } from "./context";
// Publish course
// Publish or unpublish course

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

    createLessonPending = "CREATE_LESSON_PENDING",
    createLessonSuccess = "CREATE_LESSON_SUCCESS",
    createLessonError = "CREATE_LESSON_ERROR",

    //GET INSTRUCTOR COURSES
    getInstructorCoursesPending = "GET_INSTRUCTOR_COURSES_PENDING",
    getInstructorCoursesSuccess = "GET_INSTRUCTOR_COURSES_SUCCESS",
    getInstructorCoursesError = "GET_INSTRUCTOR_COURSES_ERROR",

    //GET COURSE BY ID
    getCourseByIdPending = "GET_COURSE_BY_ID_PENDING",
    getCourseByIdSuccess = "GET_COURSE_BY_ID_SUCCESS",
    getCourseByIdError = "GET_COURSE_BY_ID_ERROR",
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
            courses: items,
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

//Update courses
export const updateCoursePending = createAction<ICourseStateContext>(
    CourseActionEnum.updateCoursePending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false,
        }
    )
)

export const updateCourseSuccess = createAction<ICourseStateContext>(
    CourseActionEnum.updateCourseSuccess, () => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
        }
    )
)

export const updateCourseError = createAction<ICourseStateContext>(
    CourseActionEnum.updateCourseError, () => (
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

export const createLessonPending = createAction<ICourseStateContext>(
    CourseActionEnum.createLessonPending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false,
        }
    )
)

export const createLessonSuccess = createAction<ICourseStateContext, ILesson>(
    CourseActionEnum.createLessonSuccess, (lesson: ILesson) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            lesson
        }
    )
)

export const createLessonError = createAction<ICourseStateContext>(
    CourseActionEnum.createLessonError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true,
        }
    )
)

export const getInstructorCoursesPending = createAction<ICourseStateContext>(
    CourseActionEnum.getInstructorCoursesPending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false,
        }
    )
)

export const getInstructorCoursesSuccess = createAction<ICourseStateContext, ILesson>(
    CourseActionEnum.getInstructorCoursesSuccess, (lesson: ILesson) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            lesson
        }
    )
)
export const getInstructorCoursesError = createAction<ICourseStateContext>(
    CourseActionEnum.getInstructorCoursesError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true,

        }
    )
)

//Get Course by Id
export const getCourseByIdPending = createAction<ICourseStateContext>(
    CourseActionEnum.getCourseByIdPending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false,
        }
    )
)

export const getCourseByIdSuccess = createAction<ICourseStateContext, ICourse>(
    CourseActionEnum.getCourseByIdSuccess, (course: ICourse) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            course
        }
    )
)

export const getCourseByIdError = createAction<ICourseStateContext>(
    CourseActionEnum.getCourseByIdError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true,
        }
    )
)