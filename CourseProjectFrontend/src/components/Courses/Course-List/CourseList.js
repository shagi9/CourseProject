import React, { useState, useEffect } from 'react'
import { getRequest } from '../../../helpers/axios_requests';
import { CourseCard } from '../Course-Card/CourseCard';
import { List, Avatar, Space } from 'antd';
import './CourseList.css';

export const CourseList = ({url}) => {
  const [courses, setCourses] = useState([]);
  
  useEffect(() => {
    const getCourses = async () => {
    const {status, data} = await getRequest(url);
    
    if(status === 200) {
      setCourses(data);
      console.log(data);
    }
  }
    getCourses();
}, [url]);

  return (
    <div className="container">
      {courses.map(course => <CourseCard key={course.id} {...course} />)}
    </div>
  )
}