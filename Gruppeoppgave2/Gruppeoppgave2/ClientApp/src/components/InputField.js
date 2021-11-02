import React from 'react';

export function InputField(props) {

    function handleChange(value) {
        const str = value.target.value;
        props.state(str);
    }
    console.log("test");
    return (
        <div>
            <label>{ props.InputField }
                <input className="form-control" value={props.testing} onBlur={handleChange} type="text" ></input>
            </label>
            <p className="errorMsg">{props.errorMsg}</p>
        </div>
    );
}