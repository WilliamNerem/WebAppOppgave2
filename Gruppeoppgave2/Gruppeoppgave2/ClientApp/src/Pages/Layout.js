import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavBar } from '../components/NavBar';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
        <div>
            <NavBar />
            <Container className='p-5'>
              {this.props.children}
            </Container>
      </div>
    );
  }
}
