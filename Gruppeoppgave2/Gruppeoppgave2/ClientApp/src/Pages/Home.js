import React, { useState } from 'react';
import { InputField } from '../components/InputField';
import { Button } from '../components/Button';
import $ from 'jquery';



export function Home() {
    const [username, setUsername] = useState();
    const [password, setPassword] = useState();

    function handleSubmit(e) {
        if ((username !== "admin") || (password !== "admin")) {
            e.preventDefault();
        }
    }

    function login(e) {
        const admin = {
            brukernavn: username,
            passord: password
        };
        console.log(admin.brukernavn);
        console.log(admin.passord);
        $.post("Strekning/Logginn", admin, function (OK) {
            if (OK) {
                window.location.href = '/departures'
            }
            else {
                e.preventDefault();
            }
        });
        
    }
    function stoplogin(e) {
        e.preventDefault();
    }

    return (
        <form onSubmit={login}>
            <InputField state={setUsername} name="Brukernavn" InputField="Brukernavn: " />
            <InputField state={setPassword} name="Passord" InputField="Passord: " />
            <Button text="Logg Inn" />
        </form>
    );
}