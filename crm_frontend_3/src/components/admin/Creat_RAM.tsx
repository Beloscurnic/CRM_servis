import React, { FC, ReactElement, useRef, useEffect, ChangeEvent, ChangeEventHandler, useState,useMemo } from 'react';
import {  CreateClient,Create_RAMDto} from '../../api/api2';
import { NavLink, useParams } from 'react-router-dom';
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
    price: number;
    memory_type: string ;
    form_factor: string ;
    memory_module_key: string ;
    volume: string ;
    clock_frequency: string;
    timing: string ;
    name_Company: string ;
}

async function create_rAM(motherboard: Create_RAMDto) {
    await apiClient.creat_rAM('2.0', motherboard);
  //  console.log('Order_Client is created.');
   window.location.reload();
}

const Creat_RAM: FC<{}> = (): ReactElement => {
    const navigate = useNavigate();
    const pavolumes = useParams();
    const name_Company2 = pavolumes.name_Company;


    const { register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });

    const onSubmit = handleSubmit(({ name_Сomponent, price, memory_type, memory_module_key, volume,clock_frequency, timing,
      form_factor
       }: any) => {

        const rAM: Create_RAMDto = {
            name_Сomponent: name_Сomponent,
            price: price,
            memory_type: memory_type ,
            memory_module_key: memory_module_key ,
            volume: volume,
            clock_frequency: clock_frequency,
            timing: timing,
            form_factor: form_factor,
            name_Company: name_Company2!
        };
        create_rAM(rAM);
        
        navigate(`/provider/${name_Company2}`);    
    })
    return(
    <div>
         <div>
                <form className="App" action='' onSubmit={onSubmit} >
                <h1 className='h1_creat'>Добавить новую ОЗУ </h1>
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
                               
                            })}
                            name="name_Сomponent"
                            type="text" />
                       <p role="alert"> {errors.name_Сomponent && errors.name_Сomponent.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.name_Сomponent && errors.name_Сomponent.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='memory_type'>Тип памяти</label>
                        <input
                           
                            id="memory_type"
                            aria-invalid={errors.memory_type ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="memory_type"
                            type="text" />
                        <p role="alert"> {errors.memory_type && errors.memory_type.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.memory_type && errors.memory_type.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='memory_module_key'>Ключ модуля памяти объём </label>
                        <input
                            id="memory_module_key"
                            aria-invalid={errors.memory_module_key ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },                            
                            })}
                            name="memory_module_key"
                            type="text" />
                        <p role="alert"> {errors.memory_module_key && errors.memory_module_key.type  === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.memory_module_key && errors.memory_module_key.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>                     
                    </div>
                    <div>
                        <label htmlFor='volume'>Объём </label>
                        <input
                            id="volume"
                            aria-invalid={errors.volume ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },   
                            })}
                            name="volume"
                            type="text" />
                        <p role="alert"> {errors. volume  && errors.volume .type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.volume  && errors.volume .type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>    
                    </div>
                    <div>
                        <label htmlFor='clock_frequency'>Тактовая частота</label>
                        <input
                           
                            id="clock_frequency"
                            aria-invalid={errors. clock_frequency ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="clock_frequency"
                            type="text" />
                       <p role="alert"> {errors.clock_frequency && errors.clock_frequency.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.clock_frequency && errors.clock_frequency.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='timing'>Тайминг</label>
                        <input
                           
                            id="timing"
                            aria-invalid={errors.timing ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="timing"
                            type="text" />
                       <p role="alert"> {errors.timing && errors.timing.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.timing && errors.timing.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                  
                    <div>
                        <label htmlFor='form_factor'>Форм фактор</label>
                        <input
                           
                            id="form_factor"
                            aria-invalid={errors. form_factor ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="form_factor"
                            type="text" />
                       <p role="alert"> {errors.form_factor && errors.form_factor.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.form_factor && errors.form_factor.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='price'>Цена за штуку</label>
                        <input      
                            id="price"
                            aria-invalid={errors.price ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value:/^[0-9]+$/,
                                    message: "error message3"
                                },
                            })}
                            name="price"
                            type="text" />
                       <p role="alert"> {errors.price && errors.price.type === "pattern" &&  "⚠️ "+"Не должно содержать символы"}</p>
                       <p role="alert"> {errors.price && errors.price.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <button type="submit"> Submit </button>
                    </div>
                </form>

            </div>
    </div>
)
}
export default Creat_RAM