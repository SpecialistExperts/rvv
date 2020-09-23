import { Checkbox } from "@material-ui/core";
import React from "react";
import { Component } from "react";
import './Resume.css'

interface IProps {
  callback : () => void;
  personaldata: {
    voornamen: string;
    tussenvoegsel: string;
    achternaam: string;
    straat: string;
    huisnummer: string;
    toevoeging: string;
    postcode: string;
    plaats: string;
    telefoonnummer: string;
    email: string;
  };
  rentaldata: {
    huisnummer: string;
    postcode: string;
    straatnaam: string;
    plaatsnaam: string;
  };
}

interface IState {}

export class Resume extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {};
  }
  render() {
    return (
      <div>
        <h3>Persoonsgegevens</h3>
        <h4>Burgerservicenummer</h4>
        <p>0123456789</p>
        <h4>Voornamen</h4>
        <p>{this.props.personaldata.voornamen}</p>
        <h4>Tussenvoegsel</h4>
        <p>{this.props.personaldata.tussenvoegsel}</p>
        <h4>Achternaam</h4>
        <p>{this.props.personaldata.achternaam}</p>
        <h4>Adres</h4>
        <p>{this.props.personaldata.straat} {this.props.personaldata.huisnummer}</p>
        <h4>Telefoonnummer</h4>
        <p>{this.props.personaldata.telefoonnummer}</p>
        <h4>E-mailadres</h4>
        <p>{this.props.personaldata.email}</p>

        <h3>Adresgegevens vakantiehuis</h3>
        <h4>Postcode</h4>
        <p>{this.props.rentaldata.postcode}</p>
        <h4>Woonplaats</h4>
        <p>{this.props.rentaldata.plaatsnaam}</p>
        <h4>Adres</h4>
        <p>{this.props.rentaldata.straatnaam} {this.props.rentaldata.huisnummer}</p>
        <Checkbox
              color="default"
              inputProps={{ "aria-label": "checkbox with default color" }}
              name="validinfo"
              onClick={() => this.props.callback()}
            />
            Gegevens zijn correct
      </div>
    );
  }
}
