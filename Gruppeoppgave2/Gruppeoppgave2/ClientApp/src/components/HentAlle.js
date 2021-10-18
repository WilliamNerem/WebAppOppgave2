import React from 'react';
import $ from 'jquery';

export function HentAlle() {

    function hentAlleStrekninger() {
        $.getJSON("strekning/hentAlle", function (strekninger) {
            formaterStrekninger(strekninger);
        });
    }

    function formaterStrekninger(strekninger) {
        let ut = " <table className='table'>" +
            "<thead>" +
            "<tr>" +
            "<th scope='col'>Strekning:</th>" +
            "<th scope='col'>Pris:</th>" +
            "</tr>" +
            "</thead >" +
            "<body>";
        for (let strekning of strekninger) {
            ut += "<tr>" +
                "<td>" + strekning.navn + "</td>" +
                "<td>" + strekning.pris + "</td>" +
                "</tr>";
        }
        ut += "</body>" +
            "</table >";
        document.getElementById("strekningene").innerHTML = ut;
    }

    hentAlleStrekninger();

    return (
        <div id="strekningene"></div>
    );
}