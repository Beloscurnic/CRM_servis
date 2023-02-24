import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import {AccessoriesClient,Accessories_CPUVm,TypeClient,Type_AccessoriesVm,Get_AccessoriesVm,Update_AccessoriesDto,UpdateClient,CreateClient,Creat_DeliveryDto } from '../../api/api2';
import { NavLink,useParams ,useNavigate} from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import '../Orderlist/squere.css'

import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import '../Orderlist/detail_order.css';
import { appendErrors, useForm,Controller } from 'react-hook-form'


const apiClient = new AccessoriesClient('https://localhost:44325');
const apiClient2 = new TypeClient('https://localhost:44325');
const apiClient3 = new UpdateClient('https://localhost:44325');
const apiClient4 = new CreateClient('https://localhost:44325');

interface FormData {
    quantity_Сomponent: number;
    issue_date:string;
}

async function creat_delivery(delivery: Creat_DeliveryDto) {
    await apiClient4.creat_delivery('2.0', delivery);
  //  console.log('Order_Client is created.');
    window.location.reload();
}

const Detail_info: FC<{}> = (): ReactElement => {
  //  const params = useParams();
   // const type_Сomponent ="CPU" //params.type_Сomponent;
    const navigate = useNavigate();
     const params2 = useParams();
     const iD_Accessories = params2.iD_Accessories;


     const [id_component, setProvider] = useState<Type_AccessoriesVm>();


     async function get_type_Accessoroes() {
        return new Promise<string>( async(resolve) => {
            let type;
        const infotype = await apiClient2.type_accessories(parseInt(iD_Accessories!),'2.0');
        setProvider(infotype);
        type=infotype.type_Сomponent;
        resolve(type);
        })};

     const [cpu, setCPU] = useState<Accessories_CPUVm>();

     async function getAccessoroes() {
         const infoCPU = await apiClient.Accessories_cPU(parseInt(iD_Accessories!),'2.0');
         setCPU(infoCPU);
     }

      const [component, setcomponent] = useState<Get_AccessoriesVm>();

     async function get_Accessoroes() {
        const infocomponent = await apiClient2.get_accessories(parseInt(iD_Accessories!),'2.0');
        setcomponent(infocomponent);
     }

     useEffect(() => {
         setTimeout(getAccessoroes, 10) 
     }, []);
     useEffect(() => {
        setTimeout(get_type_Accessoroes, 10) 
    }, []);
    useEffect(() => {
        setTimeout(get_Accessoroes, 10) 
    }, []);
   
   


    
    if(id_component?.type_Сomponent=="CPU")
    {
        return(
            <div>
                <div className='div_header'>
                    <h1> ID компонента: { iD_Accessories}</h1>
                 </div>
            <div className='div_order'>
            <table  className='table'>
                <tr>
                    <td> Уникальный номер</td>
                    <td> {cpu?.iD_Сomponent}</td>
                </tr>
                <tr>
                    <td> Полное название</td>
                    <td> {cpu?.name_Сomponent}</td>
                </tr>
                <tr>
                    <td> Количество ядер</td>
                    <td> {cpu?.number_Cores}</td>
                </tr>
                <tr>
                    <td> Тактовая частота ядра</td>
                    <td> {cpu?.purity_CPU}</td>
                </tr>
                <tr>
                    <td> Цена</td>
                    <td> {cpu?.price_CPU}</td>
                </tr>
                <tr>
                    <td> Поставщик</td>
                    <td> {component?.name_Company}</td>
                </tr>
            </table>
            </div>
            <div>
         
            </div>
           
        </div>
        )
    } 
    return(
        <div>
          {id_component?.type_Сomponent}
        </div>
    )
}
export default Detail_info