import React, { FC, ReactElement, useRef, useEffect, useState,useMemo } from 'react';
import {  List_EquipmentVm,List_Equipment,ListClient,DeleteClient,Delet_EquipmentDto,List_Services,Delet_ServicesDto} from '../../api/api3';
import {  Client, Order_Client_DetailsVm, PersonnalVm,Update_Order_ClientDto } from '../../api/api';
import { NavLink,useParams } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import "./styles/button.css"

type Tprops = {
    Id_Order: number | undefined;
};

const apiClient = new Client('https://localhost:44325');
const apiClient2 = new ListClient('https://localhost:44325');
const apiClient3 = new DeleteClient('https://localhost:44325');
const apiClient4 = new Client('https://localhost:44325');

const Table_list: FC<Tprops> = (childer, Id_Order:string): ReactElement => {
 console.log(Id_Order);
    const [service, setServices] = useState<List_Services[]>([]);

    async function Service() {
        const serviceListVm = await apiClient2.get_list_services("3.0")
        setServices(serviceListVm.list_Servicess);
    }

    useEffect(() => {
        const interval = setInterval(() => {
            Service()
          }, 1000);
          return () => clearInterval(interval);
    }, []);


    async function handleClick(id_service: string){

        const equipment:Delet_ServicesDto = {
            iD_Services: parseInt(id_service),
        }
        await apiClient3.delet_services("3.0",equipment);
       // window.location.reload();
       Service()

       const status: Update_Order_ClientDto = {
        iD_Order :parseInt(Id_Order!),
        status_Order:"Ремонт"
     };
     alert("Добавлен");
    await apiClient4.update_status1('1.0',status);
    }

    const Columns: Column<List_Services>[] = [
        {
            Header: 'ID записи',
            accessor: 'iD_Services',       
        },
        {
            Header: 'Тип услуги',
            accessor: 'name',
          
        },
        {
            Header: 'Описание работ',
            accessor: 'description',
        },
        {
            Header: 'Цена услуги',
            accessor: 'price_services',
            Cell: ({ cell }) => (
                <div>
                    {cell.row.values.price_services}{"  "}
                    <div>
                    <button  className="button-login3"  onClick={async()=> {await handleClick(cell.row.values.iD_Services!)}}>Убрать</button>
                    </div>  
                </div>
            )
        }
    ]

    const columns = useMemo(() => Columns, []);
    //  const data = useMemo(()=>orderslist, [] )

    const tableInstance = useTable({
        columns,
        data: service
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
 <div className='table_div'>
     <h1>Список оказаных услуг</h1>
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
    
        </div>
    )
}
export default Table_list