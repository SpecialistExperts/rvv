import React from "react";
import logo from "./logo.svg";
import "./App.css";
import { Topbar } from "./Components/Topbar";
import { AppBar, Button, Menu, MenuItem, Toolbar } from "@material-ui/core";
import PopupState, { bindTrigger, bindMenu } from "material-ui-popup-state";

const App: React.FC = () => {
  return (
    <div className="App">
      <AppBar position="fixed">
        <Toolbar>test test test</Toolbar>
      </AppBar>
      <Toolbar />
    </div>
  );
};

export default App;
