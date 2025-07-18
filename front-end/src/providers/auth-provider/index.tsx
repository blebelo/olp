"use client"
import { useContext, useReducer } from "react";
import { axiosInstance } from "@/utils/axiosInstance";
import { INITIAL_STATE, IUser, AuthStateContext, AuthActionContext } from "./context";
import { AuthReducer } from "./reducer";

import { 
    registerInstructorPending, 
    registerInstructorSuccess, 
    registerInstructorError 
} from "./actions";

import { useRouter } from "next/navigation";

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
    const [state, dispatch] = useReducer(AuthReducer, INITIAL_STATE);
    const instance = axiosInstance();
    const router = useRouter();

    const registerInstructor = async (user: IUser) => {
        dispatch(registerInstructorPending());
        const endpoint: string = '/api/services/app/Instructor/Create';

        await instance.post(endpoint, user)
            .then((response) => {
                dispatch(registerInstructorSuccess(response.data))
                router.push('/instructor/dashboard')
            }).catch((error) => {
                dispatch(registerInstructorError())
                console.log(error)
                console.log(error.message)
            })
    }

    return (
        <AuthStateContext.Provider value={state}>
            <AuthActionContext.Provider value={{ registerInstructor}}>
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