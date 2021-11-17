import React, {Component} from 'react';
import axios from 'axios';

import PropTypes from 'prop-types';


class Home extends Component
{
    constructor(props)
    {
        super(props);
        this.state =
            {
                sendDataAmount: "",
                isValid : true
            };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChanged = this.handleInputChanged.bind(this);
    }

    handleSubmit() {
        debugger
        for(let i = 0; i < parseInt(this.state.sendDataAmount); i++)
            {
                if (this.state.sendDataAmount !== ""){
                    axios.post("https://localhost:44343/Tasks/SendProcessData", {Test: i}, {headers: { 
                        "Access-Control-Allow-Origin": "*",
                        "Access-Control-Allow-Headers": "Origin, X-Requested-With, Content-Type, Accept"
                    }})
                        .then(response => {
                            
                        }).catch(error => console.log(error));
                } else {
                    this.setState({
                        isValid : false
                    });
                    // error message
                }
            }
            this.setState({
                sendDataAmount : ""
            });
      }
    handleInputChanged(e) {
        this.setState({
            isValid : true
        });
        let value = e.target.value;
        this.setState({
            sendDataAmount : value
        });
    }

    render()
    {
        const section = {
            display: 'absolute',
            justifyContent: 'center',
            alignItems: 'center',
            width: '100%',
            flexShrink: '0',
            height: '100vh',
            background: '#dce2e2',
        };

        const formStyle = {
            display: 'absolute',
            margin: ' 0 auto'
        }

        const submitStyle = {
            marginTop: '10vh',
            height: '6vh',
            fontSize: '1.2vw',
            backgroundColor: '#6aa6a7',
            border: 'none',
            cursor: 'pointer',
            borderRadius: '10px 10px 10px 10px',
            color: '#fff',
            margin: '1rem 28.5rem'
        }

        const inputStyle = {
            height: '4vh',
            fontSize: '1.2vw',
            backgroundColor: '#fff',
            border: 'none',
            padding: '10px',
            outline: this.state.isValid ? '1px solid #426d79' : '1px solid red',
            borderRadius: '10px 10px 10px 10px',
            margin: '10rem 25rem 0rem 25rem'
        }

        const helperTextStyle = {
            fontSize: '0.8vw',
            width: '100%',
            color: 'red',
            marginTop: '15px',
            minHeight: '17px',
            maxHeight: '10px',
            height: '10px'
        }

        return (
            <div style={section}>
                <div style={formStyle}>
                <input placeholder="Please enter number"
                       type='number'
                       name='sendDataAmount'
                       style={inputStyle}
                       onChange={this.handleInputChanged}
                       className="inputStyle"
                       value = {this.state.sendDataAmount}/>
                    {
                        !this.state.isValid &&
                        <span style={helperTextStyle}>Please enter number before submit</span>
                    }
                    <div>
                        <input type='submit' className="submitButton" value={"Submit"} style={submitStyle} onClick={this.handleSubmit}/>
                    </div>
                </div>
            </div>
        );
    }

}
Home.contextTypes = {
    router: PropTypes.object
};


export default Home