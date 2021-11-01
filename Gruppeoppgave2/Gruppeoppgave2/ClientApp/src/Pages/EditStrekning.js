import React, {useState} from 'react';
import { FormStrekning } from '../components/FormStrekning';
import $ from 'jquery';

export function EditStrekning() {
    const [id, setId] = useState();
    const [strekningen, setStrekningen] = useState();
    const [pris, setPris] = useState();

    
    const test = window.location.search.substring(1);
    $.get("strekning/hentEn?" + test, function (strekning) {
        setId(strekning.id);
        setStrekningen(strekning.navn);
        setPris(strekning.pris);
    });

    

    return (
        <div>
            <FormStrekning textStrekning={strekningen} textPris={pris} />
        </div>
    );

}