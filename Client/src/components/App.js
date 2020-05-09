import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Route, Switch
} from 'react-router-dom';
 import HomePage from './HomePage';
import AddLot from './lots/AddLot';
import LotsList from './lots/LotsList';
import LotDetails from './lots/LotDetails';
import Registration from './Registration';
import Login from './Login';
import NavBar from './NavBar';
import NotFoundPage from './NotFoundPage';

import '../css/App.css';
import Statistics from './Statistics';

class App extends Component {

  render() {
    return (
      <Router>
        <div className="App container-fluid">
          <NavBar />
          <div id="page-body">
            <Switch>
              <Route path="/" component={HomePage} exact />
              <Route path="/add-lot" component={AddLot} />
              <Route path="/lots-list" component={LotsList} />
              <Route path="/lot-details/:id" component={LotDetails} />
              <Route path="/statistics" component={Statistics} />
              <Route path="/registration" component={Registration} />
              <Route path="/login" component={Login} />
              <Route component={NotFoundPage} />
            </Switch>
          </div>
        </div>
      </Router>
    );
  }
}

export default App;
