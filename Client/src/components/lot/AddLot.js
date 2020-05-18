import React, { Component } from 'react';
import uuid from 'react-uuid';

import {
  START_PRICE_DEFAULT,
  PRICE_STEP_DEFAULT,
  BIDDING_TIME_MINUTES_DEFAULT
} from '../../constants/NewLotDefaultValues';

import {
  getTitleValidationErrors,
  getDesctiptionValidationErrors,
  getStartPriceValidationErrors,
  getPriceStepValidationErrors,
  getBiddingTimeValidationErrors
} from '../../utils/validators/addLotFieldsValidation';

import FieldRowContainer from './FieldRowContainer';
import HorizontalInput from '../HorizontalInput';
import { createLot } from '../../services/LotService';
import { fromMinutesToSeconds } from '../../utils/converters/timeConverter';
import { CURRENCY } from '../../constants/common';


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
        biddingTime: BIDDING_TIME_MINUTES_DEFAULT,
      },
      formValid: false,

      formErrors: {
        title: null,
        description: null,
        startPrice: null,
        priceStep: null,
        biddingTime: null
      },
    }
  }

  handleSubmit = (event) => {
    const lot = this.state.lot;
    lot.biddingTime = fromMinutesToSeconds(lot.biddingTime);

    createLot(lot,
      (result) => {
        alert('Lot successfully created');
        this.props.history.push(`/lots/details/${this.state.lot.id}`);
      },
      (error) => {
        alert('Error during lot creation: ' + error);
      });
    event.preventDefault();
  }

  handleBlur = (event) => {
    const name = event.target.name;
    this.validateField(name, this.state.lot[name]);
  }

  handleValueChange = (fieldName, value) => {
    const updatedLot = this.state.lot;
    updatedLot[fieldName] = value;
    this.setState(
      { lot: updatedLot }
    );
  }

  validateField = (fieldName, value) => {
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

  isFormValid = () => {
    for (const key in this.state.formErrors) {
      if (this.state.formErrors[key]?.length > 0) {
        return false;
      }
    }
    return true;
  }

  updateFormValidationState = () => {
    this.setState({ formValid: this.isFormValid() });
  }

  renderFieldRow = (fieldName, title, type, details, placeholder, required, addon) => {
    const validationErrors = this.state.formErrors[fieldName];

    return (
      <FieldRowContainer title={title} name={fieldName} details={details} required={required}>
        <HorizontalInput
          name={fieldName}
          type={type}
          value={this.state.lot[fieldName]}
          handleBlur={this.handleBlur}
          handleValueChange={this.handleValueChange}
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
        <h1>New lot</h1>

        <form onSubmit={this.handleSubmit}>

          {this.renderFieldRow('title', 'Lot name', 'text', 'E.g. «chair»', null, true, null)}

          {this.renderFieldRow('description', 'Description', 'textarea', null, null, false, null)}

          {this.renderFieldRow('startPrice', 'StartPrice', 'number', null, START_PRICE_DEFAULT, true, CURRENCY)}

          {this.renderFieldRow('priceStep', 'Min spice step', 'number', null, PRICE_STEP_DEFAULT, true, CURRENCY)}

          {this.renderFieldRow('biddingTime', 'One round time', 'number', null, BIDDING_TIME_MINUTES_DEFAULT, true, 'min.')}

          <div className="form-group row">
            <div className="col-sm-10">
              <button type="submit" className="btn btn-primary" disabled={!this.state.formValid}>Create</button>
            </div>
          </div>
        </form>

      </div>
    );
  }

}

export default AddLot;