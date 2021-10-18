import React from 'react';
import $ from 'jquery';

export function Slett() {

    function slettStrekning(id) {
        $.get(url, function (OK) {
            if (OK) {
                window.location.href = 'index.html';
            }
            else {
                $("#feil").html("Feil i db - vennligst forsøk igjen");
            }
        });
    }
}