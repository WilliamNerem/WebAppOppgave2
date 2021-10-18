import React from 'react';
import $ from 'jquery';

export function HentAlle() {

    function hentAlleStrekninger() {
        $.getJSON("strekning/hentAlle", function (strekninger) {
            formaterStrekninger(strekninger);
        });
    }

    function formaterStrekninger(strekninger) {
        let ut = " <table class='table'>" +
            "<thead>" +
            "<tr class='table-primary'>" +
            "<th scope='col'>#</th>" +
            "<th scope='col'>Strekning:</th>" +
            "<th scope='col'>Pris:</th>" +
            "</tr>" +
            "</thead >" +
            "<tbody>";
        for (let strekning of strekninger) {
            ut += "<tr>" +
                "<th scope='row'>" + strekning.id + "</th>" +
                "<td>" + strekning.navn + "</td>" +
                "<td>" + strekning.pris + "</td>" +
                "</tr>";
        }
        ut += "</tbody>" +
            "</table >";
        document.getElementById("strekningene").innerHTML = ut;
    }

    hentAlleStrekninger();

    return (
        <div id="strekningene"></div>
    );
}