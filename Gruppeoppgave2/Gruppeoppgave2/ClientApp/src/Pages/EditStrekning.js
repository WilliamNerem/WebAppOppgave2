import React, {useState} from 'react';
import { FormEditStrekning } from '../components/FormEditStrekning';
import $ from 'jquery';

export function EditStrekning() {
    let strekningen;
    let tid;
    let pris;
    const [ut, setUt] = useState();

    const user = sessionStorage.getItem('loggedIn');
    if (user === null) {
        window.location.href = '/';
    }

    useState(async() => {
        const test = window.location.search.substring(1);
        await $.get("strekning/hentEn?id=" + test, function (strekning) {
            strekningen = strekning.navn;
            tid = strekning.tid;
            pris = strekning.pris;
            render();
        });
    }, []);

    function render() {
        setUt(<FormEditStrekning textStrekning={strekningen} textPris={pris} textTid={tid} />);
    }

    return (
        <div>
            {ut}
        </div>
    );

}