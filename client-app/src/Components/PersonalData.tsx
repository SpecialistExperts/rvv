import {
  Checkbox,
  createStyles,
  makeStyles,
  TextField,
  Theme,
} from "@material-ui/core";
import { Person } from "@material-ui/icons";
import React, { Component } from "react";
import "./PersonalData.css";

interface IPersonalData {
  Name: string;
  Affix: string;
  Surname: string;
  Street: string;
  HouseNumber: number;
  AddHouseNumber?: number;
  PostalCode: string;
  Location: string;
  TelephoneNumber: string;
  Email: string;
  Valid: boolean;
}

interface IProps {}

interface IState {
}


export class PersonalData extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = { 
        Affix: ""
    };

    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(e : any){
    var name = e.target.name
    this.setState({[name]: e.target.value}, () => console.log(this.state));
  } 

  render() {
    return (
      <div className="personal_data_div">
        <h1>Persoonsgegevens</h1>
        <form noValidate autoComplete="off">
          <TextField
            id="outlined-basic"
            label="Voornamen"
            variant="outlined"
            name="name"
            onChange={this.handleChange}
          />
          <TextField
            id="outlined-basic"
            label="Tussenvoegsel"
            variant="outlined"
            name="tussenvoegsel"
            onChange={this.handleChange}
          />
          <TextField
            id="outlined-basic"
            label="Achternaam"
            variant="outlined"
            name="achternaam"
            onChange={this.handleChange}
          />
          <TextField id="outlined-basic" label="Straat" variant="outlined" />
          <TextField
            id="outlined-basic"
            label="Huisnummer"
            variant="outlined"
          />
          <TextField
            id="outlined-basic"
            label="Toevoeging"
            variant="outlined"
          />
          <TextField id="outlined-basic" label="Postcode" variant="outlined" />
          <TextField id="outlined-basic" label="Plaats" variant="outlined" />
          <TextField
            id="outlined-basic"
            label="Telefoonnummer"
            variant="outlined"
          />
          <TextField id="outlined-basic" label="E-mail" variant="outlined" />
          <div className="checkbox_div">
            <Checkbox
              color="default"
              inputProps={{ "aria-label": "checkbox with default color" }}
            />{" "}
            Gegevens zijn naar waarheid ingevuld
          </div>
        </form>
      </div>
    );
  }
}
