import React from 'react';
import $ from 'jquery';

export function EditButton(props) {

    function hentEn() {
        const id = window.location.search.substring(1);
        $.get("strekning/hentEn?" + id, function (strekning) {
            $("#id").val(strekning.id);
            $("#navn").val(strekning.navn);
            $("#pris").val(strekning.pris);
        });
    }

    function editStrekning() {
        const strekning = {
            id: $("#id").val(),
            navn: $("#navn").val(),
            pris: $("#pris").val()
        };
        $.post("strekning/Endre", strekning, function (OK) {
            if (!OK) {
                $("#feil").html("Feil i db, vennligst forsøk igjen");
            }
        });
    }

    return (
        <div>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"></link>
            <button onClick={editStrekning} className="ediButton btn btn-outline-warning"><i class="editIcon fa fa-pencil"></i></button>
        </div>
    );
}