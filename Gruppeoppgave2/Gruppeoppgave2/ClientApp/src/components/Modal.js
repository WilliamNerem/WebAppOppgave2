import React from 'react';

const Modal = () => {

    return (
        <div className="modal" id="exampleModal" tabIndex="-1">
            <div className="modal-dialog modal-dialog-centered">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title" id="exampleModalLabel">Er du sikker?</h5>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body">
                            Du er i ferd med å slette denne strekningen. Er du sikker på at du vil fortsette?
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Avbryt</button>
                        <button type="button" className="btn btn-primary">Fortsett</button>
                    </div>
                </div>
            </div>
        </div>
        )
}

export default Modal;