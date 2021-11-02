import React from 'react';
import Modal from './Modal';
import $ from 'jquery';

export function DeleteButton(props) {

    const modalTitle = "Er du sikker?";
    const modalBodyText = "Du er i ferd med å slette denne strekningen. Er du sikker på at du vil fortsette?";
    const modalDismissText = "Avbryt";
    const modalContinueText = "Fortsett";

    const deleteStrekning = () => {
        $.get("strekning/slett?id=" + props.id, function (OK) {
            if (!OK) {
                $("#feil").html("Feil i db - vennligst forsøk igjen");
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
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"></link>
            <button className="deleteButton btn btn-outline-danger" data-bs-toggle="modal" data-bs-target="#exampleModal"><i class="deleteIcon fa fa-trash"></i></button>
            <Modal continue={deleteStrekning} title={modalTitle} body={modalBodyText} dismissBtn={modalDismissText} continueBtn={modalContinueText} />
        </div>
    );
}