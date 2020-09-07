import React, { Component } from 'react'
import { Link } from "react-router-dom";
import { UserOutlined } from "@ant-design/icons";
import { remove } from "js-cookie";
import { useDispatch } from "react-redux";
import { setUser } from "../../../store/actions/user.actions";
import Title from 'antd/lib/typography/Title';
import { Layout, Avatar, Menu, Button } from 'antd';

import './Header.scss';

export const Header = ({ user }) => {

  const dispatch = useDispatch();

  const logout = () => {
    remove("token");
    remove("refreshToken");
    dispatch(setUser({}));
  };

  return (
    <Layout.Header>
      <div className="header">
      <div className="logo" />
      <Link to="/courses">
      <h2 className="logo-text">CourseProject</h2>
      </Link>
      {user.role && 
        <div>
          {user.role === "student" ? (
            <Link to="/profile" >
            <Avatar
              style={{ backgroundColor: "#d9d9d9", float:"right", right:"140px", bottom:"60px" }}
              icon={<UserOutlined />}
            />
            </Link>
          ) : (
            <Avatar size={35} style={{ backgroundColor: "#2f4f4f", float:"right", right:"150px", bottom:"60px" }}>
              {user.userName}
            </Avatar>
          )}
        </div>
      }
      {user.role ? (
        <Link to="/login">
        <Button type="primary" style={{ float: 'right', bottom: "60px" }} danger onClick={logout}>
          Sign Out
        </Button>
        </Link>
      ) : (
        <Link to="/login">
          <Button  className="sign-in" type="primary">Sign In</Button>
        </Link>
      )}
      </div> 
    </Layout.Header>     
  );
}
