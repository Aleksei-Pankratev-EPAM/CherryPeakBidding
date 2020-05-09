import React, { Component } from 'react';
import LotItem from './LotItem';
import Error from '../Error';
import data from './lots.json'

class LotsList extends Component {
    constructor(props) {
      super(props)
      const list = [];
      this.state = {
        lots: list,
        isError: false,
        error: null
      };
    }
    
   componentDidMount() {
      this.setState({
               lots: data
             });
  //   // //const url = `https://newsapi.org/v2/${this.props.news.type}?${this.props.news.query}&apiKey=3c5c8f726f4f4d87a352e63017c68eb0`;
    //  const url = './lots.json';
    // fetch(url)
    //   .then((response) => {
    //     console.log(response.JSON);
    //     return (response.json());
    //   })
    //   .then((dataF) => {
    //     alert(`fetch from json ${dataF.length}`);
    //     this.setState({
    //       lots: dataF
    //     })
    //   })
      // .catch((error) => {
      //   console.log(error);
      //   this.setState({
      //     isError: true,
      //     error: {sourse: "lots list fetching", message: error}
      //   })
      // });
   }
    renderItems() {
         if (!this.state?.isError ?? false) {
          return this.state.lots.map((item) => (
            <LotItem key={item.id} item={item} />
          ));
        } else {
          return <Error error={this.state.error}/>
        }
      }
    render() {
      return (
        <div /*className="row"*/>
            <h1>Lots list here...</h1>
        {this.renderItems()}
      </div>
    //     <div>
    //     <h1>Lots list here...</h1>
    //     <ul>
    //       {this.state.lots.map(item => (
    //         <li key={item.id}> {item}</li>
    //       ))}
    //     </ul>
    //   </div>
      );
    }
  }
  
  export default LotsList;