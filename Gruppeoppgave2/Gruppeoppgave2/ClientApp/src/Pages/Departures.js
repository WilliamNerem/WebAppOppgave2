import React, { Component } from 'react';
import $ from 'jquery';
let ut = "";

export function Departures() {

    function hentAlleStrekninger() {
        $.getJSON("strekning/hentAlle", function (strekninger) {
            formaterStrekninger(strekninger);
            console.log(strekninger)
        });
    }

    function formaterStrekninger(strekninger) {
        ut += " <table className='table'>" +
            "< thead >" +
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
    }
    hentAlleStrekninger();
    console.log(ut)
    return (
        <div id="strekningene"> {ut} </div>
    );
}