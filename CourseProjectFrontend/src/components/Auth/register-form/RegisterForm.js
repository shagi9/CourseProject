import React, { useState } from 'react';
import {
  Form,
  Input,
  Tooltip,
  Row,
  DatePicker,
  Checkbox,
  Button,
  Alert
} from 'antd';
import { QuestionCircleOutlined } from '@ant-design/icons';
import { postRequest } from '../../../helpers/axios_requests';

 const formItemLayout = {
   labelCol: {
     xs: { span: 24 },
     sm: { span: 8 },
   },
   wrapperCol: {
     xs: { span: 24 },
     sm: { span: 16 },
   },
 };
 const tailFormItemLayout = {
   wrapperCol: {
     xs: {
       span: 24,
       offset: 0,
     },
     sm: {
       span: 16,
       offset: 8,
     },
   },
 };

 const validationSchema = {
   Email: [
     { required: true, message: "The e-mail field is required" },
     { type: "email", message: "The input is not valid E-mail"}
    ],
   Password: [
     { required: true, message: "The password field is required"},
     { min: 8, message: "Minimum length is 6 characters"}
   ],
   FirstName: [{ required: true, message: "The firstname field is required"}],
   LastName: [{ required: true, message: "The lastname field is required"}],
   UserName: [{ required: true, message: "The username field is required", whitespace: true}],
   DateOfBirth: [{ required: true, message: "The dateofbirth field is required"}],
 }

export const RegisterForm = () => {
  const [responseStatus, setResponseStatus] = useState({
    finished: false
  });
  const [form] = Form.useForm();

  const onFinish = async (values) => {
    console.log("Received values of form: ", values);

    const { status, data } = await postRequest("/auth/register", values);
    
    if (status === 200) {
      console.log(data);
      setResponseStatus({
        message: data,
        discriptions:
          "Please confirm your email before start using the application.",
        type: "success",
        finished: true,
      });
    } 
    if (status === 400) {
      console.log(data);

      data.forEach((element) => {
        if (element.code === "DuplicateEmail") {
          form.setFields([
            {
              name: "email",
              value: values.email,
              errors: [element.description],
            },
          ]);
        }
        if (element.code === "DuplicateUserName") {
          form.setFields([
            {
              name: "userName",
              value: values.userName,
              errors: [element.description],
            },
          ]);
        }
      });
    }
  };

  return !responseStatus.finished ? (
    <Row type="flex" justify="center" align="middle" style={{height: '100%'}}>
    <Form
      {...formItemLayout}
      form={form}
      name="register"
      onFinish={onFinish}
       initialValues={{
         residence: ['zhejiang', 'hangzhou', 'xihu'],
         prefix: '86',
       }}
      scrollToFirstError
    >
      <Form.Item
        name="email"
        label="E-mail"
        rules={validationSchema.Email}
      >
        <Input />
      </Form.Item>

      <Form.Item
        name="password"
        label="Password"
        rules={validationSchema.Password}
        hasFeedback
      >
        <Input.Password />
      </Form.Item>

      <Form.Item
        name="firstName"
        label="FirstName"
        rules={validationSchema.FirstName}
      >
        <Input />
      </Form.Item>

      <Form.Item
        name="lastName"
        label="LastName"
        rules={validationSchema.LastName}
      >
        <Input />
      </Form.Item>

      <Form.Item
        name="userName"
        label={
          <span>
            Username&nbsp;
            <Tooltip title="What do you want others to call you?">
              <QuestionCircleOutlined />
            </Tooltip>
          </span>
        }
        rules={validationSchema.UserName}
      >
        <Input />
      </Form.Item>

      <Form.Item
          name="dateOfBirth"
          label="Date of birth"
          rules={validationSchema.DateOfBirth}
        >
          <DatePicker />
        </Form.Item>

      <Form.Item
        name="agreement"
        valuePropName="checked"
        rules={[
          { validator:(_, value) => value ? Promise.resolve() : Promise.reject('Should accept agreement') },
        ]}
        {...tailFormItemLayout}
      >
        <Checkbox>
          I have read the agreement
        </Checkbox>
      </Form.Item>
      <Form.Item {...tailFormItemLayout} >
        <Button type="primary" htmlType="submit">
          Register
        </Button>
      </Form.Item>
    </Form>
    </Row>
  ) : (
    <Alert
    message={responseStatus.message}
    description={responseStatus.descriptions}
    type={responseStatus.type}
    showIcon
    />
  );
};