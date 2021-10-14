import React, { Component } from 'react';
import Button from './Button';
import { InputField } from './InputField';

export class Home extends Component {
    static displayName = Home.name;

  render () {
    return (
        <div>
            <InputField name="Brukernavn" InputField="Brukernavn: " />
            <InputField name="Passord" InputField="Passord: " />
            <Button />
      </div>
    );
  }
}
