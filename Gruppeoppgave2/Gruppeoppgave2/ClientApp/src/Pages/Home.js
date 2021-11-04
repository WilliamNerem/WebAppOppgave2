import React from 'react';
import { Login } from '../components/Login';

export function Home() {

    const user = sessionStorage.getItem('loggedIn');
    if ((user !== null) && (user !== 'null')) {
        window.location.href = '/departures';
    }

    return (
        <Login />
    );
}