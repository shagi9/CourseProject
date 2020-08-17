import React, { Component } from 'react'
import './Footer.css';
import { Layout } from 'antd';

const { Footer } = Layout;

export class Footerr extends Component {
  render() {
    return (
      <div className="footer">
        <Footer style={{ textAlign: 'center' }}>Course Managment ©2020 Created by Ilya Shagoferov</Footer>
      </div>
    )
  }
}

export default Footerr