import React, { Component } from 'react';

export class Departures extends Component {
    static displayName = Departures.name;

    //legge til, slette og endre strekninger, avganger og priser

    render() {
        return (
            <div>
                <table className='table'>
                    <thead>
                        <tr>
                            <th scope='col'>Strekning:</th>
                            <th scope='col'>Pris:</th>
                        </tr>
                    </thead>
                    <body>
                        <tr>
                            <td>Oslo-Kiel</td>
                            <td>1999 kr</td>
                        </tr>
                        <tr>
                            <td>Kiel-Oslo</td>
                            <td>1999 kr</td>
                        </tr>
                    </body>
                </table>
            </div>
        );
    }
}