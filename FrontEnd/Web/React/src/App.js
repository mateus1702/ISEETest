import React, { Component } from 'react';
import logo from './Images/currency_converter-512.png'
import './App.css';
import CurrencyConverterForm from './components/CurrencyConverterForm'

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <CurrencyConverterForm/>
        </header>
      </div>
    );
  }
}

export default App;
