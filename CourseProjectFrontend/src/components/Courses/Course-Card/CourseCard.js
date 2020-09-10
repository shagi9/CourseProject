import React from "react";
import { Card, Button } from "antd";
import { Link } from "react-router-dom";
import './CourseCard.scss';

export const CourseCard = ({ id, name, description, imgUrl}) => {
  const { Meta } = Card;
  const link = "/subscribe/" + id;
  const file = 'https://localhost:5001/images/' + imgUrl;
  console.log(file);
  return (
    <Card
        cover = {
        <img
          className="img"
          src={file} 
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

