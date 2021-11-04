import React, { useState } from 'react';
import { InputField } from '../components/InputField';
import { InputFieldPassword } from '../components/InputFieldPassword';
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
                sessionStorage.setItem('loggedIn', username);
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
        <div className="fit-content m-auto">
            <form onSubmit={checklogin}>
                <InputField state={setUsername} name="Brukernavn" InputField="Brukernavn: " />
                <InputFieldPassword errorMsg={error} state={setPassword} name="Passord" InputField="Passord: " />
                <Button text="Logg Inn" />
            </form>
        </div>
    );
}