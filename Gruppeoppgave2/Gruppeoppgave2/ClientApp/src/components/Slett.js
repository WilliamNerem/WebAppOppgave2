import React from 'react';
import $ from 'jquery';

export function Slett(props) {

    function slettStrekning() {
        $.get("strekning/slett?id=" + props.id, function (OK) {
            if (OK) {
                location.reload();
            }
            else {
                $("#feil").html("Feil i db - vennligst forsøk igjen");
            }
        });
    }
}