import React, { Component } from 'react';
import { formatDistance, addSeconds } from 'date-fns';

import ProgressBar from 'react-bootstrap/ProgressBar';

import '../../css/LotProgressBar.css';

class LotProgressBar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            secondsLeft: props.timeToLive ?? 0
        };
    }

    componentDidMount() {
        if (this.state.secondsLeft > 0) {
            this.intervalId = setInterval(this.changeValue, 1000);
        }
    }

    componentWillUnmount() {
        if (this.intervalId) {
            clearInterval(this.intervalId);
        }
    }

    changeValue = () => {
        this.setState((prev) => {
            const next = prev.secondsLeft - 1;

            if (next < 1) {
                clearInterval(this.intervalId);
            }

            return {
                secondsLeft: next
            };
        });
    }

    getPercentageLeft = () => {
        let percentage = (this.state.secondsLeft * 100) / this.props.biddingTime;
        return 100 - percentage;
    }

    getTimeStr = () => {
        const seconds = this.state.secondsLeft;

        if (seconds < 60) {
            return `${seconds} sec.`;
        }

        const now = new Date();
        return formatDistance(addSeconds(now, seconds), now);
    }

    render() {
        const progressBar = <ProgressBar bsPrefix="lot-progress" now={this.getPercentageLeft()} label={`${this.getTimeStr()} left`} />;
        const completed = <div className="lot-is-closed">COMPLETED</div>;

        return (
            <span>
                {this.state.secondsLeft ? progressBar : completed}
            </span>
        );
    }
}

export default LotProgressBar;