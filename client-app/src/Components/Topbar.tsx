import { Box, Container } from "@material-ui/core";
import React from "react";
import './Topbar.css';
import logo from '../LogoDelft.png'

export const Topbar = () => {
  return (
    <div>
      <Container maxWidth={false}>
        <Box boxShadow={2} className = "topbar_box">
            <img src={logo} className = "topbar_image"/>
            <h2 >Test text</h2>
        </Box>
      </Container>
    </div>
  );
};
