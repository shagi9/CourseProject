import React from 'react';
import './RegisterPage.css';
import { RegisterForm }  from '../../components/Auth/register-form/RegisterForm';

export const RegisterPage = () => {
    return (
      <div className="register-container">
        <RegisterForm />
      </div>
    )
}
