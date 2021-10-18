import React from 'react';

export function InputField(props) {
    function handleChange(value) {
        const str = value.target.value;
        props.state(str);
    }

    return (
        <label>{ props.InputField }
            <input onChange={ handleChange } type="text" />
        </label>
    );
}