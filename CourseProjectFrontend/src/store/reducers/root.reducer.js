import { combineReducers } from "redux";
import { user } from './user.reducer';
import { courses } from './course.reducer';

export const root = combineReducers({
    user, 
    courses
});