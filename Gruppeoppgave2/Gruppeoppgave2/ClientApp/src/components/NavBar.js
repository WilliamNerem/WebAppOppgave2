import React, { Component } from 'react';

export class NavBar extends Component {
    static displayName = NavBar.name;

    render() {
        return (
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <div class="container-fluid">
                    <a class="navbar-brand" href="/">Home</a>
                    <a class="navbar-brand" href="/departures">Departures</a>
                    
                </div>
            </nav>
        );
    }
}