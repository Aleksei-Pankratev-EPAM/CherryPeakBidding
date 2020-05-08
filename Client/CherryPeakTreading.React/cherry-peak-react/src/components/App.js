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
  constructor(props) {
    super(props);
  }
  render() {
    return (
      // <div>fdsfdhsfh</div>
      <Router>
        <div className="App containwer-fluid">
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

// import React from 'react';
// import logo from './logo.svg';
// import './App.css';

// function App() {
//   return (
//     <div className="App">
//       <header className="App-header">
//         <img src={logo} className="App-logo" alt="logo" />
//         <p>
//           Edit <code>src/App.js</code> and save to reload.
//         </p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Learn React
//         </a>
//       </header>
//     </div>
//   );
// }

// export default App;
