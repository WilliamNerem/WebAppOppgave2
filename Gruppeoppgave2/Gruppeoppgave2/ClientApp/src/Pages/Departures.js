import React from 'react';
import { AddStrekningButton } from '../components/AddStrekningButton';
import { HentAlle } from '../components/HentAlle';

export function Departures() {

    return (
        <div>
            <HentAlle />
            <AddStrekningButton />
        </div>
        );

}