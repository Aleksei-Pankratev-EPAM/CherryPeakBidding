import React, { Component } from 'react';
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
        let seconds = this.state.secondsLeft;
        let result = '';

        const secondsInDay = 86400;
        const days = Math.floor(seconds / secondsInDay);
        seconds -= days * secondsInDay;

        if (days > 0) {
            result += `${days} d. `;
        }

        const secondsInHour = 3600;
        const hours = Math.floor(seconds / secondsInHour);
        seconds -= hours * secondsInHour;

        if (hours > 0) {
            result += `${hours} hrs. `;
        }

        const secondsInMinute = 60;
        var minutes = Math.floor(seconds / secondsInMinute);
        seconds -= minutes * secondsInMinute;

        if (minutes > 0) {
            result += `${minutes} min.`;
        }

        return `${result} ${seconds} sec.`;
    }

    render() {
        const progressBar = <ProgressBar bsPrefix="lot-progress" now={this.getPercentageLeft()} label={`${this.getTimeStr()} left`} />;
        const completed = <div className="lot-is-closed">COMPLETED</div>;

        return (
            <span>
                {this.state.secondsLeft ? progressBar : completed }
            </span>
        );
    }
}

export default LotProgressBar;