export const SET_COURSES = 'SET_COURSES';

export const getCourses = course => ({
  type: SET_COURSES,
  payload: course
});