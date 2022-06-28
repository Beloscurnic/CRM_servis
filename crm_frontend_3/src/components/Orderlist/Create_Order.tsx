import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { Create_Order_ClientDto, Client, List_Order_Client, PersonnalVm, List_Personnal } from '../../api/api';
import { appendErrors, useForm } from 'react-hook-form'
import './creat_order.css'
import { useNavigate } from 'react-router-dom';
const apiClient = new Client('https://localhost:44325');

interface FormData {
    name_Client: string;
    lastName_Client: string;
    email_Client: string;
    telefon: string;
    type_technology: string;
    model_technology: string;
    breaking_info: string;
    iD_Personnel_master: string;
}

async function createOrder(order: Create_Order_ClientDto) {
    await apiClient.create('1.0', order);
    console.log('Order_Client is created.');
    window.location.reload();
}

const Create_Order: FC<{}> = (): ReactElement => {
    const navigate = useNavigate();
    const [name, setName] = useState('Create');
    const [personalls, setPersonalls] = useState<List_Personnal[]>([]);

    async function getPersonalls() {
        const personalListVm = await apiClient.personnalAll('1.0')

        setPersonalls(personalListVm.list_Personnals);
        
    }

    useEffect(() => {
        setTimeout(getPersonalls, 100);
    }, []);

    const { register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });

    const onSubmit = handleSubmit(({ name_Client, lastName_Client, email_Client, telefon, type_technology,
        model_technology, breaking_info, iD_Personnel_master }: any) => {

        const order: Create_Order_ClientDto = {
            name_Client: name_Client,
            lastName_Client: lastName_Client,
            email_Client: email_Client,
            telefon: telefon,
            type_technology: type_technology,
            model_technology: model_technology,
            breaking_info: breaking_info,
            iD_Personnel_master: iD_Personnel_master
        };
        createOrder(order);
        navigate(`/`);    
     //   window.location.reload();
        alert("Заказ создан.")
        
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
    return (
        <div>
            <div>
                <form className="App" action='' onSubmit={onSubmit} >
                <h1 className='h1_creat'>Добавить новую запись</h1>
                    <div>
                        <label htmlFor='name_Client'>Имя клиента</label>
                        <input
                           
                            id="name_Client"
                            aria-invalid={errors.name_Client ? "true" : "false"}
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
                            name="name_Client"
                            type="text" />
                       <p role="alert"> {errors.name_Client && errors.name_Client.type === "pattern" &&  "⚠️ "+"Не должен содержать кирилицу"}</p>
                       <p role="alert"> {errors.name_Client && errors.name_Client.type === "required" && "⚠️ "+"Пустое поле"}</p>
                       <p role="alert"> {errors.name_Client && errors.name_Client.type === "maxLength" && "⚠️ "+"Максимальное количество символов 20"}</p>
                    </div>
                    <div>
                        <label htmlFor='lastName_Client'>Фамилия клиента</label>
                        <input
                        
                            id="lastName_Client"
                            aria-invalid={errors.lastName_Client ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "]+$/,
                                    message: "error message1"
                                },
                                maxLength:
                                {
                                    value: 20,
                                    message: 'error message3'
                                },
                            })}
                            name="lastName_Client"
                            type="text" />
                        <p role="alert"> {errors.lastName_Client && errors.lastName_Client.type === "pattern" && "⚠️ "+"Не должен содержать кирилицу"}</p>
                        <p role="alert"> {errors.lastName_Client && errors.lastName_Client.type === "required" && "⚠️ "+"Пустое поле"}</p>
                        <p role="alert"> {errors.lastName_Client && errors.lastName_Client.type === "maxLength" && "⚠️ "+"Максимальное количество символов 20"}</p>
                    </div>
                    <div>
                        <label htmlFor='email_Client'>Email клиента</label>
                        <input
                            id="email_Client"
                            placeholder="Email format alex@mail.ru"
                            aria-invalid={errors.email_Client ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                                    message: "error message1"
                                },
                                maxLength:
                                {
                                    value: 30,
                                    message: 'error message2'
                                },
                            })}
                            name="email_Client"
                            type="text" />
                        <p role="alert"> {errors.email_Client && errors.email_Client.type === "pattern" && "⚠️ "+"Не соотвествует модели: alex@mail.ru"}</p>
                        <p role="alert"> {errors.email_Client && errors.email_Client.type === "required" && "⚠️ "+"Пустое поле"}</p>
                        <p role="alert"> {errors.email_Client && errors.email_Client.type === "maxLength" && "⚠️ "+"Максимальное количество символов 30"}</p>
                    </div>
                    <div>
                        <label htmlFor='telefon'>Telefon клиента</label>
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
                       <p role="alert">  {errors.telefon && errors.telefon.type === "required" && "⚠️ "+"Пустое поле"}</p>
                       <p role="alert"> {errors.telefon && errors.telefon.type === "pattern" && "⚠️ "+"Не соотвествует формату: 000-000-000"}</p>
                       <p role="alert"> {errors.telefon && errors.telefon.type === " maxLength" && "⚠️ "+"Максимальное количество символов 9"}</p>
                    </div>
                    <div>
                        <label htmlFor='type_technology'>Полное Название устройства</label>
                        <input
                            id="type_technology"
                            aria-invalid={errors.type_technology ? "true" : "false"}
                            ref={register({
                                required: true,
                                pattern: {
                                    value: /^[a-zA-Z0-9+" "]+$/,
                                    message: "error message1"
                                }
                            })}
                            name="type_technology"
                            type="text" />
                        <p role="alert"> {errors.type_technology && errors.type_technology.type === "pattern" && "⚠️ "+"Не должен содержать кирилицу"}</p>
                        <p role="alert"> {errors.type_technology && errors.type_technology.type === "required" && "⚠️ "+"Пустое поле"}</p>

                    </div>
                    <div>
                        <label htmlFor='model_technology'>Серийный номер устройства</label>
                        <input
                            id="model_technology"
                            aria-invalid={errors.model_technology ? "true" : "false"}
                            ref={register({
                                required: true,

                            })}
                            name="model_technology"
                            type="text" />
                        <p role="alert"> {errors.model_technology && errors.model_technology.type === "required" && "⚠️ "+"Пустое поле"}</p>
                    </div>
                    <div>
                        <label htmlFor='breaking_info'>Данные о поломке</label>
                        <textarea

                            id="breaking_info"
                            aria-invalid={errors.breaking_info ? "true" : "false"}
                            ref={register({
                                required: true,
                            })}
                            name="breaking_info"
                        />
                       <p role="alert">  {errors.breaking_info && errors.breaking_info.type === "required" && "⚠️ "+"Пустое поле"}</p>
                    </div>
                    <div>
                        <label htmlFor='iD_Personnel_master'>Выбрать мастера</label>
                        <select
                            ref={register()}
                            id="iD_Personnel_master"
                            name='iD_Personnel_master'>

                            {personalls?.filter(person => person.position =="serviceman").map((personnal) => (
                                <option className='option_creat' key={personnal.iD_Personnal} value={personnal.iD_Personnal}>{personnal.last_Name}.{personnal.name}</option>
                            )
                            )}
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
export default Create_Order