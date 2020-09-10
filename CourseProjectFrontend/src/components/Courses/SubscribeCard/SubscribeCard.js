import React, { useState, useEffect } from "react";
import { Card, DatePicker, Button} from "antd";
import { postRequest, getRequest } from "../../../helpers/axios_requests";

import "./SubscribeCard.scss";
import { AlertOutlined } from "@ant-design/icons";

export const SubscribeCard = ({id, name, description, imgUrl}) => {
  const [courseDate, setCourseDate] = useState();
  const [isSubscribed, setIsSubscribed] = useState(false);

  useEffect(() => {
    const checkSubscriptionsStatus = async () => {
      const { status } = await getRequest(
        `/Course/GetIsUserSubscribedToTheCourse?courseId=${id}`
      );
      if (status === 200) {
        setIsSubscribed(true);
      }
    };

  if (id !== undefined) {
    checkSubscriptionsStatus();
  }
  console.log("id effect " + id);
}, [id]);

const disabledDate = (current) => {
  let today = new Date();
  return current && current < today;
};

const handleDatePickerChange = (dateString) => {
  setCourseDate(dateString);
};

const subscribeToTheCourse = async () => {
  const { status } = await postRequest("/Course/SubscribeToCourse", {
    courseId: id,
    startDate: courseDate
  });
  if (status === 200) {
    setIsSubscribed(true);
  }
};

const file = 'https://localhost:5001/images/' + imgUrl;

  return (
    <Card title={name} className="subscribe-card">
      <img src={file} alt="courseImage" className="imgsubscribe" />
      <p>{description}</p>
        {!isSubscribed ? ( 
        <div className="subscribe-block">
            <h3>Choose a date when you want to start studying:</h3>
            <DatePicker
            onChange = {(dateString) => 
              handleDatePickerChange(dateString)
            }
            disabledDate={disabledDate} 
              showToday={false}
            />
            <Button type="primary" onClick={subscribeToTheCourse}>
              Subscribe
            </Button>
          </div>
        ) : (
          <div className="subscribe-block">
          <h3>
            <AlertOutlined className="logo-succsess"/> You've already registered for the course. 
          </h3>
        </div>
        )}
    </Card>
  );
}
