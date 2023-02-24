import React, { FC, ReactElement, useRef, useEffect, ChangeEvent, ChangeEventHandler, useState,useMemo } from 'react';
import {  CreateClient,Create_MotherboardDto} from '../../api/api2';
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
    name_Сomponent: string;
    price: number;
    motherboard_socket: string ;
    motherboard_chipset: string ;
    ram: string ;
    disk_controllers: string ;
    expansion_slots: string ;
    net: string;
    audio_and_video: string ;
    form_factor: string ;
    name_Company: string ;
}

async function create_motherboard(motherboard: Create_MotherboardDto) {
    await apiClient.creat_motherboard('2.0', motherboard);
  //  console.log('Order_Client is created.');
   window.location.reload();
}

const Creat_Motherboard: FC<{}> = (): ReactElement => {
    const navigate = useNavigate();
    const params = useParams();
    const name_Company2 = params.name_Company;


    const { register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });

    const onSubmit = handleSubmit(({ name_Сomponent, price, motherboard_socket, motherboard_chipset, ram,disk_controllers, expansion_slots,
        net,audio_and_video,form_factor
       }: any) => {

        const motherboard: Create_MotherboardDto = {
            name_Сomponent: name_Сomponent,
            price: price,
            motherboard_socket: motherboard_socket ,
            motherboard_chipset: motherboard_chipset ,
            ram: ram,
            disk_controllers: disk_controllers,
            expansion_slots: expansion_slots,
            net: net,
            audio_and_video: audio_and_video,
            form_factor: form_factor,
            name_Company: name_Company2!
        };
        create_motherboard(motherboard);
        
        navigate(`/provider/${name_Company2}`);    
    })
    return(
    <div>
         <div>
                <form className="App" action='' onSubmit={onSubmit} >
                <h1 className='h1_creat'>Добавить новую материскую плату </h1>
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
                        <label htmlFor='motherboard_socket'>Сокет материнской платы</label>
                        <input
                           
                            id="motherboard_socket"
                            aria-invalid={errors.motherboard_socket ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="motherboard_socket"
                            type="text" />
                        <p role="alert"> {errors.motherboard_socket && errors.motherboard_socket.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.motherboard_socket && errors.motherboard_socket.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='motherboard_chipset'>Чипсет материнской платы</label>
                        <input
                            id="motherboard_chipset"
                            aria-invalid={errors.motherboard_chipset ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },                            
                            })}
                            name="motherboard_chipset"
                            type="text" />
                        <p role="alert"> {errors.motherboard_chipset && errors.motherboard_chipset.type  === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.motherboard_chipset && errors.motherboard_chipset.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>                     
                    </div>
                    <div>
                        <label htmlFor='ram'>Оперативная память</label>
                        <input
                            id="ram"
                            aria-invalid={errors.ram ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },   
                            })}
                            name="ram"
                            type="text" />
                        <p role="alert"> {errors. ram  && errors.ram .type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.ram  && errors.ram .type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>    
                    </div>
                    <div>
                        <label htmlFor='disk_controllers'>Дисковые контроллеры</label>
                        <input
                           
                            id="disk_controllers"
                            aria-invalid={errors. disk_controllers ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="disk_controllers"
                            type="text" />
                       <p role="alert"> {errors.disk_controllers && errors.disk_controllers.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.disk_controllers && errors.disk_controllers.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='expansion_slots'>Слоты расширения</label>
                        <input
                           
                            id="expansion_slots"
                            aria-invalid={errors.expansion_slots ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="expansion_slots"
                            type="text" />
                       <p role="alert"> {errors.expansion_slots && errors.expansion_slots.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.expansion_slots && errors.expansion_slots.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='net'>Сеть</label>
                        <input
                           
                            id="net"
                            aria-invalid={errors. net ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="net"
                            type="text" />
                       <p role="alert"> {errors.net && errors.net.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.net && errors.net.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                    </div>
                    <div>
                        <label htmlFor='audio_and_video'>Встроенные аудио и видео</label>
                        <input
                           
                            id="audio_and_video"
                            aria-invalid={errors. audio_and_video ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "+","+\\-]+$/,
                                    message: "error message3"
                                },
                               
                            })}
                            name="audio_and_video"
                            type="text" />
                       <p role="alert"> {errors.audio_and_video && errors.audio_and_video.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.audio_and_video && errors.audio_and_video.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
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
export default Creat_Motherboard