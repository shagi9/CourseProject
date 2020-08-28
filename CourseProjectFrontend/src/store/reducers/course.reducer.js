import { SET_COURSES } from '../actions/courses.actions';

const defaultState = null;

export const courses = (state = defaultState, { type, payload }) => {
  switch(type) {
    case SET_COURSES:
      return payload;
  }
  return state;
}