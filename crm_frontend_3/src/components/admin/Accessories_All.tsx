import React, { FC, ReactElement, useRef, useEffect, useState, useMemo } from 'react';
import { AccessoriesClient,List_Accessories } from '../../api/api2';
import { FormControl } from 'react-bootstrap';
import { loadUser, getrole,admin } from '../../auth/user-service';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";

import { format, formatDistance, formatRelative, subDays } from 'date-fns';
import generateExcel from "zipcelx";
import { NavLink } from 'react-router-dom';


const apiClient = new AccessoriesClient('https://localhost:44325');

const Accessories_All: FC<{}> = (): ReactElement => {
    const [accessoroess, setAccessoroes] = useState<List_Accessories[]>([]);

    async function getAccessoroes() {
        const listAccessoroes = await apiClient.all_accessories('2.0');
        setAccessoroes(listAccessoroes.list_Accessoriess);
    }
    useEffect(() => {
        setTimeout(getAccessoroes, 10);
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
                            <h1> Список комплектующих от всех компаний </h1>
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
export default  Accessories_All