import React from 'react';
import $ from 'jquery';

export function DeleteButton(props) {

    function deleteStrekning() {
        $.get("strekning/slett?id=" + props.id, function (OK) {
            if (!OK) {
                $("#feil").html("Feil i db - vennligst forsøk igjen");
            }
        });
    }

    return (
        <div>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"></link>
            <button onClick={deleteStrekning} className="deleteButton btn btn-outline-danger"><i class="deleteIcon fa fa-trash"></i></button>
        </div>
    );
}