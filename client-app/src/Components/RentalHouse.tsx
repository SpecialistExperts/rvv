import { Button, TextField } from "@material-ui/core";
import React, { ComponentState } from "react";
import { Component } from "react";
import "./RentalHouse.css";

interface IProps {}

interface IState {
  huisnummer : string
  postcode : string
  straatnaam : string
  plaatsnaam : string
  [key: string] : string | boolean
}

export class RentalHouse extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      huisnummer: "",
      postcode: "",
      straatnaam: "",
      plaatsnaam: "",
    };

    this.handleChange = this.handleChange.bind(this);
    this.getAdress = this.getAdress.bind(this);
  }

  handleChange(e: any) {
    var name = e.target.name;
    const value = name === "validinfo" ? e.target.checked : e.target.value;
    this.setState({ [name]: value }, () => console.log(this.state));
  }

  getAdress() {
      fetch(
        "https://api.overheid.io/bag?filters[postcode]="+ this.state.postcode +  "&filters[huisnummer]="+ this.state.huisnummer + "&ovio-api-key=4e82a48537b230fa5d216eeabefc6f771da47d511ffd4d778d7c899dc036db53"
      ).then((response) => response.json())
        .then((data) =>
          this.setState({
            straatnaam: data._embedded.adres[0].openbareruimte,
            plaatsnaam: data._embedded.adres[0].woonplaats,
          }, () => console.log(this.state))
        );
        
  }

  render() {

    let renderAdress = () => {
      if(this.state.straatnaam != ""){
        return (
        <div>
          <h3>Adres (Automatisch opgehaald)</h3>
          {this.state.straatnaam} {this.state.huisnummer} <br></br>
          {this.state.postcode} {this.state.plaatsnaam}
        </div>
        )
      }
    }

    return (
      <div>
        <h3>Voor welke woning of woonboot doet u een aanvraag?</h3>
        <form noValidate autoComplete="off">
          <TextField
            id="outlined-basic"
            label="postcode"
            variant="outlined"
            name="postcode"
            onChange={this.handleChange}
            disabled={this.state.straatnaam != ""}
          />
          <TextField
            id="outlined-basic"
            label="huisnummer"
            variant="outlined"
            name="huisnummer"
            onChange={this.handleChange}
            disabled={this.state.straatnaam != ""}
          />
        </form>
        <Button variant="contained" onClick={this.getAdress} disabled={!this.state.huisnummer || !this.state.postcode}>
          Zoek adres
        </Button>
        {renderAdress()}
      </div>
    );
  }
}
