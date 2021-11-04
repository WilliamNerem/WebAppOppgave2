import React, { useEffect, useState } from 'react';

export function Timepicker(props) {
    const [newValue, setNewValue] = useState(props.oldTime);

    useEffect(() => {
        props.state(props.oldTime);
    }, []);

    function handleChange(value) {
        const str = value.target.value;
        setNewValue(str);
        props.state(str);
    }

    return (
        <div onChange={handleChange}>
            <label>{props.label}
                <input className="form-control timepicker" value={newValue} type="time" />
                <p className="errorMsg">{props.errorMsg}</p>
            </label>
        </div>
    );
}