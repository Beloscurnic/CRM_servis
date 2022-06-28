import React, { FC, ReactElement, useRef, useEffect, useState, useMemo } from 'react';
import { GetAllClient,List_Provider} from '../../api/api2';
import { FormControl } from 'react-bootstrap';
import { loadUser, getrole,admin } from '../../auth/user-service';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";

import { format, formatDistance, formatRelative, subDays } from 'date-fns';
import generateExcel from "zipcelx";
import { NavLink } from 'react-router-dom';


const apiClient = new GetAllClient('https://localhost:44325');

const Adminlist: FC<{}> = (): ReactElement => {

    const [providers, setProvider] = useState<List_Provider[]>([]);
    async function getProvider() {
        const orderListVm = await apiClient.provider('2.0')
        // console.log(orderListVm);
        setProvider(orderListVm.list_Providers);
    }

    useEffect(() => {
        const interval = setInterval(() => {
            getProvider()
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
                    <option className='option_text' value="Активен">Активен</option>
                    <option className='option_text' value='Не доступен'>Не доступен</option>
                    <option className='option_text' value='Прекращено сотрудничество'>Прекращено сотрудничество</option>
                    
                </select>
            </span>

        )
    }

    const Columns: Column<List_Provider>[] = [
        {
            Header: 'ID',
            accessor: 'iD_Provider',
            Filter: ColumnFilter
        },
        {
            Header: 'Название компании',
            accessor: 'name_Company',
            Filter: ColumnFilter
        },
        {
            Header: 'Идентификационный номер',
            accessor: 'identification_Number',
            Filter: ColumnFilter
        },
        {
            Header: 'Адресс',
            accessor: 'supplier_Address',
            Filter: ColumnFilter,
            disableFilters: true,
            disableSortBy: true,
        },
        {
            Header: 'ФИО директора',
            accessor: 'fiO_Director',
            Filter: ColumnFilter,
            disableFilters: true,
            disableSortBy: true,
        },

        {
            Header: 'Телефон',
            accessor: 'telefon',
            disableSortBy: true,
            Filter: ColumnFilter,
            disableFilters: true
        },
       
        {
            Header: 'Статус',
            accessor: 'status',
            disableSortBy: true,
            Filter: ColumnFilter2
           
        },
        {
            Header: '',
            accessor: 'comments',
            disableSortBy: true,
            Filter: ColumnFilter,
            disableFilters: true,
            Cell: ({ cell }:{cell:any}) => (
                    <div>
                        <NavLink to={`/provider/${cell.row.values.name_Company}`}>Детали</NavLink>
                    </div>     
            )
        },
    ]

    const columns = useMemo(() => Columns, []);
    //  const data = useMemo(()=>orderslist, [] )

    const tableInstance = useTable({
        columns,
        data: providers
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
            <section>
                <table className='header_table'>
                    <tr>
                        <td>
                            <div className='div_orders'>
                                <h1>Список поставщиков</h1>
                            </div>
                        </td>
                        <td>
                            {/* <button onClick={getExcel}>Get Excel</button> */}
                            <div className='creat_orders'>
                                <NavLink type="a" className="btn btn--m btn--blue" to={"create"}> <li>Добавить поставщика</li></NavLink>
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
                        <div>

                            <div className='div_pagination'>
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
                        </div>
                    </table>

                </div>
            </section>
        </div>
    )
}
export default Adminlist;