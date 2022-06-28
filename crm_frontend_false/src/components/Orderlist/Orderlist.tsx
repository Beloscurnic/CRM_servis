import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { Create_Order_ClientDto, Client, List_Order_Client } from '../../api/api';
import { FormControl } from 'react-bootstrap';
import styles from './styles.module.css';
import AuthProvider from '../../auth/auth-provider';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import DetailOrder from '../Orderlist/DetailOrder';
import { NavLink } from 'react-router-dom';
import matchSorter from "match-sorter";
import Select from "react-select";
import { render } from "react-dom";
import Table_Orders from './Table_Orders';



const apiClient = new Client('https://localhost:44325');

async function createOrder(order: Create_Order_ClientDto) {
    await apiClient.create('1.0', order);
    console.log('Order_Client is created.');
}

const OrderList: FC<{}> = (): ReactElement => {
    loadUser();
    let textInput = useRef(null);
    const [orders, setOrders] = useState<List_Order_Client[] | undefined>(undefined);
    

    async function getOrder() {
        const orderListVm = await apiClient.getAll('1.0')
       // console.log(orderListVm);
        setOrders(orderListVm.orders);
        return orderListVm;
    }

    useEffect(() => {
        setTimeout(getOrder, 500);
    }, []);

    const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            const order: Create_Order_ClientDto = {
                iD_Client: parseInt(event.currentTarget.value),
            };

            createOrder(order);
            event.currentTarget.value = '';
            setTimeout(getOrder, 500);
        }
    };

    return (
        <div>
            Orders
            <div>
                <FormControl ref={textInput} onKeyPress={handleKeyPress} />
            </div>
            <section>
                <Table_Orders/>
                {/* <table className={styles.table_dark}>
                    <tr>
                        <th>ID заказа </th>
                        <th> Имя </th>
                        <th> Фамилия</th>
                        <th> Email</th>
                        <th> телефон</th>
                        <th> Цена</th>
                    </tr>
                    {orders?.map((order) => (
                    <tr key={order.iD_Order}>  
                        <td>{order.iD_Order}</td>
                        <td>{order.name_Client}</td>
                        <td>{order.lastName_Client} </td>
                        <td>{order.telefon}</td>
                        <td>{order.email_Client}</td>
                        <td>{order.price} </td>
                        <td> 
                        <NavLink to={`${order.iD_Order}`}>Детали</NavLink>                     
                        </td>
                    </tr>
         
                ))} */}
                 {/* <tr>
                     {orders?.map(order=>{
                         if(order.name_Client ==="eqqeq"){
                             return (
                                 <td> {order.name_Client}</td>

                             )
                         }
                     })}
                 </tr> */}
                {/* </table> */}
            </section>
        </div>
    );
};
export default OrderList;