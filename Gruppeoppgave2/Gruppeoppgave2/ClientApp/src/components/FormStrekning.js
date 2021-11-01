﻿import React, { useState, ReactDOM } from 'react';
import { InputField } from '../components/InputField';
import { Button } from '../components/Button';
import $ from 'jquery';

export function FormStrekning() {
    const [strekning, setStrekning] = useState();
    const [pris, setPris] = useState();
    const [errorStrekning, setErrorStrekning] = useState("");
    const [errorPris, setErrorPris] = useState("");
    const validStrekning = new RegExp('^[A-Z][a-z]+ - [A-Z][a-z]+$');
    const validPris = new RegExp('^[0-9]+$');

    function add() {
        const nyStrekning = {
            navn: strekning,
            pris: pris
        };
        $.post("strekning/Lagre", nyStrekning, function (OK) {
            if (!OK) {
                $("#feil").html("Feil i db, vennligst forsøk igjen");
            }
        });
    }

    function validateForm(e) {
        let error = false;
        if (!validStrekning.test(strekning)) {
            setErrorStrekning('Strekning må være på formatet "Fra - Til"');
            e.preventDefault();
            error = true;
        } else {
            setErrorStrekning('');
        }

        if (!validPris.test(pris)) {
            setErrorPris('Pris må kun inneholde tall');
            e.preventDefault();
            error = true;
        } else {
            setErrorPris('');
        }

        if (!error) {
            add();
        }
    }

    return (
        <form action="/departures" onSubmit={validateForm}>
            <InputField errorMsg={errorStrekning} state={setStrekning} name="Strekning" InputField="Strekning: " />
            <InputField errorMsg={errorPris} state={setPris} name="Pris" InputField="Pris: " />
            <Button text="Legg til" />
        </form>
    );
}