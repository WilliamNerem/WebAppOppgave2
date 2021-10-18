import React from 'react';
import $ from 'jquery';
import { HentAlle } from '../components/HentAlle';

export function Departures() {

    return (
        <HentAlle/>
        );
}

// -- DETTE ER DEFAULT STYLE FOR TABLE, IKKE SLETT!! --
    //return (
    //    <div>
    //        <table className='table'>
    //            <thead>
    //                <tr className='table-primary'>
    //                    <th scope="col">#</th>
    //                    <th scope='col'>Strekning:</th>
    //                    <th scope='col'>Pris:</th>
    //                </tr>
    //            </thead>
    //            <tbody>
    //                <tr>
    //                    <th scope="row">1</th>
    //                    <td>Oslo-Kiel</td>
    //                    <td>1999 kr</td>
    //                </tr>
    //                <tr>
    //                    <th scope="row">2</th>
    //                    <td>Kiel-Oslo</td>
    //                    <td>1999 kr</td>
    //                </tr>
    //            </tbody>
    //        </table>
    //    </div>
    //);
//};