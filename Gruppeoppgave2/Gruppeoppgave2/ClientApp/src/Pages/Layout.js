import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavBar } from '../components/NavBar';

export function Layout(props) {

    return (
        <div>
            <NavBar />
            <Container className='p-5'>
                {props.children}
            </Container>
        </div>
    );
}
