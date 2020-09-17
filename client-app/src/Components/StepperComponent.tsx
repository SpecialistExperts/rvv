import React from "react";
import { makeStyles, Theme, createStyles, withStyles } from "@material-ui/core/styles";
import Stepper from "@material-ui/core/Stepper";
import Step from "@material-ui/core/Step";
import StepLabel from "@material-ui/core/StepLabel";
import './Stepper.css'


const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: "100%",
    },
    button: {
      marginTop: theme.spacing(3),
      marginRight: theme.spacing(1),
    },
    actionsContainer: {
      marginBottom: theme.spacing(3),
    },
    resetContainer: {
      padding: theme.spacing(3),
    },
  })
);

interface IProps {
    // steps: string[]
    activeStep: number
}

function getSteps() {
  return ["Persoonsgegevens", "Woning", "Regels", "Samenvatting", "Bedankt"];
}


export const StepperComponent =(props:  IProps)=> {
  const classes = useStyles();
  const steps = getSteps();

  return (
    <div className={classes.root}>
      <Stepper 
        activeStep={props.activeStep} 
        orientation="vertical"
        >
        {steps.map((label, index) => (
          <Step key={label}>
            <StepLabel>{label}</StepLabel>

          </Step>
        ))}
      </Stepper>


    </div>
  );
}
