import React from 'react';

export class Button extends React.Component {


    render() {
        return (
            <input type="submit" value={this.props.text} className="btn btn-primary"></input>
        );
    }
}