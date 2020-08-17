import React, { Component } from 'react'
import { LoginForm } from '../../components/Auth/login-form/LoginForm';

export class LoginPage extends Component {
    render() {
        return (
            <div className="home-layout">
                <LoginForm />
            </div>
        )
    }
}

export default LoginPage
