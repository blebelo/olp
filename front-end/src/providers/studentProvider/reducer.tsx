import { StudentActionEnums } from "./actions";
import { IStudentStateContext } from "./context";
import { Action } from "redux-actions";

export const studentProfileReducer = (
  state: IStudentStateContext,
  action: Action<IStudentStateContext>
): IStudentStateContext => {
  switch (action.type) {
    case StudentActionEnums.getProfilePending:
    case StudentActionEnums.getProfileSuccess:
    case StudentActionEnums.getProfileError:
    case StudentActionEnums.updateProfilePending:
    case StudentActionEnums.updateProfileSuccess:
    case StudentActionEnums.updateProfileError:
      return { ...state, ...action.payload };
    default:
      return state;
  }
};
