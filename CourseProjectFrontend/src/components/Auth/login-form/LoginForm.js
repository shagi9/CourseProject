import React from 'react';
import { Link } from 'react-router-dom';
import { getCookies, set } from 'js-cookie';
import { postRequest, getRequest } from '../../../helpers/axios_requests';
import { Form, Input, Checkbox, Button } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';

import './LoginForm.scss';

import { setUser } from '../../../store/actions/user.actions';
import { useDispatch } from 'react-redux';
  
  export const LoginForm = () => {
    const [form] = Form.useForm();
    const dispatch = useDispatch();

    const errorsSchema = {
      username: ["Email is invalid"],
      password: ["Password is invalid"],
      confirmEmail: ["Please, confirm your email before start using the application"]
    }

    const validationSchema = {
      Login: [
        { required: true, message: "The Email field is required" }
      ],
      Password: [
        { required: true, message: "The Password field is required" }
      ]
    }
    
    const onFinish = async values => {
      const { status, data } = await postRequest('/auth/login', values);
      if (status === 200) {
        if (data.token != null){
          if (data.refreshToken != null){
          set('refreshToken', data.refreshToken);  
          set('token', data.token);
          
          const userResponse = await getRequest('/user/get-authorized-by-user');
          if(userResponse.status === 200){
            dispatch(setUser(userResponse.data));
          }
        }
      }
    }
    if (status === 404) {
      if (!data.isEmailConfirmed) {
        form.setFields([{
          name: 'login',
          value: values.login,
          errors: errorsSchema.confirmEmail
        }]);
      }
    }
    if (status === 400) {
        form.setFields([
        {
          name: 'login',
          value: values.login,
          errors: errorsSchema.username
        },
        {
          name: 'password',
          value: values.password,
          errors: errorsSchema.password
        }
      ]);
    }
  }

  return (
    <Form
    name="normal_login"
    className="login-form"
      initialValues={{
        remember: true,
      }}
      onFinish={onFinish}
      form={form}
    >
      <h1 style={{textAlign: "center", color: "#1890ff"}}>Sign In</h1>
      <Form.Item
        name="login"
        rules={validationSchema.Login}
      >
        <Input
        prefix={<UserOutlined className="site-form-item-icon" />} 
        placeholder="Email" />
      </Form.Item>
      <Form.Item
        name="password"
        rules={validationSchema.Password}
      >
        <Input.Password  
        prefix={<LockOutlined className="site-form-item-icon" />} 
        type="Password" 
        placeholder="Password" />
      </Form.Item>
      <Form.Item>
         <Form.Item name="remember" valuePropName="checked" noStyle>
          <Checkbox>Remember me</Checkbox>
        </Form.Item>
        <Link to="/registerPage" className="login-form-register">Go To Register</Link>
      </Form.Item> 
      <Form.Item>
        <Button className="login-btn" type="primary" htmlType="submit">
          Log in
        </Button>
      </Form.Item>
    </Form>
  );
};

export default LoginForm;