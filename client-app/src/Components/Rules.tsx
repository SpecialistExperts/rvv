import { Checkbox } from "@material-ui/core";
import React from "react";
import { Component } from "react";
import "./Rules.css";

interface IProps {
  callback : () => void
}

interface IState {}

export class Rules extends Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {};
  }
  render() {
    return (
      <div>
        <h3>Regels vakantieverhuur</h3>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at
          pretium massa. Mauris eu nisi in lectus malesuada semper a vel ligula.
          Curabitur ultricies odio nec diam facilisis, nec consectetur ipsum
          commodo. Suspendisse imperdiet egestas sodales. Maecenas commodo
          ligula tincidunt, congue mauris pretium, dignissim turpis. <br></br>
          Donec eu elit ut est mattis laoreet non quis risus. Sed posuere,
          turpis sed ultricies tincidunt, enim turpis congue diam, gravida
          elementum lacus mi sit amet eros. Praesent ultrices mollis tincidunt.
          Suspendisse rhoncus libero risus, gravida auctor mauris euismod ac.
          Proin vitae sollicitudin dui, eu tincidunt lacus. Aenean vitae blandit
          risus. Quisque eu elit sed arcu malesuada vehicula at sed felis.
          Pellentesque sollicitudin risus a enim sodales, ut mollis urna porta.
          Vivamus ut lobortis erat, nec vestibulum magna.
        </p>
        <div className="checkbox_div">
            <Checkbox
              color="default"
              inputProps={{ "aria-label": "checkbox with default color" }}
              name="validinfo"
              onClick={() => this.props.callback()}
            />
            Ik voldoe aan de regels
          </div>
      </div>
    );
  }
}
