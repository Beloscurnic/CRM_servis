import React, { FC, ReactElement, useRef, useEffect, useState,useMemo } from 'react';
import {  List_EquipmentVm,List_Equipment,ListClient,DeleteClient,Delet_EquipmentDto,List_Services} from '../../api/api3';
import {  Client, Order_Client_DetailsVm, PersonnalVm } from '../../api/api';
import { NavLink,useParams } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import "./styles/button.css"
import Table_list from './table_services';


const apiClient = new Client('https://localhost:44325');
const apiClient2 = new ListClient('https://localhost:44325');
const apiClient3 = new DeleteClient('https://localhost:44325');

type personal= {
    name: string;
    last_Name: string;
    telefon: string;
};

const Order_Detail: FC<{}> = (): ReactElement => {

    const params = useParams();
    const prodId = params.id;

    const [ordersdetail, setOrders] = useState<Order_Client_DetailsVm>();

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
    
       const [personnal, setPersonnal] = useState<PersonnalVm>();
       const [personnal2, setPersonnal2] = useState<PersonnalVm>();
       
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

    const [equimpent, setEquimpent] = useState<List_Equipment[]>([]);

    async function Equimpent() {
        const orderListVm = await apiClient2.equipment(parseInt(prodId!),'3.0')
        setEquimpent(orderListVm.list_Equipments);
    }




    useEffect(() => {
        const interval = setInterval(() => {
            getOrder(false)
          }, 1000);
          return () => clearInterval(interval);
    }, []);
  
    useEffect(() => {    
        getPersonnal()
    }, []);
    useEffect(() => {    
        Equimpent()
    }, []);

    async function handleClick(id_order: string, iD_accessories: string){

        const equipment: Delet_EquipmentDto = {
            iD_Order: parseInt(id_order),
            iD_Accessories: parseInt(iD_accessories)
        }
        await apiClient3.delet_equipment("3.0",equipment);
        Equimpent();
        getPersonnal()
    }

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
                    <table>
                        <td>
                    <div>
                        <NavLink to={`/accessories/${cell.row.values.iD_Accessories}`}>Детали</NavLink>
                    </div>
                    </td>
                    <td>
                    <div>
                    <button className="button-login3" onClick={async()=> {await handleClick(cell.row.values.iD_Order!,cell.row.values.iD_Accessories!)}}>Убрать</button>
                    </div> 
                    </td> 
                    </table>
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


    return(
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

        <div>
        <div className='table_div'>
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
        <table className='divtable2'>
              <td>
        <div className='creat_orders2'>
         <NavLink type="a" className="button-login2" to={`/creat/${ordersdetail?.iD_Order}`}>Добавить комплектующие</NavLink>   
        </div>
             </td>
             <td>
             <div className='creat_orders2'>
         <NavLink type="a" className="button-login2" to={`/creat/${ordersdetail?.iD_Order}`}>Добавить радиодетали</NavLink>   
        </div>
             </td>
        </table>
        </div>
       <Table_list Id_Order={ordersdetail?.iD_Order} />
       <div className='creat_orders2'>
         <NavLink type="a" className="button-login2" to={`/creat_services/${ordersdetail?.iD_Order}`}>Добавить услугу</NavLink>   
        </div>
    </div>
    )
}
export default Order_Detail