import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import {AccessoriesClient,Accessories_CPUVm,TypeClient,Type_AccessoriesVm,Get_AccessoriesVm,Update_AccessoriesDto,UpdateClient,CreateClient,Creat_DeliveryDto } from '../../api/api2';
import { NavLink,useParams ,useNavigate} from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import '../Orderlist/squere.css'

import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import '../Orderlist/detail_order.css';
import { appendErrors, useForm,Controller } from 'react-hook-form'
import Detail_RAM from './Detail_RAM';
import Detail_Motherboard from './Detail_Motherboard';
import Detail_Radio_component from './Detail_Radio_component';


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
   // window.location.reload();
}

const Detail_Accessories: FC<{}> = (): ReactElement => {
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
   
    async function handleClick(id: string, status: string){

        const id2=parseInt(id);
        if(status =="Активный")
        {
        const accessor: Update_AccessoriesDto = {
            iD_Accessories:  id2,
            сharacteristics_info: "Не поставляют",
         };
        
        await apiClient3.update_Accessories('2.0',accessor);
        get_Accessoroes();
        } else
        if(status =="Не поставляют")
        {
        const accessor2: Update_AccessoriesDto = {
            iD_Accessories:  id2,
            сharacteristics_info: "Активный",
         };
        
        await apiClient3.update_Accessories('2.0',accessor2);
        get_Accessoroes();
        }
    }


    const { control, register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });
    const [startDate, setStartDate] = useState<Date|null>(new Date());

    const onSubmit = handleSubmit(({quantity_Сomponent, issue_date
       }: any) => {
        // let arr = issue_date.split('.');
        // var date1 = arr[2]+"-"+arr[1]+"-"+arr[0];
        // console.log(date1);
        const delivery: Creat_DeliveryDto = {
            iD_Accessories: parseInt(iD_Accessories!),
            iD_Сomponent: cpu!.iD_Сomponent,
            name_Сomponent: cpu!.name_Сomponent,
            type_Сomponent: id_component!.type_Сomponent,
            price_Сomponent: cpu!.price_CPU,
            quantity_Сomponent: quantity_Сomponent,
            issue_date: issue_date,
            name_Company: component!.name_Company
        };
        creat_delivery(delivery);
        alert("Заказ сделан")
        navigate(`/provider/${component!.name_Company}`);    
    })


    
    const normalizeTel = (value: string) => {
        if(value.length < 11){
        value = value.replace(/\D/g, "");
        value = value.replace(/^(\d{2})(\d)/g, "$1/$2");
        value = value.replace(/(\d{2})(\d{2})/, "$1/$2"); 
        return value
        } else{
        const str2 = value.substring(0, value.length - 1);
        return str2;
        }
    };

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
            </table>
            </div>
            <div className='div_header'>
                <h1>Поставляется компанией: {component?.name_Company}  </h1>
                <h1>Текущий статус: {component?.сharacteristics_info} <button className="button-login2" onClick={async()=> {await handleClick(iD_Accessories!, component?.сharacteristics_info!)}}>Поменять статус!</button>    </h1>      
            </div>
            <div>
            <form className="App" action='' onSubmit={onSubmit} >
                <h1 className='h1_creat'>Добавить новый процессор </h1>
                    <div>
                        <label htmlFor='quantity_Сomponent'>Количество </label>
                        <input
                            id="quantity_Сomponent"
                            aria-invalid={errors. quantity_Сomponent ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[0-9]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="quantity_Сomponent"
                            type="text" />
                       <p role="alert"> {errors.quantity_Сomponent && errors.quantity_Сomponent.type === "pattern" &&  "⚠️ "+"Не содержать символы"}</p>
                       <p role="alert"> {errors.quantity_Сomponent && errors.quantity_Сomponent.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>      
                    <div>
                    <label htmlFor='issue_date'>Дата доставки </label>
                        <input
                            id="issue_date"
                            aria-invalid={errors.issue_date ? "true" : "false"}
                            onChange={(event) => {
                                const { value } = event.target;
                                event.target.value = normalizeTel(value);
                            }}
                            ref={register({
                                required: true,
                                pattern: /[0-9]{2}[/][0-9]{2}[/][0-9]{4}/,
                               
                            })}
                            name="issue_date"
                            type="text" />
                       <p role="alert"> {errors. issue_date && errors.issue_date.type === "pattern" &&  "⚠️ "+"Не соотвествует формату YYYY/MM/DD"}</p>
                       <p role="alert"> {errors. issue_date && errors.issue_date.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                      
                       </div>
                    <div>
                        <button type="submit"> Submit </button>
                    </div>
                </form>
            </div>
           
        </div>
        )
    } 
    if(id_component?.type_Сomponent=="RAM")
    {
        return(
            <div>
                <Detail_RAM iD_Accessories={iD_Accessories!}/>
            </div>
        )
    }
    if(id_component?.type_Сomponent=="Motherboard")
    {
        return(
            <div>
                  <Detail_Motherboard iD_Accessories={iD_Accessories!}/>
            </div>
        )
    }
    if(id_component?.type_Сomponent=="Radio_component")
    {
        return(
            <div>
                  <Detail_Radio_component iD_Accessories={iD_Accessories!}/>
            </div>
        )
    }
    return(
        <div>
          {id_component?.type_Сomponent}
        </div>
    )
}
export default Detail_Accessories