import React from "react";
import { Card, Button } from "antd";
import { Link } from "react-router-dom";

export const CourseCard = ({ id, name, description, imgUrl}) => {
  const { Meta } = Card;
  const link = "/subscribe/" + id;
  return (
    <Card
        cover = {
        <img
          src={imgUrl} 
          alt="courseImage"
        />
      }
      actions={[
        <Link to={link}>
        <Button type="primary">Go to full course description</Button>
      </Link> 
      ]}
      >
      <Meta
      title={name}
      description={description}
    />
    </Card>
  );
};

