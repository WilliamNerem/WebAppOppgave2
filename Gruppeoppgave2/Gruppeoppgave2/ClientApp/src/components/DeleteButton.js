import React from 'react';
import $ from 'jquery';

export function DeleteButton(props) {

    function slettStrekning() {
        $.get("strekning/slett?id=" + props.id);
    }

    return (
        <div>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"></link>
            <button onClick={slettStrekning} className="deleteButton btn btn-outline-danger"><i class="deleteIcon fa fa-trash"></i></button>
        </div>
    );
}