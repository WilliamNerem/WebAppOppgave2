import React from 'react';
import $ from 'jquery';

export function Endre() {

    function hentEn() {
        const id = window.location.search.substring(1);
        $.get("strekning/hentEn?" + id, function (strekning) {
            $("#id").val(strekning.id);
            $("#navn").val(strekning.navn);
            $("#pris").val(strekning.pris);
        });
    }

    function endreKunde() {
        const strekning = {
            id: $("#id").val(),
            navn: $("#navn").val(),
            pris: $("#pris").val()
        };
        $.post("strekning/Endre", strekning, function (OK) {
            if (OK) {
                window.location.href = 'index.html';
            }
            else {
                $("#feil").html("Feil i db, vennligst forsøk igjen");
            }
        });
    }


}