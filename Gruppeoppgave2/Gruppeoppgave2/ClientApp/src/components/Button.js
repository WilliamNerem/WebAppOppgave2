import React from 'react';

const Button = ({ children, onClick, btnColor = 'teal', labelColor, disabled, type, style, ...props }) => {
    return (
        <button className="btn btn-primary">
            {children || 'Logg inn'}
        </button>
    );
};

export default Button;