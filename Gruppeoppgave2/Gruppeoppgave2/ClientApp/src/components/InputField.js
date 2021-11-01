import React from 'react';

export function InputField(props) {
    function handleChange(value) {
        const str = value.target.value;
        props.state(str);
    }
    console.log(props.testing);
    return (
        <div>
            <label>{ props.InputField }
                <input className="form-control" onChange={handleChange} type="text" ></input>
            </label>
            <p className="errorMsg">{props.errorMsg}</p>
        </div>
    );
}