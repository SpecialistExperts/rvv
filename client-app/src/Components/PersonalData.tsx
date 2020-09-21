import {
  Checkbox,
  createStyles,
  makeStyles,
  TextField,
  Theme,
} from "@material-ui/core";
import React, { Component } from "react";
import "./PersonalData.css";

interface IProps {}

interface IState {
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
  [key: string] : string
}


export class PersonalData extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = { 
      voornamen : "",
      tussenvoegsel : "",
      achternaam : "",
      straat : "",
      huisnummer : "",
      toevoeging : "",
      postcode : "",
      plaats : "",
      telefoonnummer : "",
      email : ""
    };

    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(e : any){
    var name = e.target.name
    const value = name === 'validinfo' ? e.target.checked : e.target.value
    this.setState({[name]: value}, () => console.log(this.state));
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
          <TextField 
            id="outlined-basic" 
            label="Straat" 
            variant="outlined" 
            name="straat"
            onChange={this.handleChange}/>
          <TextField
            id="outlined-basic"
            label="Huisnummer"
            variant="outlined"
            name="huisnummer"
            onChange={this.handleChange}
          />
          <TextField
            id="outlined-basic"
            label="Toevoeging"
            variant="outlined"
            name="toevoeging"
            onChange={this.handleChange}
          />
          <TextField 
            id="outlined-basic" 
            label="Postcode" 
            variant="outlined"
            name="postcode"
            onChange={this.handleChange} />
            
          <TextField 
            id="outlined-basic" 
            label="Plaats" 
            variant="outlined"
            name="plaats"
            onChange={this.handleChange} />
          <TextField
            id="outlined-basic"
            label="Telefoonnummer"
            variant="outlined"
            name="telefoonnummer"
            onChange={this.handleChange}
          />
          <TextField 
            id="outlined-basic" 
            label="E-mail" 
            variant="outlined"
            name="email"
            onChange={this.handleChange} />
          <div className="checkbox_div">
            <Checkbox
              color="default"
              inputProps={{ "aria-label": "checkbox with default color" }}
              name="validinfo"
              onChange={this.handleChange}
            />
            Gegevens zijn naar waarheid ingevuld
          </div>
        </form>
      </div>
    );
  }
}
