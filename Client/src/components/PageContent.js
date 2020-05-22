import React from 'react';
import { Switch, Route } from 'react-router-dom';

import Home from './Home';
import Login from './Login';
import Register from './Register';
import LotList from './lot/LotList';
import AddLot from './lot/AddLot';
import LotDetails from './lot/LotDetails';
import Statistics from './Statistics';
import NotFound from './NotFound';

import '../css/PageContent.css';

function PageContent() {
    return (
        <div className="page-content col-md">
            <Switch>
                <Route path="/" component={Home} exact />
                <Route path="/lots" render={({ match: { url } }) => (
                    <>
                        <Route path={`${url}/`} component={LotList} exact />
                        <Route path={`${url}/add`} component={AddLot} />
                        <Route path={`${url}/details/:id`} component={LotDetails} />
                    </>
                )}
                />
                <Route path="/login" component={Login} />
                <Route path="/register" component={Register} />
                <Route path="/statistics" component={Statistics} />
                <Route path="*" component={NotFound} />
            </Switch>
        </div>
    );
}

export default PageContent;