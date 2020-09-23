import { Component } from "react";
import React from "react";


interface IState {
    response : string
}

interface IProps { 
    personalData : {
        voornamen : string
        tussenvoegsel : string
        achternaam : string
        straat : string
        huisnummer : string
        toevoeging : string
        postcode : string
        plaats : string
        telefoonnummer : string
        email : string
      }
      rentaldata : {
        huisnummer : string
        postcode : string
        straatnaam : string
        plaatsnaam : string
      }
    }

export class GetNumber extends Component<IProps, IState> {
    constructor(props: IProps) {
      super(props);
      this.state = {
          response : ""
      };
    }

    componentDidMount() {
        const requestoptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'},
            body: JSON.stringify({
                Name: ``,
                BSN: '547685765',
                Adress: `${this.props.personalData.straat} ${this.props.personalData.huisnummer}`,
                Email: `${this.props.personalData.email}`,
                PhoneNumber: `${this.props.personalData.telefoonnummer}`,
                ValidInfo: 'true',
                Gemeente: 'Rotterdam',
                AdressToRegister: `${this.props.rentaldata.straatnaam} ${this.props.rentaldata.huisnummer}`,
            })
        };
        console.log(requestoptions.body);
        fetch('http://localhost:5000/api/owners', requestoptions)
        .then(response => response.text())
        .then(data => this.setState({response : data}, () => console.log(this.state)))
    }

    render(){
        return (
            <div>
                <h1>Uw registratienummer is:</h1>
                <p>{this.state.response}</p>
            </div>
        )
    }
}