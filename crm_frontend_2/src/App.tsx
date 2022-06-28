import React from "react";
import { FC, ReactElement } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import './Header.css';
import userManager, { loadUser, getrole, getrole2, signinRedirect,signoutRedirect } from './auth/user-service';
import AuthProvider from './auth/auth-provider';
import SignInOidc from './auth/SigninOidc';
import SignOutOidc from './auth/SignoutOidc';
 import Orderlist from './components/Orderlist/Orderlist';
 import DetailOrder from './components/Orderlist/DetailOrder';

var x = "";
getrole().then(res => { x = res })
    .then(() => console.log(x));
var b = "";
getrole2().then(res => { b = res })
    .then(() => console.log(b));

const App: FC<{}> = (): ReactElement => {
    loadUser();
    //if (x == b) 
    //    return (           
    //            <div className="App">
    //                <header className="App-header">
    //                    <button onClick={() => signinRedirect()}>Login</button>
    //                    <AuthProvider userManager={userManager}>
    //                        <BrowserRouter>
    //                            <Routes>                                      
    //                                <Route path="/" element={<Orderlist />} />
    //                                <Route path="/signout-oidc" element={<SignOutOidc />} />
    //                                <Route path="/signin-oidc" element={<SignInOidc />} />
    //                            </Routes>
    //                        </BrowserRouter>
    //                    </AuthProvider>
    //                </header>
    //            </div>      
    //    );       
    //else
    return (
        <div>
                <header className="header-dispetcer">
                    <ul id="navbar">
                        <li><a href="#">Logo</a></li>
                        <li className="empty-li"> </li>
                        <li><button className="button-login" onClick={() => signinRedirect()}>Login</button></li>
                        <li><button className="button-login" onClick={() => signoutRedirect()}>Выход</button></li>
                    </ul>
                </header>    
                    
                    <AuthProvider userManager={userManager}>
                        <BrowserRouter>
                            <Routes>
                                <Route path="/" element={<Orderlist />} />
                              
                                <Route path=":id" element={<DetailOrder/>} />
                                <Route path="/signout-oidc" element={<SignOutOidc />} />
                                <Route path="/signin-oidc" element={<SignInOidc />} />
                            </Routes>
                        </BrowserRouter>
                    </AuthProvider>

            <footer>

            </footer>
        </div>
    );
};

export default App;
