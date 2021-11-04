import React from 'react';

export function InputFieldPassword(props) {

    function handleChange(value) {
        const str = value.target.value;
        props.state(str);
    }

    return (
        <div>
            <label>{props.InputField}
                <input className="form-control" value={props.testing} onChange={handleChange} type="password" ></input>
            </label>
            <p className="errorMsg">{props.errorMsg}</p>
        </div>
    );
}