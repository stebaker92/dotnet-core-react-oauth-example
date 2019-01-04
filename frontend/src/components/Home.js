import React, { Component } from "react";
import { GoogleLogin } from "react-google-login";
import { connect } from "react-redux";
import { login } from "../actions/authActions";
import config from "../config.json";
import { withRouter, Redirect } from "react-router-dom";

class Home extends Component {
  state = {};

  componentDidMount() {
    const token = this.props.token;
    if (!token) return;

    const options = {
      method: "GET",
      headers: { authorization: "bearer " + token }
    };
    fetch(
      config.GOOGLE_AUTH_CALLBACK_URL_BASE + "data/secure-data",
      options
    ).then(r => {
      r.text().then(userDetails => {
        this.setState({ userDetails });
        console.log(userDetails);
      });
    });
  }
  render() {
    return (
      <div>
        <h1>Home</h1>

        {this.state.userDetails && (
          <div>Token Info: {this.state.userDetails}</div>
        )}
      </div>
    );
  }
}

const mapStateToProps = state => {
  return {
    auth: state.auth,
    token: state.auth.user
  };
};

export default withRouter(connect(mapStateToProps)(Home));
