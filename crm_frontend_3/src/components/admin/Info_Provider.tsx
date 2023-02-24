import React, { FC, ReactElement, useRef, useEffect, ChangeEvent, ChangeEventHandler, useState,useMemo } from 'react';
import {  List_Accessories2,AccessoriesClient,DeleteClient,UpdateClient,Update_ProviderDto} from '../../api/api2';
import { NavLink,useParams } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import { Value } from 'sass';
import { Console } from 'console';
import './styles.css'
import "./styles/input.css"

import { appendErrors, useForm } from 'react-hook-form'

const apiClient3 = new UpdateClient('https://localhost:44325');
const apiClient2 = new DeleteClient('https://localhost:44325');
const apiClient = new AccessoriesClient('https://localhost:44325');


interface FormData {
    name_Company: string;
    status: string;
}

async function update_provider(provider: Update_ProviderDto) {
    await apiClient3.update_provider('2.0', provider);
 
}


const Info_Provider: FC<{}> = (): ReactElement => {
    
    const params = useParams();
    const name_Company = params.name_Company;

    const [accessoroess2, setAccessoroes] = useState<List_Accessories2[]>([]);
  
    async function getAccessoroes() {
        const listAccessoroes = await apiClient.company2(name_Company!,'2.0');
        setAccessoroes(listAccessoroes.list_Accessories2s!);
    }

    useEffect(() => {
        const interval = setInterval(() => {
            getAccessoroes()
          }, 1000);
          return () => clearInterval(interval);
           
    }, []);

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



    const Columns: Column<List_Accessories2>[] = [
        {
            Header: 'ID',
            accessor: 'iD_Accessories',
            Filter: ColumnFilter,
            disableSortBy: true,
        },
        {
            Header: 'Тип',
            accessor: 'type_Сomponent',
            disableFilters: true,
            Filter: ColumnFilter
        },
        {
            Header: 'Название',
            accessor: 'name_Сomponent',
            disableFilters: true,
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
            Header: 'Статус',
            accessor: 'сharacteristics_info',   
            Filter: ColumnFilter2,
            disableSortBy: true,
            Cell: ({ cell }) => (
                <div>
                      {cell.row.values.сharacteristics_info}{"  "}
                    <div className='divnavlink'>
                        <NavLink className='divnavlink' to={`/detail/${cell.row.values.iD_Accessories}`}>Детали</NavLink>
                    </div>                           
                </div>
            )
        },
       
    ]
    const columns = useMemo(() => Columns, []);
    //  const data = useMemo(()=>orderslist, [] )

    const tableInstance = useTable({
        columns,
        data: accessoroess2
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

    const { register, handleSubmit, formState: { errors } } = useForm<FormData>({ mode: "onChange" });

    const onSubmit = handleSubmit(({ status
       }: any) => {

        const provider: Update_ProviderDto = {
            name_Company:  name_Company!,
            status:  status
        };
        update_provider(provider);
        getAccessoroes();
        alert("Запись обновлена");
    })

    return(
        <div>
            <table className='header_table'>
                    <tr>
                        <td>
                            <div className='div_orders'>
                            <h1> Комплектующие предоставляемые компанией: {name_Company}</h1>
                            </div>
                        </td>
                    </tr>
                </table>

                        <form className="App" action='' onSubmit={onSubmit} >    
                        <div>
                        <label htmlFor='status'>Изменить статус поставщика</label>
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
    <div className='table_div'>
        <h1>Список поставляемых комплектующих данным поставщиком</h1>
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
                    <div className='divtable'>
                    <div className='div_orders'>
                    <h1> Добавить комплектующие из представленных:</h1>
                    </div>
                    <table className='header_table'>
                    <tr>
                        <td>
                        <div className='creat_orders2'>
                          <NavLink type="a" className="button-login2" to={`/create/Radio_component/${name_Company}`}> Радиодетали </NavLink>     
                            </div>
                        </td>
                        <td>
                            <div className='creat_orders2'>
                            <NavLink type="a" className="button-login2" to={`/create/RAM/${name_Company}`}> ОЗУ </NavLink>       
                            </div>
                        </td>
                        <td>
                            <div className='creat_orders2'>
                            <NavLink type="a" className="button-login2" to={`/create/motherboard/${name_Company}`}> Материнская плата </NavLink>       
                            </div>
                        </td>
                        <td>
                            <div className='creat_orders2'>
                            <NavLink type="a" className="button-login2" to={`/create/cpu/${name_Company}`}> CPU </NavLink>       
                            </div>
                        </td>
                    </tr>
                </table>
                </div>         
                </div> 
        </div>
    )
}
export default Info_Provider