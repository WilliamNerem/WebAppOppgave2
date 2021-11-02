import React, { useState } from 'react';
import { InputField } from '../components/InputField';
import { Button } from '../components/Button';
import $ from 'jquery';



export function Login() {
    const [username, setUsername] = useState();
    const [password, setPassword] = useState();
    const [error, setError] = useState("");

    function login(e) {
        const admin = {
            brukernavn: username,
            passord: password
        };
        
        $.post("Strekning/Logginn", admin, function (OK) {
            if (OK) {
                window.location.href = '/departures'
                setError("");
            }
            else {
                setError("Feil brukernavn eller passord");
                return false;
            }
        });

    }
    function checklogin(e) {
        if (!login()) {
            e.preventDefault();
        }
    }

    return (
        <form onSubmit={checklogin}>
            <InputField state={setUsername} name="Brukernavn" InputField="Brukernavn: " />
            <InputField errorMsg={error} state={setPassword} name="Passord" InputField="Passord: " />
            <Button text="Logg Inn" />
        </form>
    );
}