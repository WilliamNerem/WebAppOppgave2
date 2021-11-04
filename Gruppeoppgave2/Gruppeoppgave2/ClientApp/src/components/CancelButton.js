import React from 'react';

export function CancelButton() {

    function handleClick() {
        window.location.href = '/departures';
    }

    return (
        <button onClick={handleClick} className="btn btn-danger cancelBtn" >Avbryt</button>
    );
}