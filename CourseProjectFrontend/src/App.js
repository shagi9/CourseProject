import React, { useEffect } from 'react';
import { BrowserRouter as Router, Switch, Route, Redirect} from 'react-router-dom';
import { setUser } from './store/actions/user.actions';
import { get } from 'js-cookie';
import { getRequest } from './helpers/axios_requests';
import { useSelector, useDispatch } from 'react-redux';
import './App.css';

import { LoginPage } from './pages/LoginPage/LoginPage';
import { RegisterPage } from './pages/RegisterPage/RegisterPage';
import { Home } from './pages/Home/Home';
import { Header } from './components/Layouts/Header/Header';
import { Admin } from './pages/Admin/Admin';
import { ConfirmationPage } from './pages/ConfirmationPage/ConfirmationPage';
import { SubscribePage } from './pages/SubscribePage/SubscribePage';
import {UserProfilePage } from './pages/ProfilePage/Profile';
import Courses from './pages/CoursesPage/Courses';
import { PageNotFound } from './pages/404-Page/404-page';

export const App = () => {
  const user = useSelector(state => state.user);
  const dispatch = useDispatch();
  
  useEffect(() => {
    const fetchUser = async () => {
      const { status, data } = await getRequest('/user/get-authorized-by-user');
      if(status === 200){
        dispatch(setUser(data));
      }
    }
    if(!!get("token"))
      fetchUser();
    else
      dispatch(setUser({})); 
  }, [dispatch]);

  return (
    <Router>
      {
    user ? <div className="App">
      <Header user={user} />
      <Switch>
        <Route path="/" exact component={Home}></Route>
        <Route path="/login" component={() => !user.role ? <LoginPage /> : (user.role === "student" ? <Redirect to="/courses"/> : <Redirect to="/admin" />)}/>
        <Route path="/register" component={RegisterPage}></Route>
        <Route path="/courses" component={() => !user.role ? <Redirect to="/login"/> : (user.role === "admin" ? <Redirect to="/admin"/> : <Courses/>)} />
        <Route path="/confirmation/:userId/:token" component={ConfirmationPage} />
        <Route path="/subscribe/:courseId" component={() => !!user.role ? <SubscribePage/> : <Redirect to="/login"/>}/>
        <Route path="/admin" component={() => !user.role ? <Redirect to="/login"/> : (user.role === "student" ? <Redirect to="/"/> : <Admin/>)}/>
        <Route path="/profile" component={() => !user.role ? <Redirect to="/login"/> : (user.role === "admin" ? <Redirect to="/admin"/> : <UserProfilePage/>)} />
        <Route path='/404' component={PageNotFound} />
        <Redirect from='*' to='/404' /> 
      </Switch>
    </div> : <div></div>
    }
    </Router>
    );
  }

export default App;