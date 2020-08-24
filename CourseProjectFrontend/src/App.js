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
import Courses from './pages/CoursesPage/Courses';

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
        <Route path="/loginPage" component={() => !user.role ? <LoginPage /> : (user.role === "student" ? <Redirect to="/coursePage"/> : <Redirect to="/admin" />)}/>
        <Route path="/registerPage" component={RegisterPage}></Route>
        <Route path="/coursePage" component={Courses}></Route>
        <Route path="/confirmation/:userId/:token" component={ConfirmationPage} />
        <Route path="/admin" component={Admin}></Route>
        <Route path="/" exact component={Home}></Route>
      </Switch>
    </div> : <div></div>
    }
    </Router>
    );
  }

export default App;