import React, { Fragment } from "react";
import Registration from "./Pages/Registration";
import {Route } from 'react-router-dom'
import LoginForm from "./Pages/LoginForm";

const App: React.FC = () => {
  return (
    <Fragment>
      <Route path='/register' component={Registration}/>
      <Route path='/login' component={LoginForm}/>
    </Fragment>
  );
};

export default App;
