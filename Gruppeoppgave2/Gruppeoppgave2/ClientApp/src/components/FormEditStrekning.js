import React, { useState } from 'react';
import { InputField } from '../components/InputField';
import { Timepicker } from '../components/Timepicker';
import { Button } from '../components/Button';
import $ from 'jquery';

export function FormEditStrekning(props) {
    const [strekning, setStrekning] = useState();
    const [tid, setTid] = useState();
    const [pris, setPris] = useState();
    const [errorStrekning, setErrorStrekning] = useState("");
    const [errorTid, setErrorTid] = useState("");
    const [errorPris, setErrorPris] = useState("");
    const validStrekning = new RegExp('^[A-ZÆØÅ][a-zæøå]+ - [A-ZÆØÅ][a-zæøå]+$');
    const validPris = new RegExp('^[0-9]+$');

    const id = window.location.search.substring(1);

    function edit() {
        const nyStrekning = {
            id: id,
            navn: strekning,
            tid: tid,
            pris: pris
        };
        $.post("strekning/Endre", nyStrekning, function (OK) {
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

        if (tid === undefined) {
            setErrorTid('Du må velge tid');
            e.preventDefault();
            error = true;
        } else {
            setErrorTid('');
        }

        if (!validPris.test(pris)) {
            setErrorPris('Pris må kun inneholde tall');
            e.preventDefault();
            error = true;
        } else {
            setErrorPris('');
        }

        if (!error) {
            edit();
        }
    }
    console.log(props.textTid);

    return (
        <form action="/departures" onSubmit={validateForm}>
            <InputField testing={props.textStrekning} errorMsg={errorStrekning} state={setStrekning} name="Strekning" InputField="Strekning: " />
            <Timepicker oldTime={props.textTid} errorMsg={errorTid} state={setTid} name="Tid" label="Tid: " />
            <InputField testing={props.textPris} errorMsg={errorPris} state={setPris} name="Pris" InputField="Pris: " />
            <Button text="Endre" />
        </form>
    );
}