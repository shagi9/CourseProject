import { get, post } from 'axios';
import { get as getCookies, set } from 'js-cookie';

import { api } from './url';

//  const getRefreshToken = () => {
//    const refreshToken = getCookies('refreshToken');
//    if(typeof(refreshToken) != 'undefined') {
//      const { status, data } = await postRequest('/auth/refresh-token', { token, refreshToken});
//      return {
//      }
//    }
//  }

//const { status, data } = await postRequest('/auth/refresh-token', { token, refreshToken});
    //if(status === 200){
      //set('refreshToken', token);  
      //set('token', refreshToken);

const getHeaders = async () => {
  const token = getCookies('token');
  const refreshToken = getCookies('refreshToken');
  if (typeof(token) != 'undefined' && typeof(refreshToken) != 'undefined') {
    
    return {
        headers: {
          Authorization: `Bearer ${token}`
        }
      }
    }
    return null;
  }
     

export const getRequest = async (url) => {
  const headers = getHeaders();
  try {
    return await get(api + url, !!headers && headers)
      .then(response => response)
      .catch(error => error.response);
  } catch (err) {
    console.log(err);
  }
}

export const postRequest = async (url, data) => {
  const headers = getHeaders();
  try {
    return await post(api + url, data, !!headers && headers)
      .then(response => response)
      .catch(error => error.response);
  } catch (err) {
    console.log(err);
  }
}
