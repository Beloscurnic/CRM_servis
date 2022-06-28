import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import {  Client, Order_Client_DetailsVm, List_Order_Client } from '../../api/api';
import { NavLink,useParams } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';

const apiClient = new Client('https://localhost:44325');

const DetailOrder: FC<{}> = (): ReactElement => {
   loadUser()
   const [ordersdetail, setOrders] = useState< Order_Client_DetailsVm| undefined>(undefined);
//   const  { prodId }  = useParams();
        const params = useParams();
        const prodId = params.id;
    async function getOrder() {
        console.log(prodId);
        const orderDetailtVm = await apiClient.get(parseInt(prodId!), '1.0')
        setOrders(orderDetailtVm);
    }
    useEffect(() => {
        setTimeout(getOrder, 500);
    }, []);


    return (
        <div>
               {ordersdetail?.price} {ordersdetail?.lastName_Client}{ordersdetail?.name_Client}
        </div>
    );
};
export default DetailOrder;