import { handleActions } from "redux-actions";
import { INITIAL_STATE, IAuthStateContext } from "./context";
import { AuthActionEnums } from "./actions";

export const AuthReducer = handleActions<IAuthStateContext, IAuthStateContext>({
    [AuthActionEnums.registerInstructorPending]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [AuthActionEnums.registerInstructorSuccess]: (state, action) => ({
        ...state,
        ...action.payload,
    }),
    [AuthActionEnums.registerInstructorError]: (state, action) => ({
        ...state,
        ...action.payload,
    })
}, INITIAL_STATE)