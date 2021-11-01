import React from 'react';

export function InputField(props) {
    function handleChange(value) {
        const str = value.target.value;
        props.state(str);
    }

    return (
        <div>
            <label>{ props.InputField }
                <input className="form-control" onChange={handleChange} type="text" />
            </label>
            <p className="errorMsg">{props.errorMsg}</p>
        </div>
    );
}