import React from 'react';

export function CancelButton(props) {

    function handleClick() {
        window.location.href = '/departures';
    }

    return (
        <button onclick={handleClick} className="btn btn-danger cancelBtn">Avbryt</button>
    );
}