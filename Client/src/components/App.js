import React from 'react';
import { BrowserRouter } from 'react-router-dom';
//import {serverIsAvailable} from '../services/ServerAccessChecker'

import Sidebar from './Sidebar';
import PageContent from './PageContent';

function App() {
  //serverIsAvailable();

  return (
    <div className="container-fluid">
      <div className="row">
        <BrowserRouter>
          <Sidebar />
          <PageContent />
        </BrowserRouter>
      </div>
    </div>
  );
}

export default App;