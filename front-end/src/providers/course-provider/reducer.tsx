import { handleActions } from "redux-actions";
import { INITIAL_STATE, ICourseStateContext } from "./context";
import { CourseActionEnum } from "./actions";

export const CourseReducer = handleActions<ICourseStateContext, ICourseStateContext>({
    [CourseActionEnum.createCoursePending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.createCourseSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.createCourseError]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.getCoursePending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.getCourseSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.getCourseError]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.getAllCoursesPending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.getAllCoursesSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.getAllCoursesError]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.deleteCoursePending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.deleteCourseSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.deleteCourseError]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.createLessonPending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.createLessonSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.createLessonError]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [CourseActionEnum.getInstructorCoursesPending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
     [CourseActionEnum.getInstructorCoursesSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
     [CourseActionEnum.getInstructorCoursesError]: (state, action) => ({
        ...state,
        ...action.payload,
    })

}, INITIAL_STATE)