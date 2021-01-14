import React from 'react';
import {BrowserRouter, Switch, Route} from 'react-router-dom';
import Login from './components/Login'
import Menu from './components/Menu'

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={Login}/>
        <Route exact path="/menu" component={Menu}/>
      </Switch>
    </BrowserRouter>
  );
}

export default App;
