import React from 'react';

export class InputField extends React.Component {


    constructor(props) {
        super(props);
        this.state = {
            username: null,
            password: null
        };
    }

    setUsername = (uname) => {
        this.setState({ username: uname });
    }

    setPassword = (pwd) => {
        this.setState({ password: pwd });
    }

    render() {
        return (
            <label>{this.props.InputField}
                <input onChange={this.setUsername} type="text" />
            </label>
        );
    }
}