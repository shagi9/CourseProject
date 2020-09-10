import React, { useState } from 'react';
import {
  Form,
  Input,
  Tooltip,
  DatePicker,
  Checkbox,
  Button,
  Alert
} from 'antd';
import './RegisterForm.scss';
import { QuestionCircleOutlined } from '@ant-design/icons';
import { postRequest } from '../../../helpers/axios_requests';
import { firstAndLastNameRegValidator, 
  userNameRexValidator, dateOfBirthValidator } from '../../../helpers/validation';

 const formLoyaut = "vertical";

 const validationSchema = {
   Email: [
     { required: true, message: "The E-mail field is required" },
     { type: "email", message: "The input is not valid E-mail"}
    ],
   Password: [
     { required: true, message: "The Password field is required"},
     { min: 8, message: "Minimum length is 8 characters"},
     { max: 128, message: "Password is to long"}
    ],
   FirstName: [{ required: true, message: "The Firstname field is required"}, 
     { validator: firstAndLastNameRegValidator}
    ],
   LastName: [{ required: true, message: "The Lastname field is required"}, 
     { validator: firstAndLastNameRegValidator}
    ],
   UserName: [{ required: true, message: "The Username field is required", whitespace: true},
    { min: 8, message: "Minimum length is 8 characters"},
    { max: 20, message: "Username is to long"},
    { validator: userNameRexValidator} 
    ],
   DateOfBirth: [{ required: true, message: "The Dateofbirth field is required"},
    { validator: dateOfBirthValidator}
   ]
 };

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
        descriptions:
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
    <Form
      layout={formLoyaut}
      form={form}
      name="register"
      onFinish={onFinish}
      className="register-form"
      scrollToFirstError
    >
      <h1 style={{textAlign: "center", color: "#1890ff"}}>Sign Up</h1>
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
        label="First Name"
        rules={validationSchema.FirstName}
      >
        <Input className="item"/>
      </Form.Item>

      <Form.Item
        name="lastName"
        label="Last Name"
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
      >
        <Checkbox>
          I have read the agreement
        </Checkbox>
      </Form.Item>
      <Form.Item>
        <Button type="primary" htmlType="submit">
          Register
        </Button>
      </Form.Item>
    </Form>
  ) : (
    <Alert
    message={responseStatus.message}
    description={responseStatus.descriptions}
    type={responseStatus.type}
    showIcon
    />
  );
};