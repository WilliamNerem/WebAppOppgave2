import React from 'react';

export function Button(props) {
    return (
        <input type="submit" value={ props.text } className="btn btn-primary"></input>
    );
}