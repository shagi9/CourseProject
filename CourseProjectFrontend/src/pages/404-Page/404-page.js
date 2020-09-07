import React from "react";
import { Result, Button } from "antd";
import { Link } from "react-router-dom";

export const PageNotFound = () => (
  <Result
    style={{backgroundColor: "#364150", height: "100vh" }}
    status="404"
    title="404"
    subTitle="Sorry, the page you visited does not exist."
    extra={
      <Link to="/">
        <Button type="primary">Back Home</Button>
      </Link>
    }
  />
);