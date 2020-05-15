import {httpGet} from './ServerCaller';
import {TEST} from '../constants/ApiPaths'

export function serverIsAvailable(){
    httpGet(TEST, null,(data)=>{alert(data)}, (err)=>{alert(err)} );
    alert('env.server:'+ process.env.REACT_APP_SERVER_URL);
}