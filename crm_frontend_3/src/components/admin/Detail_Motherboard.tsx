import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import {AccessoriesClient,MotherboardVm,TypeClient,Type_AccessoriesVm,Get_AccessoriesVm,Update_AccessoriesDto,UpdateClient,CreateClient,Creat_DeliveryDto } from '../../api/api2';
import { NavLink,useParams ,useNavigate} from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import '../Orderlist/squere.css'

import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import '../Orderlist/detail_order.css';
import { appendErrors, useForm,Controller } from 'react-hook-form'
import { isTypeAssertionExpression } from 'typescript';
import { type } from '@testing-library/user-event/dist/type';

type Tprops = {
    iD_Accessories: string | undefined;
};


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
   // window.location.reload();
}

const Detail_Motherboard: FC<{iD_Accessories:string}> = ( children,
    iD_Accessories:string): ReactElement => {
   const navigate = useNavigate();

   const [id_component, setProvider] = useState<Type_AccessoriesVm>();


   async function get_type_Accessoroes() {
      return new Promise<string>( async(resolve) => {
    let type;
      const infotype = await apiClient2.type_accessories(parseInt(iD_Accessories!),'2.0');
      setProvider(infotype);
      type=infotype.type_Сomponent;
      resolve(type);
      })};

   const [motherboard, setmotherboard] = useState<MotherboardVm>();

   async function getAccessoroes() {
       const infomotherboard = await apiClient.Accessories_motherboard(parseInt(iD_Accessories!),'2.0');
       setmotherboard(infomotherboard);
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
          iD_Сomponent: motherboard!.iD_Сomponent,
          name_Сomponent:motherboard!.name_Сomponent,
          type_Сomponent: id_component!.type_Сomponent,
          price_Сomponent: motherboard!.price,
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


      return(
          <div>
              <div className='div_header'>
                  <h1> ID компонента: { iD_Accessories}</h1>
               </div>
          <div className='div_order'>
          <table  className='table'>
              <tr>
                  <td> Уникальный номер</td>
                  <td> {motherboard?.iD_Сomponent}</td>
              </tr>
              <tr>
                  <td> Полное название</td>
                  <td> {motherboard?.name_Сomponent}</td>
              </tr>
              <tr>
                  <td> Сокет материнской платы </td>
                  <td> {motherboard?.motherboard_socket}</td>
              </tr>
              <tr>
                  <td> Чипсет материнской платы</td>
                  <td> {motherboard?.motherboard_chipset}</td>
              </tr>
              <tr>
                  <td> Оперативная память</td>
                  <td> {motherboard?.ram}</td>
              </tr>
              <tr>
                  <td> Дисковые контроллеры </td>
                  <td> {motherboard?.disk_controllers}</td>
              </tr>
              <tr>
                  <td> Слоты расширения </td>
                  <td> {motherboard?.expansion_slots}</td>
              </tr>
              <tr>
                  <td> Сеть </td>
                  <td> {motherboard?.net}</td>
              </tr>
              <tr>
                  <td>Встроенные аудио и видео</td>
                  <td> {motherboard?.audio_and_video}</td>
              </tr>
              <tr>
                  <td> Форм фактор </td>
                  <td> {motherboard?.form_factor}</td>
              </tr>
              <tr>
                  <td> Цена</td>
                  <td> {motherboard?.price}</td>
              </tr>
          </table>
          </div>
          <div className='div_header'>
              <h1>Поставляется компанией: {component?.name_Company}  </h1>
              <h1>Текущий статус: {component?.сharacteristics_info} <button className="button-login2" onClick={async()=> {await handleClick(iD_Accessories!, component?.сharacteristics_info!)}}>Поменять статус!</button>    </h1>      
          </div>
          <div>
          <form className="App" action='' onSubmit={onSubmit} >
              <h1 className='h1_creat'>Добавить новую материскую плату  </h1>
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
export default Detail_Motherboard