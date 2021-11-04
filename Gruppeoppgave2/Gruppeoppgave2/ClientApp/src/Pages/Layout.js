import React from 'react';
import { Container } from 'reactstrap';
import { NavBar } from '../components/NavBar';
import img from '../img/color-line-bg.png';

export function Layout(props) {

    return (
        <div>
            <NavBar />
            <img src={img} alt="Bilde av Color Line som seiler" class="img-bg-top" />
            <Container className='p-5'>
                {props.children}
            </Container>
        </div>
    );
}
