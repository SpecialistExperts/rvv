import { Checkbox, TextField } from "@material-ui/core";
import { TransferWithinAStationSharp } from "@material-ui/icons";
import React, { Component } from "react";
import "./PersonalData.css";

interface IProps {
  callbackOn: () => void;
  callbackOff: () => void;
  isvalid: boolean;
  personalData: {
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
    checked : boolean
  };
}

interface IState {
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
  [key: string]: string | boolean;
  checked : boolean;
  isValid: boolean;
}

export class PersonalData extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      voornamen: "",
      tussenvoegsel: "",
      achternaam: "",
      straat: "",
      huisnummer: "",
      toevoeging: "",
      postcode: "",
      plaats: "",
      telefoonnummer: "",
      email: "",
      checked : false,
      isValid: true,
    };

    this.handleChange = this.handleChange.bind(this);
  }

  componentDidMount() {
    this.setState({
      voornamen:
        this.props.personalData.voornamen.length > 0
          ? this.props.personalData.voornamen
          : "",
      tussenvoegsel:
        this.props.personalData.tussenvoegsel.length > 0
          ? this.props.personalData.tussenvoegsel
          : "",
      achternaam:
        this.props.personalData.achternaam.length > 0
          ? this.props.personalData.achternaam
          : "",
      straat:
        this.props.personalData.straat.length > 0
          ? this.props.personalData.straat
          : "",
      huisnummer:
        this.props.personalData.huisnummer.length > 0
          ? this.props.personalData.huisnummer
          : "",
      toevoeging:
        this.props.personalData.toevoeging.length > 0
          ? this.props.personalData.toevoeging
          : "",
      postcode:
        this.props.personalData.postcode.length > 0
          ? this.props.personalData.postcode
          : "",
      plaats:
        this.props.personalData.plaats.length > 0
          ? this.props.personalData.plaats
          : "",
      telefoonnummer:
        this.props.personalData.telefoonnummer.length > 0
          ? this.props.personalData.telefoonnummer
          : "",
      email:
        this.props.personalData.email.length > 0
          ? this.props.personalData.email
          : "",
      checked : 
        this.props.personalData.checked === true ? true : false
    });
    this.emptyCheck();
  }

  handleChange(e: any) {
    var name = e.target.name;
    const value = name === "validinfo" ? e.target.checked : e.target.value;
    if(value === e.target.checked){
      this.setState({checked : value}) 
    }
    this.setState({ [name]: value }, () => this.emptyCheck());
  }

  errorCheck(){
    if(
      /^[A-Za-z\s]+$/.test(this.state.voornamen) &&
      /^[A-Za-z\s]+$/.test(this.state.achternaam) &&
      /^[A-Za-z\s]+$/.test(this.state.straat) &&
      /^\d+$/.test(this.state.huisnummer) &&
      /^[1-9][0-9]{3} ?[A-Z]{2}$/.test(this.state.postcode) && 
      /^[A-Za-z\s]+$/.test(this.state.plaats) &&
      /^((\+|00(\s|\s?\-\s?)?)31(\s|\s?\-\s?)?(\(0\)[\-\s]?)?|0)[1-9]((\s|\s?\-\s?)?[0-9])((\s|\s?-\s?)?[0-9])((\s|\s?-\s?)?[0-9])\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]$/.test(
        this.state.telefoonnummer) &&
      /\S+@\S+\.\S+/.test(this.state.email)
    ) {
      return true;
    } else {
      return false
    }
  }

  emptyCheck() {
    if (
      this.state.voornamen !== "" &&
      this.state.achternaam !== "" &&
      this.state.straat !== "" &&
      this.state.huisnummer !== "" &&
      this.state.postcode !== "" &&
      this.state.plaats !== "" &&
      this.state.telefoonnummer !== "" &&
      this.state.email !== "" &&
      this.state.checked
    ) {
      this.setState({isValid : true})
      this.errorCheck() ? this.props.callbackOn() : this.props.callbackOff()
      
    } 
    if(this.state.isValid === true)
    {
      if(
      this.state.voornamen === "" ||
      this.state.achternaam === "" ||
      this.state.straat === "" ||
      this.state.huisnummer === "" ||
      this.state.postcode === "" ||
      this.state.plaats === "" ||
      this.state.telefoonnummer === "" ||
      this.state.email === "" ||
      !this.state.checked){
        this.props.callbackOff()
        this.setState({isValid : false})
      }
    } 
  }

  render() {
    return (
      <div className="personal_data_div">
        <h1>Persoonsgegevens</h1>
        <form>
          <TextField
            id="outlined-basic"
            label="Voornamen"
            variant="outlined"
            name="voornamen"
            onChange={this.handleChange}
            helperText={
              /^[A-Za-z\s]+$/.test(this.state.voornamen) ||
              !this.state.voornamen
                ? ""
                : "Voer een geldige naam in"
            }
            value={this.state.voornamen}
            error={
              /^[A-Za-z\s]+$/.test(this.state.voornamen) ||
              !this.state.voornamen
                ? false
                : true
            }
          />
          <TextField
            id="outlined-basic"
            label="Tussenvoegsel"
            variant="outlined"
            name="tussenvoegsel"
            error={
              /^[A-Za-z\s]+$/.test(this.state.tussenvoegsel) ||
              !this.state.tussenvoegsel
                ? false
                : true
            }
            helperText={
              /^[A-Za-z\s]+$/.test(this.state.tussenvoegsel) ||
              !this.state.tussenvoegsel
                ? ""
                : "Voer een geldig tussenvoegsel in"
            }
            onChange={this.handleChange}
            value={this.state.tussenvoegsel}
          />
          <TextField
            id="outlined-basic"
            label="Achternaam"
            variant="outlined"
            name="achternaam"
            error={
              /^[A-Za-z\s]+$/.test(this.state.achternaam) ||
              !this.state.achternaam
                ? false
                : true
            }
            helperText={
              /^[A-Za-z\s]+$/.test(this.state.achternaam) ||
              !this.state.achternaam
                ? ""
                : "Voer een geldige achternaam in"
            }
            onChange={this.handleChange}
            value={this.state.achternaam}
          />
          <TextField
            id="outlined-basic"
            label="Straat"
            variant="outlined"
            name="straat"
            error={
              /^[A-Za-z\s]+$/.test(this.state.straat) || !this.state.straat
                ? false
                : true
            }
            helperText={
              /^[A-Za-z\s]+$/.test(this.state.straat) || !this.state.straat
                ? ""
                : "Voer een geldige straatnaam in"
            }
            onChange={this.handleChange}
            value={this.state.straat}
          />
          <TextField
            id="outlined-basic"
            label="Huisnummer"
            variant="outlined"
            name="huisnummer"
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
            onChange={this.handleChange}
            value={this.state.huisnummer}
          />
          <TextField
            id="outlined-basic"
            label="Toevoeging"
            variant="outlined"
            name="toevoeging"
            onChange={this.handleChange}
            value={this.state.toevoeging}
          />
          <TextField
            id="outlined-basic"
            label="Postcode"
            variant="outlined"
            name="postcode"
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
            onChange={this.handleChange}
            value={this.state.postcode}
          />

          <TextField
            id="outlined-basic"
            label="Plaats"
            variant="outlined"
            name="plaats"
            error={
              /^[A-Za-z\s]+$/.test(this.state.plaats) || !this.state.plaats
                ? false
                : true
            }
            helperText={
              /^[A-Za-z\s]+$/.test(this.state.plaats) || !this.state.plaats
                ? ""
                : "Voer een geldig plaatsnaam in"
            }
            onChange={this.handleChange}
            value={this.state.plaats}
          />
          <TextField
            id="outlined-basic"
            label="Telefoonnummer"
            variant="outlined"
            name="telefoonnummer"
            error={
              /^((\+|00(\s|\s?\-\s?)?)31(\s|\s?\-\s?)?(\(0\)[\-\s]?)?|0)[1-9]((\s|\s?\-\s?)?[0-9])((\s|\s?-\s?)?[0-9])((\s|\s?-\s?)?[0-9])\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]$/.test(
                this.state.telefoonnummer
              ) || !this.state.telefoonnummer
                ? false
                : true
            }
            helperText={
              /^((\+|00(\s|\s?\-\s?)?)31(\s|\s?\-\s?)?(\(0\)[\-\s]?)?|0)[1-9]((\s|\s?\-\s?)?[0-9])((\s|\s?-\s?)?[0-9])((\s|\s?-\s?)?[0-9])\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]$/.test(
                this.state.telefoonnummer
              ) || !this.state.telefoonnummer
                ? ""
                : "Voer een geldig telefoonnummer in"
            }
            onChange={this.handleChange}
            value={this.state.telefoonnummer}
          />
          <TextField
            id="outlined-basic"
            label="E-mail"
            variant="outlined"
            name="email"
            error={
              /\S+@\S+\.\S+/.test(this.state.email) || !this.state.email
                ? false
                : true
            }
            helperText={
              /\S+@\S+\.\S+/.test(this.state.email) || !this.state.email
                ? ""
                : "Voer een geldig plaatsnaam in"
            }
            onChange={this.handleChange}
            value={this.state.email}
          />
          <div className="checkbox_div">
            <Checkbox
              color="default"
              inputProps={{ "aria-label": "checkbox with default color" }}
              name="validinfo"
              onChange={this.handleChange}
              checked={this.state.checked}
            />
            Gegevens zijn naar waarheid ingevuld
          </div>
        </form>
      </div>
    );
  }
}
