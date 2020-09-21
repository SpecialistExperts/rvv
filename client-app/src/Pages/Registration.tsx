import React, { Component } from "react";
import "./Registration.css";
import { AppBar, Button, Container, Grid, Toolbar } from "@material-ui/core";
import logo from "../LogoDelft.png";
import LanguageOption from "../Components/LanguageOption";
import { StepperComponent } from "../Components/StepperComponent";
import { PersonalData} from "../Components/PersonalData";
import { RentalHouse } from "../Components/RentalHouse";
import { Rules } from "../Components/Rules";

interface IState {
  activeStep: number;
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
      activeStep: 0,
    };

    this.setActiveStep = this.setActiveStep.bind(this);
  }

  setActiveStep(x: number) {
    this.setState({ activeStep: x });
  }

  handleNext = () => {
    console.log(this.state.activeStep)

    this.setActiveStep(this.state.activeStep + 1);
    console.log(this.PersonalDataRef.current.state);
  };

  handleBack = () => {
    this.setActiveStep(this.state.activeStep - 1);
  };

  handleReset = () => {
    this.setActiveStep(0);
  };

  renderSwitch = (x : number) => {
    switch(x) {
      case 0 :
        return (<PersonalData ref={this.PersonalDataRef}/>);
      case 1 : 
        return (<RentalHouse ref={this.PersonalDataRef}/>);
      case 2 : 
      return (<Rules ref={this.PersonalDataRef}/>);
      case 3 : 
      return (<div> case 3</div>);
      case 4 : 
      return (<div> case 4</div>);
    }}

  render() {
    return (
      <div className="App">
        <AppBar className="navbar" position="fixed">
          <Toolbar>
            <img src={logo} />
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
                  disabled={this.state.activeStep === 4}
                  variant="contained"
                  color="primary"
                  onClick={this.handleNext}
                >
                  Next
                </Button>
              </div>
            </Grid>
          </Grid>
        </Container>
      </div>
    );
  }
}

export default Registration;
