import React from 'react';
import { Link } from 'react-router-dom';
import { ArrowUpRight } from 'react-bootstrap-icons';

import '../../css/LotItem.css';
import LotProgressBar from './LotProgressBar';
import UserStatus from './UserStatus';
import Money from '../Money';
import Pluralizer from '../Pluralizer';

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
        <div className='mx-auto mt-3'>
          <Link to={getDetailsUrl(id)}>
            <Thumbnail src={mainPhotoUrl} alt={title} />
          </Link>
        </div>
        <div className="card-body">
          <h3 className="card-title"><Link to={getDetailsUrl(id)}>{title}</Link></h3>
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

function getDetailsUrl(lotId) {
  return `/lots/details/${lotId}`;
}

function StartPrice({ value }) {
  return <span className="text-nowrap"><Money value={value} /></span>;
}

function MinPriceStep({ value }) {
  return <span title="Min. price step"><Money value={value} /></span>;
}

function MaxOffer({ value }) {
  return <div className="max-lot-offer text-nowrap" title="Max offer"><Money value={value} /></div>;
}

function BidCount({ value }) {
  return <div><Pluralizer value={value} plural='bids' singular='bid' /></div>
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
  return <img src={src ?? 'no-image.png'} alt={alt ?? 'no image'} className="img-thumbnail" width="200px" height="200px" />
}

export default LotItem;