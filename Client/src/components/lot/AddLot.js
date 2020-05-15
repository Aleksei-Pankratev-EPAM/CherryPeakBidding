import React, { Component } from 'react';
import uuid from 'react-uuid';
import Redirect from 'react-dom';

import {
  START_PRICE_DEFAULT,
  PRICE_STEP_DEFAULT,
  BIDDING_TIME_DEFAULT,
} from '../../constants/NewLotDefaultValues';

import {
  getTitleValidationErrors,
  getDesctiptionValidationErrors,
  getStartPriceValidationErrors,
  getPriceStepValidationErrors,
  getBiddingTimeValidationErrors
} from './AddLotFieldsValidation';

import FieldRowContainer from './FieldRowContainer';
import HorizontalInput from '../HorizontalInput';
import { createLot } from '../../services/LotService';


class AddLot extends Component {

  constructor(prop) {
    super(prop);

    this.state = {
      lot: {
        id: uuid(),
        title: '',
        description: '',
        startPrice: START_PRICE_DEFAULT,
        priceStep: PRICE_STEP_DEFAULT,
        biddingTime: BIDDING_TIME_DEFAULT,
      },
      formValid: false,

      formErrors: {
        title: [],
        description: [],
        startPrice: [],
        priceStep: [],
        biddingTime: []
      },
    }

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.isFormValid = this.isFormValid.bind(this);
    this.validateForm = this.validateForm.bind(this);
  }

  componentDidMount() {
    this.validateForm();
  }

  handleSubmit(event) {
    createLot(this.state.lot,
      (result) => {
        alert('Лот успешно создан');
        this.props.history.push(`/lots/details/${this.state.lot.id}`);
      },
      (error) => {
        alert('При создании лота произошла ошибка: ' + error);
      });
    event.preventDefault();
  }

  handleChange(event) {
    const name = event.target.name;
    const value = event.target.value;
    const updatedLot = this.state.lot;
    updatedLot[name] = value;
    this.setState(
      { lot: updatedLot },
      () => { this.validateField(name, value) }
    );
  }

  validateField(fieldName, value) {
    let fieldValidationErrors = this.state.formErrors;
    let errors = [];

    switch (fieldName) {
      case 'title': errors = getTitleValidationErrors(value);
        break;
      case 'description': errors = getDesctiptionValidationErrors(value);
        break;
      case 'startPrice': errors = getStartPriceValidationErrors(value);
        break;
      case 'priceStep': errors = getPriceStepValidationErrors(value);
        break;
      case 'biddingTime': errors = getBiddingTimeValidationErrors(value);
        break;

      default:
        break;
    }

    fieldValidationErrors[fieldName] = errors;

    this.setState({
      formErrors: fieldValidationErrors,
    }, this.updateFormValidationState);
  }

  validateForm() {
    for (const fieldName in this.state.lot) {
      this.validateField(fieldName, this.state.lot[fieldName]);
    }
  }

  isFormValid() {
    for (const key in this.state.formErrors) {
      if (this.state.formErrors[key]?.length > 0) {
        return false;
      }
    }
    return true;
  }

  updateFormValidationState() {
    this.setState({ formValid: this.isFormValid() });
  }

  isFieldValid(errors) {
    return !errors || errors.length === 0;
  }

  renderFieldRow(fieldName, title, type, details, placeholder, required, addon) {
    const validationErrors = this.state.formErrors[fieldName];

    return (
      <FieldRowContainer title={title} name={fieldName} details={details} required={required}>
        <HorizontalInput
          name={fieldName}
          type={type}
          value={this.state.lot[title]}
          handleChange={this.handleChange}
          placeholder={placeholder}
          required={required}
          addon={addon}
          validationErrors={validationErrors} />
      </FieldRowContainer>
    )

  }

  render() {
    return (
      <div>
        <h1>Новый лот</h1>

        <form onSubmit={this.handleSubmit}>
          {this.renderFieldRow('title', 'Наименование лота', 'text', 'Например, «Стул обеденный»', null, true, null)}

          <FieldRowContainer title='Описание' name='description'>
            <textarea name='description' className={`form-control ${this.isFieldValid(this.state.formErrors['description']) ? 'is-valid' : 'is-invalid'}`} rows="3"
              value={this.state.lot.description} onChange={this.handleChange} />
            <div className="invalid-tooltip">
              {this.state.formErrors['description']}
            </div>
          </FieldRowContainer>

          {this.renderFieldRow('startPrice', 'Начальная цена', 'number', null, START_PRICE_DEFAULT, true, 'cc')}

          {this.renderFieldRow('priceStep', 'Минимальный шаг', 'number', 'Минимальный шаг приращения цены', PRICE_STEP_DEFAULT, true, 'cc')}

          {this.renderFieldRow('biddingTime', 'Время одного раунда', 'number', null, BIDDING_TIME_DEFAULT, true, 'мин.')}

          <div className="form-group row">
            <div className="col-sm-10">
              <button type="submit" className="btn btn-primary" disabled={!this.state.formValid}>Создать</button>
            </div>
          </div>
        </form>

      </div>
    );
  }

}

export default AddLot;