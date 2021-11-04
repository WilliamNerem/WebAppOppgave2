import React, {useState} from 'react';
import { FormStrekning } from '../components/FormStrekning';
import $ from 'jquery';

export function EditStrekning() {
    let oldStrekning;
    let oldTid;
    let oldPris;
    const [ut, setUt] = useState();
    const id = window.location.search.substring(1);

    const user = sessionStorage.getItem('loggedIn');
    if (user === null) {
        window.location.href = '/';
    }

    useState(async() => {
        const test = window.location.search.substring(1);
        await $.get("strekning/hentEn?id=" + test, function (strekningen) {
            oldStrekning = strekningen.navn;
            oldTid = strekningen.tid;
            oldPris = strekningen.pris;
            render();
        });
    }, []);

    function render() {
        setUt(<FormStrekning dbFunction={edit} btnText="Endre" strekningText={oldStrekning} tidText={oldTid} prisText={oldPris} />);
    }

    const edit = (strekning, tid, pris) => {
        const nyStrekning = {
            id: id,
            navn: strekning,
            tid: tid,
            pris: pris
        };
        $.post("strekning/Endre", nyStrekning, function (OK) {
            if (!OK) {
                $("#feil").html("Feil i db, vennligst forsøk igjen");
            }
        })
            .fail(function (feil) {
                if (feil.status == 401) {
                    window.location.href = "/"
                }
            });
    }

    return (
        <div className="fit-content m-auto">
            {ut}
        </div>
    );

}