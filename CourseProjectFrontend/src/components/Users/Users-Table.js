import React, { useState, useEffect } from "react";
import { postRequest } from "../../helpers/axios_requests";

import { Table } from "antd";
import "./Users-Table.css";

export const UsersTable = () => {
  const [users, setUsers] = useState([]);
  const [pagination, setPagination] = useState({
    currentPage: 1,
    pageSize: 5
   });

  useEffect(() => {
    const getUsers = async () => {
      const { status, data } = await postRequest(
        "/User/GetAllUsersWithFullInfo",{currentPage: pagination.currentPage, pageSize: pagination.pageSize, totalCount: pagination.totalCount}
      );
      if (status === 200) {
        var i = 1;
        data.users.forEach((x) => {
          x.id = i;
          i += 1;
        });
        console.log(data);
        setUsers(data.users);
        setPagination(data.pageInfo);
      }
    };
    getUsers();
  }, []);

  const columns = [
    {
      title: "Id",
      dataIndex: "id",
      key: "id",
    },
    {
      title: "User Name",
      dataIndex: "userName",
      key: "userName",
    },
    {
      title: "Email",
      dataIndex: "email",
      key: "email",
    },
    {
      title: "Full Name",
      dataIndex: "fullName",
      key: "fullName",
    },
    {
      title: "Birth",
      dataIndex: "dateOfBirth",
      key: "dateOfBirth",
    },
    {
      title: "Registered Date",
      dataIndex: "registeredDate",
      key: "registeredDate",
    },
  ];

  return (
    <div>
      <Table
        bordered
        columns={columns}
        dataSource={users}
        pagination={pagination}
        title={() => "Users table"}
        rowKey={(record) => record.id}
      />
    </div>
  );
};