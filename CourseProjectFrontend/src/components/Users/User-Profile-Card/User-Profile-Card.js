import React, { useState, useEffect } from 'react'
import { getRequest } from '../../../helpers/axios_requests';
import "./User-Profile-Card.scss";
import { Table } from "antd";

export const UserProfileCard = () => {
  const [user, setUser] = useState({});
  const [courses, setCourses] = useState([{}]);
  
  const columns = [
    {
      title: "Course Name",
      dataIndex: "name"
    },
    {
      title: "Start Date",
      dataIndex: "startDate",
    },
    {
      title: "End Date",
      dataIndex: "endDate"
    }
  ];

  useEffect(() => {
    const fetchUser = async () => {
      const { status, data } = await getRequest(
        "/User/GetUserWithFullInfo"
      );

      if (status === 200) {
        console.log(data);
        setUser(data);
      }
    };

    const fetchCourses = async () => {
      console.log("userId " + user.id);
      const { status, data } = await getRequest(
        `/Course/GetCoursesByUserId?userId=${user.id}`
      );

      if (status === 200){
        console.log(data);
        setCourses(data);
      }
    };
    fetchUser();
    fetchCourses();
  }, [user.id]);

  return (
      <div className="profile">
        <div>
        <img
          src="https://p7.hiclipart.com/preview/355/848/997/computer-icons-user-profile-google-account-photos-icon-account.jpg"
          alt="user-logo"
          className="user-logo"
        />
        <div>
          <h2>{user.fullName}</h2>
          <h3>{user.nickName}</h3>
          <h3>Email: {user.email}</h3>
          <h3>Date of birth: {user.dateOfBirth}</h3>
        </div>
        <h3>Registration date: {user.registrationDate}</h3>
        </div>
      <Table
        dataSource={courses}
        columns={columns}
        pagination={false}
        bordered={true}
        className="course-table"
      />
      </div>
  );
};

