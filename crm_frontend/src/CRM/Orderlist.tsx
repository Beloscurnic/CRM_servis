import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { Create_Order_ClientDto, Client, List_Order_Client } from '../api/api';
import { FormControl } from 'react-bootstrap';
import { Console } from 'console';

const apiClient = new Client('https://localhost:44325');

async function createOrder(order: Create_Order_ClientDto) {
    await apiClient.create('1.0', order);
    console.log('Order_Client is created.');
}

const OrderList: FC<{}> = (): ReactElement => {
    let textInput = useRef(null);
    const [orders, setOrders] = useState<List_Order_Client[] | undefined>(undefined);

    async function getOrder() {
        const orderListVm = await apiClient.getAll('1.0')
       // console.log(orderListVm);
        setOrders(orderListVm.orders);
    }

    useEffect(() => {
        setTimeout(getOrder, 500);
    }, []);

    const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            const order: Create_Order_ClientDto = {
                iD_Client: event.currentTarget.value,
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
                {orders?.map((order) => (
                    <div>{order.iD_Order} {order.price}  {order.email_Client} </div>
                 
                ))}
            </section>
        </div>
    );
};
export default OrderList;