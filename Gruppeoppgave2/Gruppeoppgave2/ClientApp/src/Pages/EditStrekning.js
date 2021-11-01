import React, {useState} from 'react';
import { FormStrekning } from '../components/FormStrekning';
import $ from 'jquery';

export function EditStrekning() {
    const [strekningen, setStrekningen] = useState();
    const [pris, setPris] = useState();

    useState(() => {
        const test = window.location.search.substring(1);
        $.get("strekning/hentEn?id=" + test, function (strekning) {
            setStrekningen(strekning.navn);
            setPris(strekning.pris);
        });
    }, []);

    

    return (
        <div>
            <FormStrekning textStrekning={strekningen} textPris={pris} />
        </div>
    );

}