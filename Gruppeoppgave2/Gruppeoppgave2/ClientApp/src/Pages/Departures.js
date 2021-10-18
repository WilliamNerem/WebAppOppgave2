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

// -- DETTE ER DEFAULT STYLE FOR TABLE, IKKE SLETT!! --
    //return (
    //    <div>
    //        <table className='table'>
    //            <thead>
    //                <tr className='table-primary'>
    //                    <th scope="col">#</th>
    //                    <th scope='col'>Strekning:</th>
    //                    <th scope='col'>Pris:</th>
    //                </tr>
    //            </thead>
    //            <tbody>
    //                <tr>
    //                    <th scope="row">1</th>
    //                    <td>Oslo-Kiel</td>
    //                    <td>1999 kr</td>
    //                </tr>
    //                <tr>
    //                    <th scope="row">2</th>
    //                    <td>Kiel-Oslo</td>
    //                    <td>1999 kr</td>
    //                </tr>
    //            </tbody>
    //        </table>
    //    </div>
    //);
//};