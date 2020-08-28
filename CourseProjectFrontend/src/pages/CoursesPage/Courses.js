import React, { Component } from 'react'
import { CourseList } from '../../components/Courses/Course-List/CourseList';

import './Courses.css';

export class Courses extends Component {
render() {
  return (
    <div className="container2">
      <CourseList url="/Course/GetAllCourses"/>
    </div>
    )
  }
}

export default Courses
    