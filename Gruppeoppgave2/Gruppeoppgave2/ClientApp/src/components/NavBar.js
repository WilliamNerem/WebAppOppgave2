import React, { useState, useEffect } from 'react';

export function NavBar() {
    const [loggedIn, setLoggedIn] = useState("Ikke logget inn");

    useEffect(() => {
        const user = sessionStorage.getItem('loggedIn')
        if (user !== null) {
            setLoggedIn("Logget inn som: " + user);
        }
    },[]);

    return (
        <nav className="navbar navbar-expand-lg navbar-light">
            <div className="container-fluid">
                <a className="navbar-brand text-light" href="/"><img src="#" alt="" width="100" height="50" /></a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav p-2">
                        <li className="nav-item">
                            <a className="nav-link active text-light" aria-current="page" href="/">Hjem</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link active text-light" aria-current="page" href="/departures">Strekninger</a>
                        </li>
                    </ul>
                    <ul className="navbar-nav p-2">
                        <p className="text-light">{loggedIn}</p>
                    </ul>
                </div>
            </div>
        </nav>
    );
}