import {createAction} from 'redux-actions';
import { IUser, IAuthStateContext } from './context';

export enum AuthActionEnums {
    registerInstructorPending = "REGISTER_INSTRUCTOR_PENDING",
    registerInstructorSuccess = "REGISTER_INSTRUCTOR_SUCCESS",
    registerInstructorError = "REGISTER_INSTRUCTOR_ERROR",
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