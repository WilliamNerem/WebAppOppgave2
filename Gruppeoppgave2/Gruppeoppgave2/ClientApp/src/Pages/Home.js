import React, { Component } from 'react';
import { InputField } from '../components/InputField';
import { Button } from '../components/Button';

let uname = "";
let pwd = "";

export class Home extends Component {

    static displayName = Home.name;

    username(value) {
        console.log(value);
        uname = value;
    }

    password(value) {
        pwd = value;
    }

    validateAdmin() {
        console.log(uname);
        if ((uname !== "hei") || (pwd !== "123")) {
            return false;
        } 
    }
    

  render () {
      return (
          <form action="/departures" onSubmit={this.validateAdmin()}>
              <InputField onChange={this.username} name="Brukernavn" InputField="Brukernavn: " />
              <InputField onChange={this.password} name="Passord" InputField="Passord: " />
            <Button text="Logg Inn" />
      </form>
    );
  }
}
