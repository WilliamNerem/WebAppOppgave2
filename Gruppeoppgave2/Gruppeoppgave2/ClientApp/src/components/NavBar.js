import React, { Component } from 'react';

export class NavBar extends Component {
    static displayName = NavBar.name;

    render() {
        return (
            <nav className="navbar navbar-expand-lg navbar-light fixed-top">
                <div className="container-fluid">
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <a className="nav-link active text-light" aria-current="page" href="/">Hjem</a>
                                <a className="nav-link active text-light" aria-current="page" href="/departures">Avganger :)</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}