import React from 'react';
import { Link } from 'react-router-dom';
import { set } from 'js-cookie';
import './LoginForm.css';
import { postRequest, getRequest } from '../../../helpers/axios_requests';
import { Form, Input, Checkbox, Button } from 'antd';

import { setUser } from '../../../store/actions/user.actions';
import { useDispatch } from 'react-redux';
  
  export const LoginForm = () => {
    const [form] = Form.useForm();
    const dispatch = useDispatch();
    
    const onFinish = async values => {
  
      const { status, data } = await postRequest('/auth/login', values);
      
      if(status === 200) {
        if(data.token != null){
          set('token', data.token);
  
          const userRespounce = await getRequest('/user/get-authorized-by-user');
          if(userRespounce.status === 200){
            dispatch(setUser(userRespounce.data));
          }
        }
      }
      else {
        form.setFields([
          {
            name: 'login',
            value: values.login,
            errors: ["Login or password is invalid"]
          },
          {
            name: 'password',
            value: values.password,
            errors: ["Login or password is invalid"]
          }
        ]);
      }
    };

  return (
    <Form
      className="login-form"
      name="basic"
      initialValues={{ remember: true }}
      onFinish={onFinish}
      form={form}
    >
      <Form.Item
        label="Username"
        name="login"
        placeholder="username"
        rules={[{ required: true, message: 'Please input your username!' }]}
      >
        <Input placeholder="Username" />
      </Form.Item>
      <Form.Item
        label="Password"
        name="password"
        rules={[{ required: true, message: 'Please input your password!' }]}
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
        Or <Link to="/registerPage">register now!</Link>
      </Form.Item>
    </Form>
  );
};

export default LoginForm;