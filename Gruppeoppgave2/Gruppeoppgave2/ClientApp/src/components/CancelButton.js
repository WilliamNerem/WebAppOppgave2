import React from 'react';

export function CancelButton(props) {

    function handleClick() {
        window.location.href = '/departures';
    }

    return (
        <button type="button" onClick={handleClick} className="btn btn-danger cancelBtn">Avbryt</button>
    );
}