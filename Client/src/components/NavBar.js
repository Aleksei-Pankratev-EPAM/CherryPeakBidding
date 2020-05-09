// import React from 'react'
import React from 'react';
//import { Link } from 'react-router-dom';
import { Nav, Navbar /*, NavItem, NavDropdown, MenuItem, Form, FormControl, Button */} from 'react-bootstrap';

const NavBar = () => {
    return (
        <div className='App tc f3'>
           <Navbar bg='light' expand='lg'>
             <Navbar.Brand href="/">Home</Navbar.Brand>
             <Navbar.Toggle aria-controls="basic-navbar-nav" />
             <Navbar.Collapse id="basic-navbar-nav">
               <Nav className='mr-auto'>
                 <Nav.Link href="/lots-list">Lots list</Nav.Link>
                 <Nav.Link href="/statistics">Statistics</Nav.Link>
                 <Nav.Link href="/registration">Registration</Nav.Link>
                 <Nav.Link href="/login">Login</Nav.Link>
                 {/* <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                   <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                   <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                   <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                   <NavDropdown.Divider />
                   <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
                 </NavDropdown> */}
               </Nav>
               {/* <Form inline>
                 <FormControl type="text" placeholder="Search" className="mr-sm-2" />
                 <Button variant="outline-success">Search</Button>
               </Form> */}
             </Navbar.Collapse>
           </Navbar>
         </div>
       );
    }
//     <div className="navbar-fixed">
//         <nav class="navbar  navbar-dark bg-primary" >
//             <ul>
//                 <li>
//                     <Link to="/">Home</Link>
//                 </li>
//                 <li>
//                     <Link to="/lots-list">Lots list</Link>
//                 </li>
//                 <li>
//                     <Link to="/statistics">Statistics</Link>
//                 </li>
//                 <li>
//                     <Link to="/registration">Registration</Link>
//                 </li>
//                 <li>
//                     <Link to="/login">Login</Link>
//                 </li>
//             </ul>
//         </nav>
//     </div>
// );

export default NavBar;
