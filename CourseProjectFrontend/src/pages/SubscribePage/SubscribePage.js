import React, { useState, useEffect } from 'react';
import { useParams, Redirect } from 'react-router-dom';
import { SubscribeCard} from '../../components/Courses/SubscribeCard/SubscribeCard';
import {getRequest} from '../../helpers/axios_requests';

export const SubscribePage = () => {
  const [course, setCourse] = useState({});
  const { courseId } = useParams();

  useEffect(() => {
    const getCourseById = async () => {
        const { data } = await getRequest("/Course/GetCourseById?courseId="+courseId);
        setCourse(data);
    }
    getCourseById();
}, [courseId])
    return (
      <div>
        {course ? <SubscribeCard {...course}/> : <div></div>} 
      </div>
    )
}

