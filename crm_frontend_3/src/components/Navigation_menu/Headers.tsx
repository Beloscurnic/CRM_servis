import React, { FC, ReactElement, useRef, useEffect, useState,useMemo } from 'react';
import { ROW_SELECT_DISABLED } from "react-bootstrap-table-next";
import SignInOidc from '../../auth/SigninOidc';
import SignOutOidc from '../../auth/SignoutOidc';
import userManager, { loadUser, getrole,admin, dispatcher,getname, signinRedirect,signoutRedirect,storekeeper,master } from '../../auth/user-service';
import './Header.css';
import { NavLink,useParams } from 'react-router-dom';
// var d="";
// dispatcher().then(res => { d = res })
// var a = "";
// admin().then(res => { a = res })
// var x = "";
// getrole().then(res => { x = res  })

// var s= "";
// storekeeper().then(res => { s = res })

// var m= "";
// master().then(res => { m = res })

const Navigation_menu: FC<{}> = (): ReactElement => {
    loadUser();
    const [orders, setOrders] = useState("Войти");


    async function getOrder() {
        
        const orderListVm = await  getname()
        for ( let index in orderListVm as any)
        {
          const name2 =  orderListVm![0] 
          setOrders(name2!);
        }
    }

    const [userrole, setrole] = useState("");

    async function getrole2() {
        const role2 = await getrole()
        setrole(role2.role);
    }

    useEffect(() => {
        setTimeout(getrole2, 500);
    }, []);
    useEffect(() => {
        setTimeout(getOrder, 50);
        // list(orders)
    }, []);

     if (userrole === "dispatcher"){
        return (  
           <div >
           <header className="header-dispetcer">
                  <ul id="navbar">
                      <li><a href="#">Logo</a></li>
                      <li className="empty-li"> </li>
                       <li><a type='button' className="button-login" href="/">Главная</a></li> 
                       <li><button className="button-login"  onClick={() => signinRedirect()}>{orders}</button></li>
                      <li><button className="button-login" onClick={() => signoutRedirect()}>Выход</button></li>         
                  </ul>
          </header>
      </div>
        )}
        if (userrole === "storekeeper"){
            return (
               <div >
               <header className="header-dispetcer">
                      <ul id="navbar">
                          <li><a href="#">Logo</a></li>
                          <li className="empty-li"> </li>
                          <li><button className="button-login"  onClick={() => signinRedirect()}>{orders}</button></li>
                          <li><button className="button-login" onClick={() => signoutRedirect()}>Выход</button></li>         
                      </ul>
              </header>
          </div>
            )}
if (userrole === "admin"){
        return (
           <div>
           <header className="header-dispetcer">
                  <ul id="navbar">
                      <li className="empty-li2"> </li>
                      <li><a type='button' className="button-login" href="/">Главная</a></li>
                      <li><a type='button' className="button-login" href="/accessories/all">Комплектующие</a></li>
                      <li><a type='button' className="button-login" href="/listDelivery">Доставка</a></li>
                      <li><a type='button' className="button-login" href="https://localhost:44335/Auth/Get_Personnel">Персонал</a></li> 
                      <li><a type='button' className="button-login" href="https://localhost:44335/Auth/Register">Регистрация</a></li>    
                      <li><button className="button-login"  onClick={() => signinRedirect()}>{orders}</button></li>
                      <li><button className="button-login" onClick={() => signoutRedirect()}>Выход</button></li>         
                  </ul>
          </header>
      </div>
        )
    }
    if (userrole === "serviceman"){
        return (
            <div >
            <header className="header-dispetcer">
                   <ul id="navbar">
                       <li><a href="#">Logo</a></li>
                       <li className="empty-li4"> </li>
                       <li><a type='button' className="button-login" href="/">Главная</a></li>
                       <li><button className="button-login"  onClick={() => signinRedirect()}>{orders}</button></li>
                       <li><button className="button-login" onClick={() => signoutRedirect()}>Выход</button></li>         
                   </ul>
           </header>
       </div>
        )
    }
    return(
        <div >
        <header className="header-dispetcer">
               <ul id="navbar">
                   <li><a href="#">Logo</a></li>
                   <li className="empty-li"> </li>
                   <li><button className="button-login"  onClick={() => signinRedirect()}>{orders}</button></li>
                   <li><button className="button-login" onClick={() => signoutRedirect()}>Выход</button></li>         
               </ul>
       </header>
   </div>
    )
};

export default Navigation_menu