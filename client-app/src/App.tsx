import React from "react";
import "./App.css";
import { AppBar, Toolbar } from "@material-ui/core";

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
