import React, { FC, ReactElement, useRef, useEffect, useState, useMemo } from 'react';
import { CreateClient,List_Provider,Create_ProviderDto} from '../../api/api2';
import { FormControl } from 'react-bootstrap';
import { loadUser, getrole,dispatcher } from '../../auth/user-service';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";

import '../Orderlist/creat_order.css'
import { format, formatDistance, formatRelative, subDays } from 'date-fns';
import generateExcel from "zipcelx";
import { NavLink } from 'react-router-dom';
import { appendErrors, useForm } from 'react-hook-form'
import { useNavigate } from 'react-router-dom';

interface FormData {
    name_Company: string ;
    identification_Number: string ;
    supplier_Address: string ;
    fiO_Director: string;
    telefon: string ;
    status: string;
    comments: string;
}

async function createProvider(provider: Create_ProviderDto) {
    await apiClient.creat_provider('2.0', provider);
   // window.location.reload();
   
}


const apiClient = new CreateClient('https://localhost:44325');

const AddProvider: FC<{}> = (): ReactElement => {
    const navigate = useNavigate();
    const [name, setName] = useState('Create');
    const { register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });
   
    const onSubmit = handleSubmit(({ name_Company, identification_Number,supplier_Address,  fiO_Director, telefon,
        status, comments}: any) => {

        const provider: Create_ProviderDto = {
            name_Company:  name_Company,
            identification_Number: identification_Number,
            supplier_Address:supplier_Address,
            fiO_Director:  fiO_Director,
            telefon: telefon,
            status:  status,
            comments: comments
        };
        createProvider(provider);
        navigate('/');
    })

    const normalizeTel = (value: string) => {
        if(value.length < 11){
            value = value.replace(/\D/g, "");
        value = value.replace(/^(\d{3})(\d)/g, "$1-$2");
        value = value.replace(/(\d{3})(\d{3})/, "$1-$2");
            return value
            } else{
            const str2 = value.substring(0, value.length - 1);
            return str2;
            }
        return value;
    };

 
    return(
        <div>
 <div>
                <form className="App" action='' onSubmit={onSubmit} >
                <h1 className='h1_creat'>Заполните поля</h1>
                    <div>
                        <label htmlFor='name_Company'>Название компании</label>
                        <input
                           
                            id="name_Company"
                            aria-invalid={errors.name_Company ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9]+$/,
                                    message: "error message3"
                                },
                                maxLength:
                                {
                                    value: 20,
                                    message: 'error message2'
                                },
                            })}
                            name="name_Company"
                            type="text" />
                       <p role="alert"> {errors.name_Company && errors.name_Company.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors.name_Company && errors.name_Company.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                       <p role="alert"> {errors.name_Company && errors.name_Company.type === "maxLength" && "⚠️ "+"Максимальное количество символов 20"}</p>
                    </div>
                    <div>
                        <label htmlFor='identification_Number'>Идентификационный номер</label>
                        <input
                        
                            id="identification_Number"
                            aria-invalid={errors.identification_Number ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9]+$/,
                                    message: "error message1"
                                },
                                maxLength:
                                {
                                    value: 20,
                                    message: 'error message3'
                                },

                            })}
                            name="identification_Number"
                            type="text" />
                        <p role="alert"> {errors.identification_Number && errors.identification_Number.type === "pattern" && "⚠️ "+"Не должно содержать кириллицы"}</p>
                        <p role="alert"> {errors.identification_Number && errors.identification_Number.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                        <p role="alert"> {errors.identification_Number && errors.identification_Number.type === "maxLength" && "⚠️ "+"Максимальное количество символов 20"}</p>
                    </div>
                    <div>
                        <label htmlFor='supplier_Address'>Адресс компании</label>
                        <input
                           
                            id="supplier_Address"
                            aria-invalid={errors.supplier_Address ? "true" : "false"}
                            ref={register({
                                required: true,
                              
                                maxLength:
                                {
                                    value: 20,
                                    message: 'error message2'
                                },
                            })}
                            name="supplier_Address"
                            type="text" />
                      
                       <p role="alert"> {errors.supplier_Address && errors.supplier_Address.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                       <p role="alert"> {errors.supplier_Address && errors.supplier_Address.type === "maxLength" && "⚠️ "+"Максимальное количество символов 20"}</p>
                    </div>
                    <div>
                        <label htmlFor='fiO_Director'>ФИО директора</label>
                        <input
                            id="fiO_Director"
                            aria-invalid={errors. fiO_Director ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "]+$/,
                                    message: "error message3"
                                },
                                maxLength:
                                {
                                    value: 20,
                                    message: 'error message2'
                                },
                            })}
                            name="fiO_Director"
                            type="text" />
                       <p role="alert"> {errors. fiO_Director && errors. fiO_Director.type === "pattern" &&  "⚠️ "+"Не должно содержать кириллицы"}</p>
                       <p role="alert"> {errors. fiO_Director && errors. fiO_Director.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                       <p role="alert"> {errors. fiO_Director && errors. fiO_Director.type === "maxLength" && "⚠️ "+"Максимальное количество символов 20"}</p>
                    </div>
                    <div>
                        <label htmlFor='telefon'>Контактный номер</label>
                        <input
                            id="telefon"
                            placeholder="Tel format 000-000-000"
                            aria-invalid={errors.telefon ? "true" : "false"}
                            onChange={(event) => {
                                const { value } = event.target;
                                event.target.value = normalizeTel(value);
                            }}
                            ref={register({
                                required: true,
                                pattern: /[0-9]{3}-[0-9]{3}-[0-9]{3}/,
                                
                            })}
                            name="telefon"
                            type="text" />
                       <p role="alert">  {errors.telefon && errors.telefon.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>
                       <p role="alert"> {errors.telefon && errors.telefon.type === "pattern" && "⚠️ "+"Не соотвествует модели: 000 000 000"}</p>
                    </div>
                    <div>
                        <label htmlFor='comments'>Коментарий</label>
                        <input
                            id="comments"
                            aria-invalid={errors.comments ? "true" : "false"}
                            ref={register({
                                required: true,
                               
                            })}
                            name="comments"
                            type="text" />
                        
                        <p role="alert"> {errors.comments && errors.comments.type === "required" && "⚠️ "+"Поле не должно быть пустым"}</p>

                    </div>
                  
                    <div>
                        <label htmlFor='status'>Статус</label>
                        <select
                            ref={register()}
                            id="status"
                            name='status'>
                                <option className='option_creat' key={1} value={"Активен"}>Активен</option>
                                <option className='option_creat' key={2} value={"Не доступен"}>Не доступен</option>
                                <option className='option_creat' key={3} value={"Прекращено сотрудничество"}>Прекращено сотрудничество</option>
                            
                        </select>

                    </div>
                    <div>
                        <button type="submit"> Submit </button>
                    </div>
                </form>

            </div>
        </div>
    )
}
export default AddProvider