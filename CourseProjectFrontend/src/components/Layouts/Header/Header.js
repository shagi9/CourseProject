import React, { Component } from 'react'
import { NavLink } from "react-router-dom";
import { remove } from "js-cookie";
import { useDispatch } from "react-redux";
import { setUser } from "../../../store/actions/user.actions";
import LogoImg from "../../../assets/images/simple2.png";
import { Link } from "react-router-dom";
import { UserOutlined, LaptopOutlined, NotificationOutlined } from '@ant-design/icons';
import { Layout, Menu, Drawer } from 'antd';

import classes from './Header.css';

export const Header = ({ user }) => {

  const dispatch = useDispatch();

  const logout = () => {
    remove("token");
    remove("refreshToken");
    dispatch(setUser({}));
  };

  return (
    <Layout.Header>
      <div className="logo" />
      <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['2']}>
        <Menu.Item key="1">
          <NavLink to="/">
            Home
          </NavLink>
        </Menu.Item>

      { user.role ? (
      <Menu.Item key="4">
        <NavLink to="loginPage" onClick={logout}>
          Sign Out
        </NavLink>
      </Menu.Item>
      ) : (
        <Menu.Item key="3">
          <NavLink to="loginPage">
            Sign In
          </NavLink>
        </Menu.Item>
      )}
    </Menu>
    </Layout.Header>
  );
}
