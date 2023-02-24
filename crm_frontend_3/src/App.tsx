import React from "react";
import { FC, ReactElement,useState,useEffect } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import userManager, {master, loadUser, getrole,getrole2,admin,dispatcher, signinRedirect,signoutRedirect,storekeeper } from './auth/user-service';
import AuthProvider from './auth/auth-provider';
import SignInOidc from './auth/SigninOidc';
import SignOutOidc from './auth/SignoutOidc';
import Orderlist from './components/Orderlist/Orderlist';
import DetailOrder from './components/Orderlist/DetailOrder';
import Create_Order from "./components/Orderlist/Create_Order";
import Navigation_menu from "./components/Navigation_menu/Headers";
import Adminlist from "./components/admin/AdminList";
import AddProvider from "./components/admin/AddProvider";
import Info_Provider from "./components/admin/Info_Provider";
import Detail_Accessories from "./components/admin/Detail_Accessories";
import Creat_CPU from "./components/admin/Creat_CPU";
import Creat_Accessories from "./components/admin/Creat_Accessories";
import Accessories_All from "./components/admin/Accessories_All";
import List_delivery from "./components/admin/List_Delivery";
import List_delivery2 from "./components/storekeeper/List_Delivery2";
import Order_Detail from "./components/master/Order_Detail";
import List_Master from "./components/master/List_Master";
import Detail_info from "./components/master/Detail_info";
import Creat_Equepmen from "./components/master/Creat_Equepmen";
import Input_service from "./components/master/Input_service";
import Creat_Motherboard from "./components/admin/Creat_Motherboard";
import Creat_RAM from "./components/admin/Creat_RAM";
import Creat_Radio_component from "./components/admin/Creat_Radio_component";

var x = "";
getrole2().then(res => { x = res })

var b = "";
admin().then(res => { b = res })

var c = "";
dispatcher().then(res => { c = res })

var s= "";
storekeeper().then(res => { s = res })

var m= "";
master().then(res => { m = res })


const App: FC<{}> = (): ReactElement => {
    loadUser();
    const [userrole, setrole] = useState("");

    async function getrole2() {
        const role2 = await getrole()
        setrole(role2.role);
    }

    useEffect(() => {
        setTimeout(getrole2, 500);
    }, []);

    if (b === x || userrole== "admin")
    {
       return (           
               <div>
                <Navigation_menu/>      
                       <AuthProvider userManager={userManager}>
                           <BrowserRouter>
                               <Routes>               
                                   <Route path="/" element={<Adminlist/>} />    
                                   <Route path="provider/:name_Company" element={<Info_Provider/>} /> 
                                   <Route path="/detail/:iD_Accessories" element={<Detail_Accessories/>} />  
                                   <Route path="/create" element={<AddProvider/>} />
                                   <Route path="/listDelivery" element={<List_delivery/>} />       
                                   <Route path="accessories/all" element={<Accessories_All/>} />
                                   <Route path="provider/create/:name_Company" element={<Creat_Accessories/>} />         
                                   <Route path="create/cpu/:name_Company" element={<Creat_CPU/>} />  
                                   <Route path="create/motherboard/:name_Company" element={<Creat_Motherboard/>} /> 
                                   <Route path="create/RAM/:name_Company" element={<Creat_RAM/>} />       
                                   <Route path="create/Radio_component/:name_Company" element={<Creat_Radio_component/>} />                             
                                   <Route path="/signout-oidc" element={<SignOutOidc />} />
                                   <Route path="/signin-oidc" element={<SignInOidc />} />
                               </Routes>
                           </BrowserRouter>
                       </AuthProvider>
               </div>      
       ); 
    } 
    if (userrole === "storekeeper" || s === x)
    {
       return (           
               <div>
                <Navigation_menu/>      
                       <AuthProvider userManager={userManager}>
                           <BrowserRouter>
                               <Routes>               
                                   <Route path="/" element={<List_delivery2/>} />       
                               </Routes>
                           </BrowserRouter>
                       </AuthProvider>
               </div>      
       ); 
    }     
    if (userrole === "serviceman"  || m === x)
    {
       return (           
               <div>
                <Navigation_menu/>      
                       <AuthProvider userManager={userManager}>
                           <BrowserRouter>
                               <Routes>               
                                   <Route path="/" element={<List_Master/>} />  
                                   <Route path="detail/:id" element={<Order_Detail/>} />   
                                   <Route path="/creat/:id_order" element={<Creat_Equepmen/>} />         
                                   <Route path="/accessories/:iD_Accessories" element={<Detail_info/>} />               
                                   <Route path="/creat_services/:id_order" element={<Input_service/>} />                      
                               </Routes>
                           </BrowserRouter>
                       </AuthProvider>
               </div>      
       ); 
    }  
    if (userrole === "dispatcher"|| c === x){ 
    return (
        <div>                    
                  <Navigation_menu/>
                    <AuthProvider userManager={userManager}>
                        <BrowserRouter>
                            <Routes>
                                <Route path="/" element={<Orderlist />} />
                                <Route path=":id" element={<DetailOrder/>} />
                                <Route path="personal/:id" element={<DetailOrder/>} /> 
                                <Route path="create" element={<Create_Order/>} /> 
                                <Route path="allpersonnal" element={<Create_Order/>} /> 
                                <Route path="create" element={<Create_Order/>} /> 
                                <Route path="/signout-oidc" element={<SignOutOidc />} />
                                <Route path="/signin-oidc" element={<SignInOidc />} />
                                <Route path="/creat/:id_order" element={<Creat_Equepmen/>} />         
                                <Route path="/accessories/:iD_Accessories" element={<Detail_info/>} />         
                            </Routes>
                        </BrowserRouter>
                    </AuthProvider>
        </div>
    );
    } else{
    return(
        <div>
              <Navigation_menu/>
        </div>
    )
    }
};

export default App;
