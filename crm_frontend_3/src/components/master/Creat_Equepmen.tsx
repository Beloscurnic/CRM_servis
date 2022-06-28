import React, { FC, ReactElement, useRef, useEffect, useState,useMemo, } from 'react';
import {  List_EquipmentVm,List_Equipment,ListClient,Creat_Equipment ,Creat_EquimpentDto,} from '../../api/api3';
import {AccessoriesClient,Accessories_CPUVm,TypeClient,Type_AccessoriesVm,Get_AccessoriesVm,Update_AccessoriesDto,UpdateClient,CreateClient,Creat_DeliveryDto ,List_Accessories } from '../../api/api2';
import userManager, { loadUser} from '../../auth/user-service';
import { Update_Order_ClientDto,Create_Order_ClientDto, Client, List_Order_Client } from '../../api/api';
import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import { NavLink,useParams ,useNavigate} from 'react-router-dom';

const apiClient2 = new AccessoriesClient('https://localhost:44325');
const apiClient3 = new Creat_Equipment('https://localhost:44325');
const apiClient = new TypeClient('https://localhost:44325');
const apiClient4 = new Client('https://localhost:44325');
const Creat_Equepmen: FC<{}> = (): ReactElement => {
    const navigate = useNavigate();
     const params2 = useParams();
     const id_order = params2.id_order;

    const [accessoroess, setAccessoroes] = useState<List_Accessories[]>([]);

    async function getAccessoroes() {
        const listAccessoroes = await apiClient2.all_accessories('2.0');
        setAccessoroes(listAccessoroes.list_Accessoriess);
    }
    useEffect(() => {
        setTimeout(getAccessoroes, 10);
    }, []);

    async function handleClick(iD_Accessories: string,name_Company: string){
        const delivery: Creat_EquimpentDto = {
            iD_Order: parseInt(id_order!),
            iD_Accessories: parseInt(iD_Accessories!),
            name_Company: name_Company
         };
        await apiClient3.creat_equipment('3.0',delivery);
       
        
        const status: Update_Order_ClientDto = {
            iD_Order :parseInt(id_order!),
            status_Order:"Ремонт"
         };
        await apiClient4.update_status1( '1.0',status);
        alert("Добавлен");
        getAccessoroes();
    }
       
    const ColumnFilter = ({ column }: { column: any }) => {
        const { filterValue, setFilter } = column
        return (
            <span className='form__group'>
                Поиск:{' '}
                <input className='form__input' value={filterValue || ''} onChange={(e) => setFilter(e.target.value)}></input>
            </span>

        )
    }

    const ColumnFilter2 = ({ column }: { column: any }) => {
        const { filterValue, setFilter } = column
        return (

            <span className='form__group'>
                Поиск:{' '}
                <select className='form__input' value={filterValue || ''} onChange={(e) => setFilter(e.target.value)}>
                    <option className='option_text' value=''>All</option>
                    <option className='option_text' value="Активный">Активный</option>
                    <option className='option_text' value="Не поставляют">Не поставляют</option>
                </select>
            </span>

        )
    }

    const Columns: Column<List_Accessories>[] = [
        {
            Header: 'ID',
            accessor: 'iD_Accessories',
            Filter: ColumnFilter,
            disableSortBy: true,
        },
        {
            Header: 'Тип',
            accessor: 'type_Сomponent',
            disableSortBy: true,
            Filter: ColumnFilter
        },
        {
            Header: 'Название',
            accessor: 'name_Сomponent',
            disableSortBy: true,
            Filter: ColumnFilter
        },
        {
            Header: 'В наличие',
            accessor: 'quantity_Сomponent',
            disableSortBy: true,
            disableFilters: true,
            Filter: ColumnFilter
        },
        {
            Header: 'Цена за штуку',
            accessor: 'price_Сomponent',   
            disableFilters: true,
            Filter: ColumnFilter,
            disableSortBy: true,
        },
        {
            Header: 'Поставщик',
            accessor: 'name_Company',   
           
            Filter: ColumnFilter,
            disableSortBy: true,
        },
        {
            Header: 'Статус',
            accessor: 'сharacteristics_info',
            Filter: ColumnFilter2,
            disableSortBy: true,
            Cell: ({ cell }) => (
                <div>
                      {cell.row.values.сharacteristics_info}{"  "}
                      <div className='divnavlink'>
                        <NavLink className='divnavlink' to={`/accessories/${cell.row.values.iD_Accessories}`}>Детали</NavLink>
                      </div>      
                      <div>
                         <button  className="button-login3" onClick={async()=> {await handleClick(cell.row.values.iD_Accessories!, cell.row.values.name_Company!)}}>Добавить</button>
                    </div> 
                </div>
            )
        },
    ]
    const columns = useMemo(() => Columns, []);
    //  const data = useMemo(()=>orderslist, [] )

    const tableInstance = useTable({
        columns,
        data: accessoroess
    },
    useFilters,
    useSortBy,
    usePagination
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

    const { pageIndex, pageSize } = state;
return(
    <div>
    <table className='header_table'>
            <tr>
                <td>
                    <div className='div_orders'>
                    <h1> Список комплектующих</h1>
                    </div>
                </td>
            
            </tr>
        </table>
<div className='table_div'>
            <table className='table' {...getTableProps()}>

                <thead>
                    {
                        headerGroups.map(headerGroups => (
                            <tr {...headerGroups.getHeaderGroupProps()}>
                                {headerGroups.headers.map((column) => (
                                    <th  {...column.getHeaderProps(column.getSortByToggleProps())}>{column.render('Header')}
                                        <span>
                                            {column.isSorted
                                                ? column.isSortedDesc
                                                    ? ' 🔽'
                                                    : ' 🔼'
                                                : ''}
                                        </span>
                                        {/* {column.render('Header')} */}
                                        <div className='span_div'>{column.canFilter ? column.render('Filter') : null}</div>


                                    </th>
                                ))}

                            </tr>
                        ))
                    }
                </thead>
                <tbody {...getTableBodyProps()}>
                    {page.map((row) => {
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
                
                    <div className='div_pagination2'>
                        <span>
                            Страница{' '}
                            <strong>
                                {pageIndex + 1} of {pageOptions.length}
                            </strong>{' '}
                        </span>
                        <select className='form__input' value={pageSize} onChange={(e) => setPageSize(Number(e.target.value))}>
                            {[10, 25, 50].map((pageSize) => (
                                <option key={pageSize} value={pageSize}>
                                    Show {pageSize}
                                </option>
                            ))}
                        </select>
                        <button className='button button5' onClick={() => previousPage()} disabled={!canPreviousPage}>Предыдущая</button>
                        <button className='button button5' onClick={() => nextPage()} disabled={!canNextPage}>Следующая</button>
                    </div>
          
            </table> 
        </div>    
</div>
)
}
export default Creat_Equepmen;