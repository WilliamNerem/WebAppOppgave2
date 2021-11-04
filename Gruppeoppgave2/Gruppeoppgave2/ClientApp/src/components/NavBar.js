import React, { useState, useEffect } from 'react';
import $ from 'jquery';
import Modal from './Modal';
import img from '../img/Color_Line_color_horizontal.svg'

export function NavBar() {
    const [loggedIn, setLoggedIn] = useState("Ikke logget inn");
    const [logOutButton, setLogOutButton] = useState();

    const modalId = "logOutModal";
    const modalTitle = "Logge ut?";
    const modalBodyText = "Du er i ferd med å logge ut av denne brukeren. Er du sikker på at du vil fortsette? Alle ulagrede endringer vil bli borte.";
    const modalDismissText = "Avbryt";
    const modalContinueText = "Logg ut";

    useEffect(() => {
        const user = sessionStorage.getItem('loggedIn');
        if ((user !== null) && (user !== "null")) {
            setLoggedIn("Logget inn som: " + user);
            setLogOutButton(
                <button type="button" className="btn btn-info" aria-current="page" data-bs-toggle="modal" data-bs-target="#logOutModal">Logg ut</button>
                );
        }
    }, []);

    const logOut = () => {
        $.post("Strekning/LoggUt", function (OK) {
            sessionStorage.setItem('loggedIn', null);
            window.location.href = '/'
        });
    }

    return (
        <nav className="navbar navbar-expand-lg navbar-light">
            <div className="container-fluid">
                <a className="navbar-brand bg-light" href="/departures">
                    <img src={img} alt="Image of Color Line Logo" width="100" height="50" />
                </a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <a className="nav-link active text-light" aria-current="page" href="/departures">Hjem</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link active text-light" aria-current="page" href="/departures">Strekninger</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link active text-light">{loggedIn}</a>
                        </li>
                        {logOutButton}
                    </ul>
                </div>
            </div>
            <Modal id={modalId} continue={logOut} title={modalTitle} body={modalBodyText} dismissBtn={modalDismissText} continueBtn={modalContinueText} />
        </nav>
    );
}