import React, { Component } from "react";
import './Dashboard.css';

export default class Dashboard extends Component {
  state = {
      isLoading: true,
      passwords: null
  };

  componentDidMount() {
      fetch('GetList/') //TODO: Pass a username, maybe change the get to a post?
      .then(resp => resp.json)
      .then((data) => {
        this.setState({
            passwords: data
        })
      })
      .catch((err)=> {
        console.log(err);
      })
  }

  render() {
      let {isLoading} = this.state;

    return (
        <React.Fragment>
            {isLoading ? <Login /> : <PasswordList passwords={this.state.passwords} />}
        </React.Fragment>
    );
  }
}

const Login = () => {
    return (
        <div className="container">
            <div className="form-group">
                <label for="exampleInputEmail1">Email address</label>
                <input type="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" />
                <small id="emailHelp" className="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <div className="form-group">
                <label for="exampleInputPassword1">Password</label>
                <input type="password" className="form-control" id="exampleInputPassword1" placeholder="Password" />
            </div>
            <div className="form-group form-check">
                <input type="checkbox" className="form-check-input" id="exampleCheck1" />
                <label className="form-check-label" forHtml="exampleCheck1">Check me out</label>
            </div>
            <button type="submit" className="btn btn-primary">Submit</button>
        </div>
    );
}

const PasswordList = () => {
    let list = this.props.passwords.map(elem => {
        <div className="row">
            <label className="col-md-6">
                Password for {elem.Site}:
            </label>
            <input className="col-md-6" type="text" value={elem.Password} />
        </div>
    });
    return (
        <div className="container greyBackground">
            <div className="col-md-12 text-center">
                <h2>Your list of passwords</h2>
                {list}
            </div>
        </div>
    );
}