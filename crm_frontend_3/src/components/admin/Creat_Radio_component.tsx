import React, { FC, ReactElement, useRef, useEffect, ChangeEvent, ChangeEventHandler, useState,useMemo } from 'react';
import {  RadioClient,Create_Radio_componentsDto} from '../../api/api2';
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



const apiClient = new RadioClient('https://localhost:44325');

interface FormData {
    name_Сomponent: string;
    price: number;
    options: string;
    name_Company: string;
}

async function create_radio_component(radio_component: Create_Radio_componentsDto) {
    await apiClient.creat_component('2.0', radio_component);
  //  console.log('Order_Client is created.');
   window.location.reload();
}

const Creat_Radio_component: FC<{}> = (): ReactElement => {
    const navigate = useNavigate();
    const pavolumes = useParams();
    const name_Company2 = pavolumes.name_Company;


    const { register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });

    const onSubmit = handleSubmit(({ name_Сomponent, price, options
       }: any) => {

        const radio_component: Create_Radio_componentsDto = {
            name_Сomponent: name_Сomponent,
            price: price,
            options: options,
            name_Company: name_Company2!
        };
        create_radio_component(radio_component);
        navigate(`/provider/${name_Company2}`);    
    })
    return(
    <div>
         <div>
                <form className="App" action='' onSubmit={onSubmit} >
                <h1 className='h1_creat'>Добавить Радиодеталь </h1>
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
                        <label htmlFor='options'>Характеристики</label>
                        <input
                            id="options"
                            aria-invalid={errors.options ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                            })}
                            name="options"
                            type="text" />
                        <p role="alert"> {errors.options && errors.options.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.options && errors.options.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
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
export default Creat_Radio_component