import React from 'react';
import { FormStrekning } from '../components/FormStrekning';

export function NewStrekning() {
    const user = sessionStorage.getItem('loggedIn');
    if (user === null) {
        window.location.href = '/';
    }

    return (
        <div>
            <FormStrekning />
        </div>
    );

}