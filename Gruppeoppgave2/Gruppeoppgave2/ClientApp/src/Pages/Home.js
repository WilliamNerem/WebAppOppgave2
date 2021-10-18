import React, { useState } from 'react';
import { InputField } from '../components/InputField';
import { Button } from '../components/Button';


export function Home() {
    const [username, setUsername] = useState();
    const [password, setPassword] = useState();

    function handleSubmit(e) {
        if ((username !== "admin") || (password !== "admin")) {
            e.preventDefault();
        }
    }

    return (
        <form action="/departures" onSubmit={handleSubmit}>
            <InputField state={setUsername} name="Brukernavn" InputField="Brukernavn: " />
            <InputField state={setPassword} name="Passord" InputField="Passord: " />
            <Button text="Logg Inn" />
        </form>
    );
}