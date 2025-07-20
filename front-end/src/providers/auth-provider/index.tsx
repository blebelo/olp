"use client"
import { useContext, useReducer } from "react";
import { axiosInstance } from "@/utils/axiosInstance";
import { INITIAL_STATE, IUser, AuthStateContext, AuthActionContext } from "./context";
import { AuthReducer } from "./reducer";
import { AbpTokenProperies, decodeToken } from "@/utils/jwt";
import { useRouter } from "next/navigation";
import {
    registerInstructorPending,
    registerInstructorSuccess,
    registerInstructorError,
    loginUserPending,
    loginUserSuccess,
    loginUserError,
    registerStudentPending,
    registerStudentSuccess,
    registerStudentError
} from "./actions";

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
    const [state, dispatch] = useReducer(AuthReducer, INITIAL_STATE);
    const instance = axiosInstance;
    const router = useRouter();

    const registerInstructor = async (user: IUser) => {
        dispatch(registerInstructorPending());
        const endpoint: string = '/services/app/Instructor/Create';

        await instance.post(endpoint, user)
            .then((response) => {
                dispatch(registerInstructorSuccess(response.data))
                router.push('/instructor/dashboard')
            }).catch((error) => {
                dispatch(registerInstructorError())
            })
    }

    const registerStudent = async (user: IUser) => {
        dispatch(registerStudentPending());
        const endpoint: string = '/services/app/Student/Create';

        await instance.post(endpoint, user)
            .then((response) => {
                dispatch(registerStudentSuccess(response.data))
                router.push('/instructor/dashboard')
            }).catch((error) => {
                dispatch(registerStudentError())
                console.error(error)
            })
    }

    const loginUser = async (user: IUser) => {
        dispatch(loginUserPending());
        const endpoint = `/TokenAuth/Authenticate`;

        await instance
            .post(endpoint, user)
            .then((response) => {
                const token = response.data.result.accessToken;

                const decoded = decodeToken(token);
                const userRole = decoded[AbpTokenProperies.role];

                sessionStorage.setItem("token", token);
                sessionStorage.setItem("role", userRole);

                dispatch(loginUserSuccess(token));
                router.push('/instructor/dashboard');
            })
            .catch((error) => {
                console.error(error)
                dispatch(loginUserError());
            });
    }

    return (
        <AuthStateContext.Provider value={state}>
            <AuthActionContext.Provider value={{ registerInstructor, loginUser, registerStudent }}>
                {children}
            </AuthActionContext.Provider>
        </AuthStateContext.Provider>
    )
}

export const useAuthState = () => {
    const context = useContext(AuthStateContext);
    if (!context) {
        throw new Error('useAuthState must be used within a AuthProvider');
    }
    return context;
}

export const useAuthActions = () => {
    const context = useContext(AuthActionContext);
    if (!context) {
        throw new Error('useAuthActions must be used within a AuthProvider')
    }
    return context;
}