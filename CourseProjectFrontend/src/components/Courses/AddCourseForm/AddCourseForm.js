import React, { useState } from 'react';
import {
  Form,
  Input,
  Upload,
  Alert,
  Button
} from 'antd';
import './AddCourseForm.scss';
import { postRequest } from '../../../helpers/axios_requests';
import { UploadOutlined } from '@ant-design/icons';

const formLoyaut = "vertical";

export const AddCourseForm = () => {
  const [file, setFile] = useState(null);
  const [form] = Form.useForm();

  const hangleChange = e => {
    console.log(e.target.files, "value");
    setFile(e.target.files[0]);
  }

  const onFinish = async (values) => {
    const formData = new FormData();
    for (var key in values)
      formData.append(key, values[key]);
    
    formData.append("file", file);  
    console.log(file);
    console.log("Received values of form: ", values);

    const { status, data } = await postRequest('/Course/AddCourseByAdmin', formData);

    if (status === 200) {
      console.log(data);
    }
    if (status === 400) {
      console.log(data);
    }
    setFile(null);
    form.resetFields();
  };

  return (
    <Form
      className="form"
      name="form"
      layout={formLoyaut}
      onFinish={onFinish}
      form={form}
      scrollToFirstError
    >
      <h1 style={{ textAlign: "center" }}>Add Course</h1>
      <Form.Item
        name="name"
        label="Title"
      >
        <Input />
      </Form.Item>
      <Form.Item
        name="description"
        label="Description"
      >
        <Input.TextArea />
      </Form.Item>
      <label className="file-input-label">
        <input
          id="file-input"
          className="file-input"
          type="file" 
          name="file" 
          onChange={hangleChange}
        />
        <p className="fake-btn"><UploadOutlined /> Upload</p>
        {file && <p className="file-name">{file.name}</p>}
      </label>
      <Form.Item>
        <Button type="primary" htmlType="submit">
          submit
        </Button>
      </Form.Item>
    </Form>
  );
}
