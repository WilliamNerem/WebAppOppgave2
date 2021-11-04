import React from 'react';

export function EditButton(props) {

    function edit() {
        window.location.href = '/editStrekning?' + props.id;
    }

    return (
        <div>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"></link>
            <button onClick={edit} className="editButton btn btn-outline-warning"><i class="editIcon fa fa-pencil"></i></button>
        </div>
    );
}