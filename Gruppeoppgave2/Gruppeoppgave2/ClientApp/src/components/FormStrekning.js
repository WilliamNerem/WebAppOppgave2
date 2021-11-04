import React, { useState } from 'react';
import { InputField } from '../components/InputField';
import { Timepicker } from '../components/Timepicker';
import { Button } from '../components/Button';

export function FormStrekning(props) {
    const [strekning, setStrekning] = useState();
    const [tid, setTid] = useState();
    const [pris, setPris] = useState();
    const [errorStrekning, setErrorStrekning] = useState("");
    const [errorTid, setErrorTid] = useState("");
    const [errorPris, setErrorPris] = useState("");
    const validStrekning = new RegExp('^[A-ZÆØÅ][a-zæøå]+ - [A-ZÆØÅ][a-zæøå]+$');
    const validPris = new RegExp('^[0-9]{4}$');


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
            setErrorPris('Pris må kun inneholde tall, maks 4 siffer');
            e.preventDefault();
            error = true;
        } else {
            setErrorPris('');
        }

        if (!error) {
            props.dbFunction(strekning, tid, pris);
        }
    }

    return (
        <form action="/departures" onSubmit={validateForm}>
            <InputField text={props.strekningText} errorMsg={errorStrekning} state={setStrekning} name="Strekning" InputField="Strekning: " />
            <Timepicker oldTid={props.tidText} errorMsg={errorTid} state={setTid} name="Tid" label="Tid: " />
            <InputField text={props.prisText} errorMsg={errorPris} state={setPris} name="Pris" InputField="Pris: " />
            <Button text={props.btnText} />
        </form>
    );
}