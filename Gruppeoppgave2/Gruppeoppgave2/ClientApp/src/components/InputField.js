import React, { useState } from 'react';

export class InputField extends React.Component {


    render() {
        return (
            <form>
                <label>{this.props.InputField}
                    <input type="text" />
                </label>
            </form>
        );
    }
}