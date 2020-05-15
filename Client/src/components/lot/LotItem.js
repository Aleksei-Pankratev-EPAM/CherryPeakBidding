import React from 'react';
import { Link } from 'react-router-dom';
import { ArrowUpRight } from 'react-bootstrap-icons';

import '../../css/LotItem.css';
import LotProgressBar from './LotProgressBar';
import UserStatus from './UserStatus';
import { CURRENCY } from "../Currency";

function LotItem(props) {
  const {
    id,
    title,
    mainPhotoUrl,
    participationStatus,
    bidsCount,
    biddingTime,
    timeToLive
  } = props.item;

  return (
    <div className="col-lg-3 col-md-6 mb-3">
      <div className="card shadow-sm h-100">
        <Thumbnail src={mainPhotoUrl} alt={title} />
        <div className="card-body">
          <h3 className="card-title"><Link to={`/lots/details/${id}`}>{title}</Link></h3>
          <UserStatus value={participationStatus} />
          <div className="card-text">
            <PriceInfo item={props.item} />
            <BidCount value={bidsCount} />
            <LotProgressBar biddingTime={biddingTime} timeToLive={timeToLive} />
          </div>
        </div>
      </div>
    </div>
  );
}

function getPriceStr(value) {
  return `${value} ${CURRENCY}`;
}

function pluralize(value, plural = '', singular = '') {
  const name = (value > 1 || value === 0) ? plural : singular;
  return `${value} ${name}`;
}

function StartPrice({ value }) {
  return <span className="text-nowrap">{getPriceStr(value)}</span>;
}

function MinPriceStep({ value }) {
  return <span title="Min. price step">{getPriceStr(value)}</span>;
}

function MaxOffer({ value }) {
  return <div className="max-lot-offer text-nowrap" title="Max offer">{getPriceStr(value)}</div>;
}

function BidCount({ value }) {
  return <div>{pluralize(value, 'bids', 'bid')}</div>;
}

function PriceInfo(props) {
  const { startPrice, minPriceStep, maxOffer } = props.item;

  return (
    <>
      <MaxOffer value={maxOffer} />
      <div>From <StartPrice value={startPrice} /> <ArrowUpRight /> <MinPriceStep value={minPriceStep} /></div>
    </>
  );
}

function Thumbnail({ src, alt }) {
  return <img src={src ?? 'no-image.png'} alt={alt ?? 'no image'} className="img-thumbnail mx-auto mt-3" width="200px" height="200px" />
}

export default LotItem;