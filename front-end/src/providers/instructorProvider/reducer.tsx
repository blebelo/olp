import { handleActions } from "redux-actions";
import { INSTRUCTOR_PROFILE_INITIAL_STATE, IInstructorStateContext } from "./context";
import { InstructorActionEnums } from "./actions";

export const InstructorProfileReducer = handleActions<IInstructorStateContext, IInstructorStateContext>(
  {
    [InstructorActionEnums.getProfilePending]: (state, action) => ({
      ...state,
      ...action.payload,
    }),
    [InstructorActionEnums.getProfileSuccess]: (state, action) => ({
      ...state,
      ...action.payload,
    }),
    [InstructorActionEnums.getProfileError]: (state, action) => ({
      ...state,
      ...action.payload,
    }),
    [InstructorActionEnums.updateProfilePending]: (state, action) => ({
      ...state,
      ...action.payload,
    }),
    [InstructorActionEnums.updateProfileSuccess]: (state, action) => ({
      ...state,
      ...action.payload,
    }),
    [InstructorActionEnums.updateProfileError]: (state, action) => ({
      ...state,
      ...action.payload,
    }),
  },

  INSTRUCTOR_PROFILE_INITIAL_STATE

);