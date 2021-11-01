import React, { useState } from 'react';
import { InputField } from '../components/InputField';
import { Button } from '../components/Button';
import $ from 'jquery';

export function FormStrekning(props) {
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
        })
        .fail(function (feil) {
            if (feil.status == 401) {
                window.location.href = "/"
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
    console.log(props.textStrekning);
    console.log(props.textPris);

    return (
        <form action="/departures" onSubmit={validateForm}>
            <InputField testing={props.textStrekning} errorMsg={errorStrekning} state={setStrekning} name="Strekning" InputField="Strekning: " />
            <InputField testing={props.textPris} errorMsg={errorPris} state={setPris} name="Pris" InputField="Pris: " />
            <Button text="Legg til" />
        </form>
    );
}