import React, { useState, useEffect } from "react";
import { postRequest } from "../../helpers/axios_requests";
import "./Users-Table.css";

import { CourseExpandableList } from "../Courses/Course-Expandable-List/Course-Expandable-List";
import { Form, Input, Table, Button } from "antd";

const formLoyaut = "inline";

export const UsersTable = () => {
  const [users, setUsers] = useState([]);
  const [lastSearchData, setLastSearchData] = useState('');
  const [pagination, setPagination] = useState({
    current: 1,
    pageSize: 2
   });

   const [sorter, setSorter] = useState({order:"",field:""});

   const [form] = Form.useForm();

   const sortTable = async (pagination, filters, sorter) => {
     setSorter(sorter);
     
     console.log(sorter);
     console.log(sorter.order);
     console.log(sorter.field);

     const { order, field } = sorter;
     const { current, pageSize} = pagination;

     const { data } = await postRequest(`/User/GetSortedUsers`, { searchString: lastSearchData, order: order ? order : "", field, pageSize, current});
     setUsers(data.users);
     setPagination(data.pageInfo);
   };

   const clearValue = async () => {
    form.resetFields();
    setSorter({order: null, field: null, columnKey: null});
    const { pageSize } = pagination;
    const { data } = await postRequest(`/User/GetSortedUsers`, {searchString: '', order:'ascend', field: 'id', pageSize, current: 0});
    
    setUsers(data.users);
    setPagination(data.pageInfo);
    setLastSearchData('');
  };

   const onFinish = async (values) => {
    const { current, pageSize } = pagination;
    const { order, field } = sorter;
    console.log("find");
    console.log({searchString: values.searchData, order:sorter.order, field:sorter.field, pageSize, current});
    if (values.searchData) {
      setLastSearchData(values.searchData);
      
      console.log(current);
      console.log(pageSize);

      const { status, data } = await postRequest(
        `/User/GetSortedUsers`,{searchString: values.searchData, order: order ? order : "", field, pageSize, current:1 });  

      if (status === 200) {
        console.log(data);
        setUsers(data.users);
        setPagination(data.pageInfo);
      }
    }
  };

  useEffect(() => {
    const getUsers = async () => {
      const { status, data } = await postRequest(
        "/User/GetAllUsersWithFullInfo",{current: pagination.current, pageSize: pagination.pageSize, total: pagination.total}
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
      sorter: true,
      sortOrder: sorter.columnKey === "id" && sorter.order
    },
    {
      title: "User Name",
      dataIndex: "userName",
      key: "userName",
      sorter: true,
      sortOrder: sorter.columnKey === "userName" && sorter.order
    },
    {
      title: "Email",
      dataIndex: "email",
      key: "email",
      sorter: true,
      sortOrder: sorter.columnKey === "email" && sorter.order
    },
    {
      title: "Full Name",
      dataIndex: "fullName",
      key: "fullName",
      sorter: true,
      sortOrder: sorter.columnKey === "fullName" && sorter.order
    },
    {
      title: "Birth",
      dataIndex: "dateOfBirth",
      key: "dateOfBirth",
      sorter: true,
      sortOrder: sorter.columnKey === "dateOfBirth" && sorter.order
    },
    {
      title: "Registered Date",
      dataIndex: "registrationDate",
      key: "registrationDate",
      sorter: true,
      sortOrder: sorter.columnKey === "registrationDate" && sorter.order
    }
  ];

  return (
    <div>
       <Form
        form={form}
        name="searh"
        onFinish={onFinish}
        layout={formLoyaut}
        scrollToFirstError
        className="users-form"
      >
        <Form.Item name="searchData" label={null}>
          <Input className="item" />
        </Form.Item>
        <Form.Item>
          <Button htmlType="submit">
            Search
          </Button>
        </Form.Item>
        <Form.Item>
          <Button htmlType="button" onClick={clearValue}>
            Clear
          </Button>
        </Form.Item>
      </Form>
      <Table
        bordered
        columns={columns}
        dataSource={users}
        pagination={pagination}
        title={() => "Users table"}
        rowKey={(record) => record.id}
        expandable={{
          expandedRowRender: (record) => (
            <CourseExpandableList email={record.email} />
          ),
          rowExpandable: (record) => record.name !== "Not Expandable",
        }}
        onChange={sortTable}
      />
    </div>
  );
};