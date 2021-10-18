import React, { Component } from 'react';
import 'bootstrap/dist/js/bootstrap';
import { Route } from 'react-router';
import { Layout } from './Pages/Layout';
import { Home } from './Pages/Home';

import './custom.css'
import { Departures } from './Pages/Departures';

export default class App extends Component {
    static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/departures' component={Departures} />
      </Layout>
    );
  }
}
