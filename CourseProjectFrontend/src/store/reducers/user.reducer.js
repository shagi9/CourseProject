import { SET_USER } from '../actions/user.actions';

const defaultState = null;

export const user = (state = defaultState, { type, payload }) => {
  switch (type) {
    case SET_USER: 
      return payload;  
    }
  return state;
}