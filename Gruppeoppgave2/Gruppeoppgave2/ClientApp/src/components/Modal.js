import React from 'react';

const Modal = (props) => {

    return (
        <div className="modal" id="exampleModal" tabIndex="-1">
            <div className="modal-dialog modal-dialog-centered">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title" id="exampleModalLabel">{props.title}</h5>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body">
                        {props.body}
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{props.dismissBtn}</button>
                        <button type="button" className="btn btn-primary" onClick={props.continue} data-bs-dismiss="modal">{props.continueBtn}</button>
                    </div>
                </div>
            </div>
        </div>
        )
}

export default Modal;