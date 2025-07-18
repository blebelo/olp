import {createAction} from 'redux-actions';
import { IUser, IAuthStateContext } from './context';

export enum AuthActionEnums {
    //Register Instructor
    registerInstructorPending = "REGISTER_INSTRUCTOR_PENDING",
    registerInstructorSuccess = "REGISTER_INSTRUCTOR_SUCCESS",
    registerInstructorError = "REGISTER_INSTRUCTOR_ERROR",

    //Login
    
    loginUserPending = "User_PENDING",
    loginUserSuccess = "LOGIN_TRAINER_SUCCESS",
    loginUserError = "LOGIN_TRAINER_ERROR",

    //Register Student
    registerStudentPending = "REGISTER_STUDENT_PENDING",
    registerStudentSuccess = "REGISTER_STUDENT_SUCCESS",
    registerStudentError = "REGISTER_STUDENT_ERROR",


}

export const registerInstructorPending = createAction<IAuthStateContext>(
    AuthActionEnums.registerInstructorPending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false
        }
    )
)

export const registerInstructorSuccess = createAction<IAuthStateContext, IUser>(
    AuthActionEnums.registerInstructorSuccess, (user: IUser) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            user
        }
    )
)

export const registerInstructorError = createAction<IAuthStateContext>(
    AuthActionEnums.registerInstructorError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true
        }
    )
)

export const loginUserPending = createAction<IAuthStateContext>(
    AuthActionEnums.loginUserPending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false
        }
    )
)

export const loginUserSuccess = createAction<IAuthStateContext, IUser>(
    AuthActionEnums.loginUserSuccess, (user: IUser) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            user
        }
    )
)

export const loginUserError = createAction<IAuthStateContext>(
    AuthActionEnums.loginUserError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true
        }
    )
)

export const registerStudentPending = createAction<IAuthStateContext>(
    AuthActionEnums.registerStudentPending, () => (
        {
            isPending: true,
            isSuccess: false,
            isError: false
        }
    )
)

export const registerStudentSuccess = createAction<IAuthStateContext, IUser>(
    AuthActionEnums.registerStudentSuccess, (user: IUser) => (
        {
            isPending: false,
            isSuccess: true,
            isError: false,
            user
        }
    )
)

export const registerStudentError = createAction<IAuthStateContext>(
    AuthActionEnums.registerStudentError, () => (
        {
            isPending: false,
            isSuccess: false,
            isError: true
        }
    )
)