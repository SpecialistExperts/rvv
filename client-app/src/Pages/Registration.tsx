import React, { Component } from "react";
import "./Registration.css";
import { AppBar, Button, Container, Grid, Toolbar } from "@material-ui/core";
import logo from "../LogoDelft.png";
import LanguageOption from "../Components/LanguageOption";
import { StepperComponent } from "../Components/StepperComponent";
import { PersonalData } from "../Components/PersonalData";
import { RentalHouse } from "../Components/RentalHouse";
import { Rules } from "../Components/Rules";
import { Resume } from "../Components/Resume";
import { GetNumber } from "../Components/GetNumber";

interface IState {
  knoppie: boolean;
  activeStep: number;
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
    checked: boolean
  };
  rentaldata: {
    huisnummer: string;
    postcode: string;
    straatnaam: string;
    plaatsnaam: string;
  };
}

interface IProps {
  step?: number;
}

class Registration extends Component<IProps, IState> {
  PersonalDataRef: React.RefObject<any>;
  constructor(props: IProps) {
    super(props);
    this.PersonalDataRef = React.createRef();
    this.state = {
      knoppie: true,
      activeStep: 0,
      personaldata: {
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
        checked: false
      },
      rentaldata: {
        huisnummer: "",
        postcode: "",
        straatnaam: "",
        plaatsnaam: "",
      },
    };

    this.knoppieaan = this.knoppieaan.bind(this);
    this.knoppieuit = this.knoppieuit.bind(this);
    this.setActiveStep = this.setActiveStep.bind(this);
  }

  setActiveStep(x: number) {
    this.setState({ activeStep: x });
  }

  handleNext = () => {
    this.setActiveStep(this.state.activeStep + 1);
    this.setState({knoppie : true})
    this.saveData();
  };

  handleBack = () => {
    this.setActiveStep(this.state.activeStep - 1);
  };

  handleReset = () => {
    this.setActiveStep(0);
  };

  saveData() {
    if (this.state.activeStep === 0)
      this.setState({ personaldata: this.PersonalDataRef.current.state }, () =>
        console.log(this.state)
      );
    if (this.state.activeStep === 1)
      this.setState({ rentaldata: this.PersonalDataRef.current.state }, () =>
        console.log(this.state)
      );
  }

  knoppieaan() {
    this.setState({knoppie: false})
  }

  knoppieuit() {
    this.setState({knoppie: true})
  }

  renderSwitch = (x: number) => {
    switch (x) {
      case 0:
        return (
          <PersonalData
            personalData={this.state.personaldata}
            ref={this.PersonalDataRef}
            callbackOn={this.knoppieaan}
            callbackOff={this.knoppieuit}
            isvalid = {false}
          />
        );
      case 1:
        return <RentalHouse ref={this.PersonalDataRef} callback={this.knoppieaan}  rentalData={this.state.rentaldata}/>;
      case 2:
        return <Rules ref={this.PersonalDataRef} callback={this.knoppieaan}/>;
      case 3:
        return (
          <Resume
            personaldata={this.state.personaldata}
            rentaldata={this.state.rentaldata}
            ref={this.PersonalDataRef}
            callback={this.knoppieaan}
          />
        );
      case 4:
        return (
          <GetNumber
            personalData={this.state.personaldata}
            rentaldata={this.state.rentaldata}
            ref={this.PersonalDataRef}
          />
        );
    }
  };

  render() {

    let renderButtons = () => {
      if(this.state.activeStep <= 3){
        return (
          <div className="button_div">
                <Button
                  className="button"
                  disabled={this.state.activeStep === 0}
                  variant="contained"
                  color="primary"
                  onClick={this.handleBack}
                >
                  Back
                </Button>
                <Button
                  className="button"
                  disabled={this.state.activeStep === 4 || this.state.knoppie}
                  variant="contained"
                  color="primary"
                  onClick={this.handleNext}
                >
                  Next
                </Button>
              </div>
        )
      }
    }

    return (
      <div className="App">
        <AppBar className="navbar" position="fixed">
          <Toolbar>
            <img src={logo} alt="logo" />
            <LanguageOption />
          </Toolbar>
        </AppBar>
        <Toolbar />
        <Container maxWidth="lg">
          <Grid container spacing={0}>
            <Grid item xs={3}>
              <StepperComponent activeStep={this.state.activeStep} />
            </Grid>
            <Grid item xs={9}>
              {this.renderSwitch(this.state.activeStep)}
              {renderButtons()}
            </Grid>
          </Grid>
        </Container>
      </div>
    );
  }
}

export default Registration;
