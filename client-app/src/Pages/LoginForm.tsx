import { Button, Grid, TextField } from "@material-ui/core";
import React from "react";
import logo from "../Delft2.jpg";

export const LoginForm = () => {
  return (
    <div>
      <Grid container style={{ minHeight: "90vh" }}>
        <Grid item xs={12} sm={6}>
          <img
            src={logo}
            style={{ width: "100%", height: "100%", objectFit: "cover" }}
            alt="brand"
          />
        </Grid>
        <Grid container item xs={12} sm={6} align-items="center" direction="column" style={{padding: 10}}>
          <div />
          <div>
            <Grid container justify="center">
              <img src="" width={200} />
            </Grid>
            <TextField
              id="outlined-basic"
              label="Email"
              variant="outlined"
              name="email"
            />
            <TextField
              id="outlined-basic"
              label="Password"
              variant="outlined"
              name="password"
              type="password"
            />
            <Button> Login </Button>
          </div>
        </Grid>
      </Grid>
    </div>
  );
};

export default LoginForm;
