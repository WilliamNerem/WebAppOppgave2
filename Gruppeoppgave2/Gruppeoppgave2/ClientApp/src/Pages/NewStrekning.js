import React from 'react';
import { FormStrekning } from '../components/FormStrekning';
import $ from 'jquery';

export function NewStrekning() {
    const user = sessionStorage.getItem('loggedIn');
    if (user === null) {
        window.location.href = '/';
    }

    

    const add = (strekning, tid, pris) => {
        const nyStrekning = {
            navn: strekning,
            tid: tid,
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

    return (
        <div>
            <FormStrekning dbFunction={add} btnText="Legg til" />
        </div>
    );

}