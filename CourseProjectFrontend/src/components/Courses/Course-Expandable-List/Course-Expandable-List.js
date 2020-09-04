import React, {useEffect, useState } from 'react'
import { getRequest } from '../../../helpers/axios_requests';
import { Table } from "antd";

export const CourseExpandableList = ({email}) => {
  const [courses, setCourses] = useState([{}]);

useEffect(() => {
  const fetchCourses = async () =>{
  const { status, data } = await getRequest(`/Course/GetCoursesByStudentEmail?email=${email}`);
  console.log(data);
  if(status === 200){
    var i = 1;
    data.forEach(x => {
      x.id = i;
      i+=1;
    });
    setCourses(data);
    }
}
  if(email){
    fetchCourses();
  }
}, [email]);

const columns = [
  {
    title: "Id",
    dataIndex: "id",
    key: "id"
  },
  {
    title: "Course Name",
    dataIndex: "name",
    key: "name"
  },
  {
    title: "Start Date",
    dataIndex: "startDate",
    key: "startDate"
  },
  {
    title: "End Date",
    dataIndex: "endDate",
    key: "endDate"
  }
];

  return (
    <div>
      <Table
        columns={columns}
        pagination={false}
        dataSource={courses}
        rowKey={record => record.id}
      />
    </div>
  )
}