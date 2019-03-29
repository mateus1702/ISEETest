import React from "react";
import Select from "react-select";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import { Form, Button, Alert } from "react-bootstrap";

class CurrencyConverterForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      amountReal: "",
      amountForeign: "",
      currencies: [],
      selectedCurrency: null,
      restServiceOffile: false
    };

    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleCurencyChange = this.handleCurencyChange.bind(this);
    this.convertCurrencyFromReal = this.convertCurrencyFromReal.bind(this);
    this.convertCurrencyFromForeign = this.convertCurrencyFromForeign.bind(
      this
    );
  }

  componentDidMount() {
    axios
      .get(`http://localhost:5000/api/currency`)
      .then(res => {
        let currencies = [];
        res.data.currencies.forEach(item => {
          currencies.push({
            label: `${item.code} - ${item.name}`,
            value: item.code,
            code: item.code
          });
        });
        this.setState({ currencies });
      })
      .catch(res => {
        if (!res.response)
          this.setState({
            restServiceOffile: true
          });
      });
  }

  handleInputChange(event) {
    const target = event.target;
    let value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;

    if (name === "amountReal" || name === "amountForeign")
      value = value.replace(",", ".");

    this.setState({
      [name]: value
    });
  }

  handleCurencyChange(selectedCurrency) {
    this.setState({
      selectedCurrency: selectedCurrency
    });
  }

  convertCurrencyFromReal() {
    if (this.state.selectedCurrency && this.state.amountReal) {
      let params = `?from=BRL&to=${this.state.selectedCurrency.value}&amount=${
        this.state.amountReal
      }`;

      axios
        .get(`http://localhost:5000/api/currency/convert${params}`)
        .then(res => {
          if (res.status === 200)
            this.setState({
              amountForeign: res.data.result
            });
          else
            this.setState({
              amountForeign: ""
            });
        });
    }
  }

  convertCurrencyFromForeign() {
    if (this.state.selectedCurrency && this.state.amountForeign) {
      let params = `?from=${this.state.selectedCurrency.value}&to=BRL&amount=${
        this.state.amountForeign
      }`;

      axios
        .get(`http://localhost:5000/api/currency/convert${params}`)
        .then(res => {
          if (res.status === 200)
            this.setState({
              amountReal: res.data.result
            });
          else
            this.setState({
              amountReal: ""
            });
        });
    }
  }

  render() {
    let mainApp = (
      <Form>
        <Form.Group className="currency-container">
          <Form.Label>Target currency</Form.Label>
          <Select
            className="currency"
            options={this.state.currencies}
            onChange={this.handleCurencyChange}
          />
        </Form.Group>
        {this.state.selectedCurrency && (
          <React.Fragment>
            <Form.Group>
              <Form.Label>BRL Amount</Form.Label>
              <Form.Control
                name="amountReal"
                type="text"
                placeholder=""
                value={this.state.amountReal}
                onChange={this.handleInputChange}
              />
            </Form.Group>
            <Button variant="primary" onClick={this.convertCurrencyFromReal}>
              Convert from BRL to {this.state.selectedCurrency.code}
            </Button>
            <br />
            <br />
            <Form.Group>
              <Form.Label>{this.state.selectedCurrency.code} Amount</Form.Label>
              <Form.Control
                name="amountForeign"
                type="text"
                placeholder=""
                value={this.state.amountForeign}
                onChange={this.handleInputChange}
              />
            </Form.Group>
            <Button variant="primary" onClick={this.convertCurrencyFromForeign}>
              Convert from {this.state.selectedCurrency.code} to BRL
            </Button>
          </React.Fragment>
        )}
      </Form>
    );

    return (
      <React.Fragment>
          <br />
        {this.state.restServiceOffile ? (
           
          <Alert variant='danger'>
            Rest service offile...
          </Alert>
        ) : (
          mainApp
        )}
      </React.Fragment>
    );
  }
}

export default CurrencyConverterForm;
