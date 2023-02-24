import React, { FC, ReactElement, useRef, useEffect, useState,useMemo, } from 'react';
import { useNavigate } from 'react-router-dom';
import { appendErrors, useForm } from 'react-hook-form'
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import '../Orderlist/table.css';
import { NavLink,useParams } from 'react-router-dom'
import { Creat_servicesDto,Creat_Equipment, List_EquipmentVm,List_Equipment,ListClient,DeleteClient,Delet_EquipmentDto,List_Services} from '../../api/api3';
import { Order_Client_DetailsVm, PersonnalVm } from '../../api/api';
import { Update_Order_ClientDto,Create_Order_ClientDto, Client, List_Order_Client } from '../../api/api';
const apiClient = new Client('https://localhost:44325');
const apiClient2 = new ListClient('https://localhost:44325');
const apiClient3 = new DeleteClient('https://localhost:44325');
const apiClient4 = new Creat_Equipment('https://localhost:44325');



async function create_service(services: Creat_servicesDto) {
    await apiClient4.creat_services('3.0', services);
  //  console.log('Order_Client is created.');
  //  window.location.reload();
}
async function update_order(services: Update_Order_ClientDto) {
  
    await apiClient.update_status1('1.0',services);
}

interface FormData {
    iD_Order: number;
    name: string ;
    description: string ;
    warranty: string ;
    price_services: number;
}

const Input_service: FC<{}> = (): ReactElement => {
    const navigate = useNavigate();
    const params = useParams();
    const iD_Order2 = params.id_order;
 console.log(iD_Order2)
    
    const { register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });

    const [ordersdetail, setOrders] = useState<Order_Client_DetailsVm>();

    async function getOrder() {
       
        const iD_Order3=parseInt(iD_Order2!);
           const orderDetailtVm = await apiClient.get(iD_Order3, '1.0')
           setOrders(orderDetailtVm);
       };
       useEffect(() => {
        setTimeout(getOrder, 10)
    }, []);

    const onSubmit = handleSubmit(({ name, description, price_services, warranty
       }: any) => {
        const iD_Order=parseInt(iD_Order2!);
        const services: Creat_servicesDto = {
            name: name,
            description: description,
            price_services:price_services,
            warranty:warranty,
            iD_Order: iD_Order
        };
        const status: Update_Order_ClientDto = {
            iD_Order :iD_Order,
            status_Order:"Ремонт"
         };
        create_service(services);
        update_order(status);
        navigate(`/detail/${iD_Order}`);   
        getOrder()
    })
    return(
        <div>
        <div>
               <form className="App" action='' onSubmit={onSubmit} >
               <h1 className='h1_creat'>Добавить оказанную услугу</h1>
                   <div>
                       <label htmlFor='name'>Название оказаной работы</label>
                       <input        
                           id="name"
                           aria-invalid={errors.name ? "true" : "false"}
                           ref={register({
                               required: true,
                               pattern: {
                                   value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                   message: "error message3"
                               },
                               maxLength:
                               {
                                   value: 20,
                                   message: 'error message2'
                               },
                           })}
                           name="name"
                           type="text" />
                      <p role="alert"> {errors.name && errors.name.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                      <p role="alert"> {errors.name && errors.name.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                      <p role="alert"> {errors.name && errors.name.type === "maxLength" && "⚠️ "+"Максимальное количество символов 30"}</p>
                   </div>
                   <div>
                       <label htmlFor='description'>Описание проделанной работы</label>
                       <input
                           id="description"
                           aria-invalid={errors.description ? "true" : "false"}
                           ref={register({
                               required: true,
                            
                           })}
                           name="description"
                           type="text" />
                      <p role="alert"> {errors.description && errors.description.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                   </div>
                   <div>
                       <label htmlFor='price_services'> Цена работы</label>
                       <input
                           id="price_services"
                           aria-invalid={errors.price_services ? "true" : "false"}
                           ref={register({
                               required: true,
                               pattern: {
                                   value: /^[0-9]+$/,
                                   message: "error message3"
                               },                            
                           })}
                           name="price_services"
                           type="text" />
                       <p role="alert"> {errors.price_services && errors.price_services.type  === "pattern" &&  "⚠️ "+"Не должно содержать символы"}</p>
                      <p role="alert"> {errors.price_services && errors.price_services.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>                     
                   </div>
                   <div>
                       <label htmlFor='warranty'> Гарантия в месяцах</label>
                       <input
                           id="warranty"
                           aria-invalid={errors.warranty ? "true" : "false"}
                           ref={register({
                               required: true,
                               pattern: {
                                   value: /^[0-9]+$/,
                                   message: "error message3"
                               },                            
                           })}
                           name="warranty"
                           type="text" />
                       <p role="alert"> {errors.warranty && errors.warranty.type  === "pattern" &&  "⚠️ "+"Не должно содержать символы"}</p>
                      <p role="alert"> {errors.warranty && errors.warranty.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>                     
                   </div>
                   <div>
                       <button type="submit"> Submit </button>
                   </div>
               </form>
           </div>
   </div>
    )
}
export default Input_service