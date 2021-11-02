import React, { useEffect, useState } from 'react';

export function InputField(props) {
    const [newValue, setNewValue] = useState(props.testing);

    useEffect(() => {
        props.state(props.testing);
    }, []);

    function handleChange(value) {
        const str = value.target.value;
        setNewValue(str);
        props.state(str);
    }

    return (
        <div>
            <label>{ props.InputField }
                <input className="form-control" value={newValue} onChange={handleChange} type="text" ></input>
            </label>
            <p className="errorMsg">{props.errorMsg}</p>
        </div>
    );
}