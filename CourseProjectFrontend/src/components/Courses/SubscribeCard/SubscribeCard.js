import React, { useState, useEffect } from "react";
import { Card, DatePicker, Button, Spin } from "antd";
import { postRequest, getRequest } from "../../../helpers/axios_requests";

import { Link } from "react-router-dom";
import { AlertOutlined } from "@ant-design/icons";

export const SubscribeCard = () => {
  return (
    <Card title="title" className="subscribe-card">
      <img src="{imgUrl}" alt="courseImage" className="imgsubscribe" />
      <p>"info"</p>
      <div className="content">
        <h3>How the Specialization Works</h3>
        <h4>Take Courses</h4>
        <p>
          A Honey Course Specialization is a series of courses that helps you
          master a skill. To begin, enroll in the Specialization directly, or
          review its courses and choose the one you'd like to start with. When
          you subscribe to a course that is part of a Specialization, you’re
          automatically subscribed to the full Specialization. It’s okay to
          complete just one course — you can pause your learning or end your
          subscription at any time. Visit your learner dashboard to track your
          course enrollments and your progress.
        </p>
        <h4>Hands-on Project</h4>
        <p>
          Every Specialization includes a hands-on project. You'll need to
          successfully finish the project(s) to complete the Specialization and
          earn your certificate. If the Specialization includes a separate
          course for the hands-on project, you'll need to finish each of the
          other courses before you can start it.
        </p>
        <h4>Earn a Certificate</h4>
        <p>
          When you finish every course and complete the hands-on project, you'll
          earn a Certificate that you can share with prospective employers and
          your professional network.
        </p>
      </div>
          <div className="subscribe-block">
            <h3>Choose a date when you want to start studying:</h3>
            <DatePicker
              showToday={false}
            />
            <Button type="primary">
              Subscribe
            </Button>
          </div>
    </Card>
  )
}
