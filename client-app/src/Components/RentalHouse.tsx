import { Button, TextField } from "@material-ui/core";
import React from "react";
import { Component } from "react";
import "./RentalHouse.css";

interface IProps {
  callback: () => void
  rentalData : {
    huisnummer: string;
    postcode: string;
    straatnaam: string;
    plaatsnaam: string;
  }
}

interface IState {
  huisnummer: string;
  postcode: string;
  straatnaam: string;
  plaatsnaam: string;
  [key: string]: string | number;
  activeStep: number;
  error: string;
}

export class RentalHouse extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      huisnummer: "",
      postcode: "",
      straatnaam: "",
      plaatsnaam: "",
      activeStep: 0,
      error: ""
    };

    this.handleback = this.handleback.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.getAdress = this.getAdress.bind(this);
  }

  componentDidMount() {
    this.setState({
      huisnummer:
        this.props.rentalData.huisnummer.length > 0
          ? this.props.rentalData.huisnummer
          : "",
      postcode:
        this.props.rentalData.postcode.length > 0
          ? this.props.rentalData.postcode
          : "",
      plaatsnaam:
        this.props.rentalData.plaatsnaam.length > 0
          ? this.props.rentalData.plaatsnaam
          : "",
      straatnaam:
        this.props.rentalData.straatnaam.length > 0
          ? this.props.rentalData.straatnaam
          : ""})};

  handleChange(e: any) {
    var name = e.target.name;
    const value = name === "validinfo" ? e.target.checked : e.target.value;
    this.setState({ [name]: value }, () => console.log(this.state));
  }

  getAdress() {
    fetch(
      "https://api.overheid.io/bag?filters[postcode]=" +
        this.state.postcode +
        "&filters[huisnummer]=" +
        this.state.huisnummer +
        "&ovio-api-key=4e82a48537b230fa5d216eeabefc6f771da47d511ffd4d778d7c899dc036db53"
    )
      .then((response) => response.json())
      .then((data) =>
        this.setState(
          {
            straatnaam: data._embedded.adres[0].openbareruimte,
            plaatsnaam: data._embedded.adres[0].woonplaats,
            activeStep: this.state.activeStep + 1,
            error: "",
            
          },
          () => this.props.callback()
        )
      ).catch(() => this.setState({ error : "Er is geen adres gevonden met deze data."}));
  }

  handleback() {
    this.setState({
      activeStep: this.state.activeStep - 1,
      postcode: "",
      huisnummer: "",
    });
  }

  renderswitch(x: number) {
    switch (x) {
      case 0:
        return (
          <div>
            <Button
              className= "search_button"
              variant="contained"
              onClick={this.getAdress}
              disabled={/^[1-9][0-9]{3} ?[A-Z]{2}$/.test(this.state.postcode) && /^\d+$/.test(this.state.huisnummer) ? false : true}
            >
              Zoek adres
            </Button>
            <p className="error_message">{this.state.error}</p>
          </div>
        );
      case 1:
        if (this.state.straatnaam !== "") {
          return (
            <div>
              <h3>Adres (Automatisch opgehaald)</h3>
              <p className="adres_message">{this.state.straatnaam} {this.state.huisnummer} <br></br>
              {this.state.postcode} {this.state.plaatsnaam}</p>
              <div>
                <Button variant="contained" onClick={this.handleback}>
                  Wijzig adres
                </Button>
              </div>
            </div>
          );
        }
    }
  }

  render() {
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
            disabled={this.state.activeStep === 1}
            value={this.state.postcode}
            error={
              /^[1-9][0-9]{3} ?[A-Z]{2}$/.test(this.state.postcode) ||
              !this.state.postcode
                ? false
                : true
            }
            helperText={
              /^[1-9][0-9]{3} ?[A-Z]{2}$/.test(this.state.postcode) ||
              !this.state.postcode
                ? ""
                : "Voer een geldige postcode in (1234AB)"
            }
          />
          <TextField
            id="outlined-basic"
            label="huisnummer"
            variant="outlined"
            name="huisnummer"
            onChange={this.handleChange}
            disabled={this.state.activeStep === 1}
            value={this.state.huisnummer}
            error={
              /^\d+$/.test(this.state.huisnummer) || !this.state.huisnummer
                ? false
                : true
            }
            helperText={
              /^\d+$/.test(this.state.huisnummer) || !this.state.huisnummer
                ? ""
                : "Voer een geldig huisnummer in"
            }
          />
        </form>
        {this.renderswitch(this.state.activeStep)}
      </div>
    );
  }
}
