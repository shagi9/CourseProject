import React, { useEffect, useState } from "react";
import { Result, Button } from "antd";
import { Link, useParams } from "react-router-dom";
import { getRequest } from "../../helpers/axios_requests";

export const ConfirmationPage = () => {
  const [resStatus, setResStatus] = useState({
    status: "error",
    title: "Something went wrong, try to register new account again.",
  });
  const [view, setView] = useState(false);

  const { userId, token } = useParams();

  useEffect(() => {
    const confirmEmail = async () => {
      const { status } = await getRequest(
        `/auth/verifyEmail?userId=${userId}&token=${token}`
      );
  
      if (status === 200) {
        setResStatus({
          status: "success",
          title: "You have been successfully register to the Honey Course !",
        });
      } else {
      }
      setView(true);
    };
    confirmEmail();
  }, [userId,token]);

  return (
    <div className="email-confirmation">
      {view && (
        <Result
          status={resStatus.status}
          title={resStatus.title}
          extra={[
            <Link to="/loginPage">
              <Button type="primary">Start learning !</Button>
            </Link>,
          ]}
        />
      )}
    </div>
  );
};     