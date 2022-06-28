import React, { FC, ReactElement, useRef, useEffect, ChangeEvent, ChangeEventHandler, useState,useMemo } from 'react';
import {  CreateClient,Create_CPUDto } from '../../api/api2';
import { NavLink,useParams } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import '../Orderlist/table.css';
import { Value } from 'sass';
import { Console } from 'console';
import { appendErrors, useForm } from 'react-hook-form'
import './styles.css'
import '../Orderlist/creat_order.css'
import { useNavigate } from 'react-router-dom';

import "./styles/Creat_Accessories.css"



const apiClient = new CreateClient('https://localhost:44325');

interface FormData {
    name_Сomponent: string ;
    price_CPU: number;
    quantity_CPU: number;
    number_Cores: number;
    purity_CPU: string ;
    name_Company: string;
}

async function create_CPU(cpu: Create_CPUDto) {
    await apiClient.cPU('2.0', cpu);
  //  console.log('Order_Client is created.');
   window.location.reload();
}

const Creat_CPU: FC<{}> = (): ReactElement => {
    const navigate = useNavigate();
    const params = useParams();
    const name_Company2 = params.name_Company;


    const { register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });

    const onSubmit = handleSubmit(({ name_Сomponent, price_CPU, quantity_CPU, number_Cores, purity_CPU,
       }: any) => {

        const cpu: Create_CPUDto = {
            name_Сomponent: name_Сomponent,
            price_CPU: price_CPU,
            quantity_CPU:quantity_CPU,
            number_Cores: number_Cores,
            purity_CPU: purity_CPU,
            name_Company: name_Company2!
        };
        create_CPU(cpu);
        
        navigate(`/provider/${name_Company2}`);    
    })
    return(
    <div>
         <div>
                <form className="App" action='' onSubmit={onSubmit} >
                <h1 className='h1_creat'>Добавить новый процессор </h1>
                    <div>
                        <label htmlFor='name_Сomponent'>Полное название компонента</label>
                        <input
                           
                            id="name_Сomponent"
                            aria-invalid={errors. name_Сomponent ? "true" : "false"}
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
                            name="name_Сomponent"
                            type="text" />
                       <p role="alert"> {errors.name_Сomponent && errors.name_Сomponent.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.name_Сomponent && errors.name_Сomponent.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                       <p role="alert"> {errors.name_Сomponent && errors.name_Сomponent.type === "maxLength" && "⚠️ "+"Максимальное количество символов 20"}</p>
                    </div>
                    <div>
                        <label htmlFor='number_Cores'>Количество ядер</label>
                        <input
                           
                            id="number_Cores"
                            aria-invalid={errors.number_Cores ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[0-9]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="number_Cores"
                            type="text" />
                        <p role="alert"> {errors.number_Cores && errors. number_Cores.type === "pattern" &&  "⚠️ "+"Не должно содержать символы"}</p>
                       <p role="alert"> {errors. number_Cores && errors. number_Cores.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='purity_CPU'>Тактовая частота</label>
                        <input
                            id="purity_CPU"
                            aria-invalid={errors.purity_CPU ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[0-9+"."]+$/,
                                    message: "error message3"
                                },                            
                            })}
                            name="purity_CPU"
                            type="text" />
                        <p role="alert"> {errors.purity_CPU && errors.purity_CPU.type  === "pattern" &&  "⚠️ "+"Не должно содержать символы"}</p>
                       <p role="alert"> {errors.purity_CPU && errors.purity_CPU.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>                     
                    </div>
                    <div>
                        <label htmlFor='quantity_CPU'>Рабочее напряжение</label>
                        <input
                            id="quantity_CPU"
                            aria-invalid={errors.quantity_CPU ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[0-9]+$/,
                                    message: "error message3"
                                },   
                            })}
                            name="quantity_CPU"
                            type="text" />
                        <p role="alert"> {errors. quantity_CPU  && errors.quantity_CPU .type === "pattern" &&  "⚠️ "+"Не должно содержать символы"}</p>
                       <p role="alert"> {errors.quantity_CPU  && errors.quantity_CPU .type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>    
                    </div>
                    <div>
                        <label htmlFor='price_CPU'>Цена за штуку</label>
                        <input      
                            id="price_CPU"
                            aria-invalid={errors.price_CPU ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value:/^[0-9]+$/,
                                    message: "error message3"
                                },
                            })}
                            name="price_CPU"
                            type="text" />
                       <p role="alert"> {errors.price_CPU && errors.price_CPU.type === "pattern" &&  "⚠️ "+"Не должно содержать символы"}</p>
                       <p role="alert"> {errors.price_CPU && errors.price_CPU.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <button type="submit"> Submit </button>
                    </div>
                </form>

            </div>
    </div>
)
}
export default Creat_CPU