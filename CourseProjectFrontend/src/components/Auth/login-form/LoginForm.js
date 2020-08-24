import React from 'react';
import { Link } from 'react-router-dom';
import { getCookies, set } from 'js-cookie';
import './LoginForm.css';
import { postRequest, getRequest } from '../../../helpers/axios_requests';
import { Form, Input, Checkbox, Button } from 'antd';

import { setUser } from '../../../store/actions/user.actions';
import { useDispatch } from 'react-redux';
  
  export const LoginForm = () => {
    
    const [form] = Form.useForm();
    const dispatch = useDispatch();

    const initialValues = {
      Login: "",
      Password: "",
      RememberMe: true,
    };

    const errorsSchema = {
      username: ["username is invalid"],
      password: ["Password is invalid"],
      confirmEmail: ["Please, confirm your email before start using the application."]
    }

    const validationSchema = {
      Login: [
        { required: true, message: "The Username field is required" }
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
      className="login-form"
      name="basic"
      initialValues={initialValues}
      onFinish={onFinish}
      form={form}
    >
      <Form.Item
        label="Username"
        name="login"
        rules={validationSchema.Login}
      >
        <Input placeholder="Username" />
      </Form.Item>
      <Form.Item
        label="Password"
        name="password"
        rules={validationSchema.Password}
      >
        <Input.Password type="Password" placeholder="password" />
      </Form.Item>
      <Form.Item>
        <Form.Item name="remember" valuePropName="checked" noStyle>
          <Checkbox>Remember me</Checkbox>
        </Form.Item>
        <Link to="/registerPage" className="login-form-forgot">
          Forgot password
        </Link>
      </Form.Item>
      <Form.Item>
        <Button className="login-btn" type="primary" htmlType="submit">
          Log in
        </Button>
        Or <Link to="/registerPage">register!</Link>
      </Form.Item>
    </Form>
  );
};

export default LoginForm;