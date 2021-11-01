import React, { useEffect, useState } from 'react';
import { DeleteButton } from '../components/DeleteButton';
import $ from 'jquery';
import { EditButton } from './EditButton';

export function HentAlle() {
    const [ut, setUt] = useState();
    const formatButtons = {
        display: 'flex'
    };
    useEffect(() => {
        $.getJSON("strekning/hentAlle", function (strekninger) {
            formaterStrekninger(strekninger);
        });
    }, [])
    

    function formaterStrekninger(strekninger) {
        let arr = [];
        for (let strekning of strekninger) {
            arr.push(<tr>
                <th scope="row">{strekning.id}</th>
                <td>{strekning.navn}</td>
                <td>{strekning.pris}</td>
                <td><div style={formatButtons}><DeleteButton id={strekning.id} /><EditButton id={strekning.id} /></div></td>
            </tr>);
        }
        setUt(arr);
    }
    return (
        <div id="strekningene">
            <table className="table">
                <thead>
                    <tr className="table-primary">
                        <th scope="col">#</th>
                        <th scope="col">Strekning:</th>
                        <th scope="col">Pris:</th>
                        <th scope="col">Knapper:</th>
                    </tr>
                </thead >
                <tbody>
                    { ut }
                </tbody>
            </table>
        </div>
    );
}