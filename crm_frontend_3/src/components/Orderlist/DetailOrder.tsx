import React, { FC, ReactElement, useRef, useEffect, useState,useMemo } from 'react';
import { Update_Status_orderDto, Client, Order_Client_DetailsVm, PersonnalVm } from '../../api/api';
import { NavLink,useParams } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import OrderList from './Orderlist';
import Get_Personnal from './Get_Personnal';
import './squere.css'
import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import './detail_order.css';
import {  List_EquipmentVm,List_Equipment,ListClient,DeleteClient,Delet_EquipmentDto,List_Services} from '../../api/api3';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import Table_list from '../master/table_services';


const apiClient = new Client('https://localhost:44325');
const apiClient2 = new ListClient('https://localhost:44325');

type detail= {
            iD_Order: number,
            name_Client: string,
            lastName_Client: string,
            telefon: string,
            type_technology: string,
            model_technology: string,
            breaking_info: string,
            quipment_info:string,
            receipt_date: Date,
        };
type personal= {
            name: string;
            last_Name: string;
            telefon: string;
        };

const DetailOrder: FC<{}> = (): ReactElement => {
   loadUser()
   const [ordersdetail2, setOrders2] = useState<Order_Client_DetailsVm>();
   const [ordersdetail, setOrders] = useState<Order_Client_DetailsVm>();
   const [personnal, setPersonnal] = useState<PersonnalVm>();
   const [personnal2, setPersonnal2] = useState<PersonnalVm>();
  // const [personnal3, setPersonnal3] = useState<PersonnalVm>();
//   const  { prodId }  = useParams();
        const params = useParams();
        const prodId = params.id;
       
      
    async function getOrder(bool:boolean) {
     return new Promise<string>( async(resolve) => {
            let id;
            
        const orderDetailtVm = await apiClient.get(parseInt(prodId!), '1.0')
        setOrders(orderDetailtVm);
        if(bool===false)
        {
        id=orderDetailtVm.iD_Personnel_dispatcher;
        resolve(id);
        }else {
        id=orderDetailtVm.iD_Personnel_master;
        resolve(id);
        }
    })};

    async function getOrder2() {
        return new Promise<detail>( async(resolve) => {
               let id;
               
           const orderDetailtVm = await apiClient.get(parseInt(prodId!), '1.0')
           setOrders2(orderDetailtVm);
        
           resolve({
               iD_Order: orderDetailtVm.iD_Order,
               name_Client:orderDetailtVm.name_Client,
               lastName_Client:orderDetailtVm.lastName_Client,
               telefon: orderDetailtVm.telefon,
               type_technology:orderDetailtVm.type_technology ,
               model_technology: orderDetailtVm.model_technology,
               quipment_info:orderDetailtVm.quipment_info,
               breaking_info:orderDetailtVm.breaking_info,
               receipt_date:orderDetailtVm.receipt_date,
           });
          
       })};

      async function a1 (){
        var doc = new jsPDF();
      //  var col = ["iD_Personnel_dispatcher"];
        
        type detail= {
            iD_Order: number,
            name_Client: string,
            lastName_Client: string,
            telefon: string,
            type_technology: string,
            model_technology: string,
            breaking_info: string,
            quipment_info:string,
            receipt_date: Date,
        }
        type personal= {
            name: string;
            last_Name: string;
            telefon: string;
        };
      
      
        const detail2: detail= await getOrder2() as unknown as detail;
        const personnal: personal= await getPersonnal() as unknown as personal;
        
        let arr = detail2.breaking_info.split(' ');
        let text="";
        let a=60;
        let b=54;
        
        doc.setFont('PTSans');
        doc.setFontSize(14);
        
        doc.text("Chitanta pentru reparatie de la - " + detail2.receipt_date.toString().split('T')[0], 14, 15);
        doc.text("__________________________________________________________________________", 14, 20);
        doc.setFontSize(18);
        doc.text("ID Ordin - " + detail2.iD_Order,14,28);
        doc.setFontSize(14);
        doc.text("Client - " + detail2.lastName_Client + "."+ detail2.name_Client,14,36);
        doc.text("Telefon client - " + detail2.telefon,14,42);
        doc.text("Produs - " + detail2.type_technology,14,48);
        doc.text("Numarul de serie - " + detail2.model_technology,14,54);
        if(detail2.quipment_info!==undefined)
        {
        doc.text("Echipamente - " + detail2.quipment_info,14,b+6);
        b=b+6;
        } 
        // doc.text("Defectiune - ",14,b+6);
    
        // for(let i=0; i<arr.length; i++ )
        // {
        //     text=text +" "+ arr[i];
        //     if(arr.length>15)
        //     {
        //         if(i==Math.round(arr.length/2))
        //         {
        //             doc.text(text,39,b+6);
        //             b=b+6;
        //             text="";
        //         }
        //         if(i==arr.length)
        //         {
        //             doc.text(text,16,b+6);
        //             b=b+6+6;
        //             text="";
        //         }
        //     }
        //     else  if( arr.length<15 && i==arr.length-1) {
        //         doc.text(text,39,b+6);
        //         b=b+6;
        //         text="";
        //     }
        // }
       
        doc.text("__________________________________________________________________________", 14, b+6+2);
        b=b+9;
        doc.setFontSize(12);
        doc.text("Conditii de reparatie ",14,b+6);
        b=b+6;
        doc.text("1. Examinarea se efectueaza in 3 zile lucratoare. Reparatia in cinci zile lucratoare zile lucratoare",14,b+6);
        b=b+6;
        doc.text("2. In lipsa pieselor, reparatia se prelungeste pe o perioada pina primirea acestora",14,b+6);
        b=b+6;
        doc.text("3. Atelierul elimina doar defectiunile declarate de client",14,b+6);
        b=b+6;
        doc.text("4. Pentru defectiuni ascunse sau nedeclarate, precum si pentru pierderea datelor stocate in",14,b+6);
        b=b+6;
        doc.text(" telefon si lasate de cartelele SIM si FLASH, atelierul nu este responsabil",14,b+6);
        b=b+6;
        doc.text("5. In caz de neprezentare a cadavrelor in termen de 30 de zile, telefonul este considerat",14,b+6);
        b=b+6;
        doc.text("fara proprietar si aruncat la discretia comandantului.",14,b+6);
        b=b+12;

        doc.text("Sunt familiarizat cu termenii si conditiile de reparatie si depozitare",14,b+6);
        b=b+12;
        doc.text("Executor - ",14,b+6);
        doc.text(personnal.last_Name+"."+personnal.name,32,b+6);
        b=b+6;
        doc.setFontSize(14);
        doc.text("Telefon mastera - "+ personnal.telefon,14,b+6);

        b=b+16;
        doc.text("____________________",24,b+6);
        doc.setFontSize(10);
        doc.text("Semnatura dispecerului",33,b+4+6);
        doc.setFontSize(14);
        doc.text("____________________",140,b+6);
        doc.setFontSize(10);
        doc.text("Semnatura clientului",150,b+6+4);

        // autoTable(doc, {
        //     head: [col],
        //     body: [[detail2.iD_Personnel_dispatcher]]
        // })
        

        doc.save('table.pdf')
      //  console.log(detail2.iD_Personnel_dispatcher)
        }

    //   a(ordersdetail)

    async function a2 (id_order: number | undefined){
        const delivery: Update_Status_orderDto = {
            iD_Order :id_order!,
         };
        await apiClient.update_status('1.0',delivery);
        getOrder(false);
        var doc = new jsPDF();
      //  var col = ["iD_Personnel_dispatcher"];
        
        type detail= {
            iD_Order: number,
            name_Client: string,
            lastName_Client: string,
            telefon: string,
            type_technology: string,
            model_technology: string,
            breaking_info: string,
            quipment_info:string,
            receipt_date: Date,
        }
        type personal= {
            name: string;
            last_Name: string;
            telefon: string;
        };
    
        doc.save('table.pdf')
      //  console.log(detail2.iD_Personnel_dispatcher)
        }

    async function getPersonnal() {
        return new Promise<personal>( async(resolve) => {
        // console.log(prodId);
         const id = await getOrder(false);  
         const id2= await getOrder(true);
      //   console.log(id);
         const personalVm = await apiClient.personnal(id, '1.0')
         setPersonnal(personalVm);
         const personalVm2 = await apiClient.personnal(id2, '1.0')
         setPersonnal2(personalVm2);
         resolve({
            name: personalVm2.name,
            last_Name:personalVm2.last_Name,
            telefon:personalVm2.telefon, 
        });
    })};
    //  async function getPersonnal3() {
    //     return new Promise<personal>( async(resolve) => {
    //     // console.log(prodId);
        
    //      const id2= await getOrder(true);
    //   //   console.log(id);

    //      const personalVm2 = await apiClient.personnal(id2, '1.0')
    //      setPersonnal3(personalVm2);
    //      resolve({
    //         name: personalVm2.name,
    //         last_Name:personalVm2.last_Name,
    //         telefon:personalVm2.telefon,
           
    //     });
       
    // })};

    useEffect(() => {
        setTimeout(getOrder, 500)
    }, []);
    useEffect(() => {    
        getPersonnal()
    }, []);
   
    // useEffect(() => {    
    //     a1()
    // }, []);
    useEffect(() => {    
        getOrder2()
    }, []);
   
    const [equimpent, setEquimpent] = useState<List_Equipment[]>([]);

    async function Equimpent() {
        const orderListVm = await apiClient2.equipment(parseInt(prodId!),'3.0')
        setEquimpent(orderListVm.list_Equipments);
    }


    useEffect(() => {    
        Equimpent()
    }, []);

    const Columns: Column<List_Equipment>[] = [
        {
            Header: 'ID записи',
            accessor: 'iD_Order',       
        },
        {
            Header: 'Номер детали',
            accessor: 'iD_Accessories',
          
        },
        {
            Header: 'Название компонента',
            accessor: 'name_Сomponent',
        },
        {
            Header: 'Тип компонента',
            accessor: 'type_Сomponent',
        },
        {
            Header: 'Цена',
            accessor: 'price_Сomponent',
        },
        {
            Header: 'Поставщик',
            accessor: 'name_Company',
            Cell: ({ cell }) => (
                <div>
                    {cell.row.values.name_Company}{"  "}
                    <div>
                        <NavLink to={`/accessories/${cell.row.values.iD_Accessories}`}>Детали</NavLink>
                    </div>
                </div>
            )
        },

    ]

    const columns = useMemo(() => Columns, []);
    //  const data = useMemo(()=>orderslist, [] )

    const tableInstance = useTable({
        columns,
        data: equimpent
    }
    );
    const {
        getTableProps,
        getTableBodyProps,
        headerGroups,
        page,
        nextPage,
        previousPage,
        canNextPage,
        canPreviousPage,
        pageOptions,
        setPageSize,
        state,
        prepareRows,
        rows,
        prepareRow,
    } = tableInstance
 
    
    return (
        <div> 
            
            <div className='div_header'>
               <h1> ID заказа: { ordersdetail?.iD_Order}</h1>
            </div>
            <div className='div_order'>
            <table  className='table'>
                <tr>
                    <td> Имя клиента</td>
                    <td> { ordersdetail?.name_Client}</td>
                </tr>
                <tr>
                    <td> Фамилия клиента</td>
                    <td> {ordersdetail?.lastName_Client}</td>
                </tr>
                <tr>
                    <td> Email клиента</td>
                    <td> {ordersdetail?.email_Client}</td>
                </tr>
                <tr>
                    <td> Телефон клиента</td>
                    <td> {ordersdetail?.telefon}</td>
                </tr>
                <tr>
                    <td> Имя диспетчер</td>
                    <td> {personnal?.name}</td>
                </tr>
                <tr>
                    <td> Фамилия диспетчер</td>
                    <td> {personnal?.last_Name}</td>
                </tr>
                <tr>
                    <td> Телефон диспетчер</td>
                    <td> {personnal?.telefon}</td>
                </tr>
                <tr>
                    <td> Имя мастера</td>
                    <td> {personnal2?.name}</td>
                </tr>
                <tr>
                    <td> Фамилия мастера</td>
                    <td> {personnal2?.last_Name}</td>
                </tr>
                <tr>
                    <td> Телефон мастера</td>
                    <td> {personnal2?.telefon}</td>
                </tr>
                <tr>
                    <td> Тип техники</td>
                    <td> {ordersdetail?.type_technology}</td>
                </tr>
                <tr>
                    <td> Модель техники</td>
                    <td> {ordersdetail?.model_technology}</td>
                </tr>
                <tr>
                    <td> Информация о поломки</td>
                    <td> {ordersdetail?.breaking_info}</td>
                </tr>
                <tr>
                    <td> Статус заказа</td>
                    <td>  {ordersdetail?.status_Order}</td>
                </tr>
                <tr>
                    <td> Дата принятия</td>
                    <td> {ordersdetail?.receipt_date.toString().split('T')[0]}</td>
                </tr>
                <tr>
                    <td> Дата выдачи</td>
                    <td> {ordersdetail?.issue_date?.toString().split('T')[0]}</td>
                </tr>
                <tr>
                    <td> Цена ремонта</td>
                    <td> {ordersdetail?.price}</td>
                </tr>
            </table>
            </div>
            <div className='table_div'>
                <h1> Список установленых комплектующих</h1>
                    <table className='table' {...getTableProps()}>

                        <thead>
                            {
                                headerGroups.map(headerGroups => (
                                    <tr {...headerGroups.getHeaderGroupProps()}>
                                        {headerGroups.headers.map((column) => (
                                            <th  {...column.getHeaderProps()}>{column.render('Header')}
                                            </th>
                                        ))}

                                    </tr>
                                ))
                            }
                        </thead>
                        <tbody {...getTableBodyProps()}>
                            {rows.map((row) => {
                                prepareRow(row)
                                return (
                                    <tr {...row.getRowProps()}>
                                        {row.cells.map((cell) => {
                                            return <td {...cell.getCellProps()}> {cell.render('Cell')}</td>
                                        })}
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>

        </div>

        <Table_list Id_Order={ordersdetail?.iD_Order} />
            <div className='div_button '>
            <button className="button-login" onClick={a1} >Подтверждение заказа</button> 
            <button className="button-login" onClick={async()=> {await a2(ordersdetail?.iD_Order)} }>Сертификат выдачи</button> 
            </div>
        </div>
    );
};
export default DetailOrder;