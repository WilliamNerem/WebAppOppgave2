import React from 'react';

export function AddStrekningButton() {

    function addStrekning() {
        window.location.href = '/addStrekning';
    }

    return (
        <div>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"></link>
            <button onClick={addStrekning} className="btn btn-primary">Legg til ny strekning</button>
        </div>
    );
}