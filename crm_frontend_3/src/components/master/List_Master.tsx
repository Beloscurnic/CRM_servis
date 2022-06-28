import React, { FC, ReactElement, useRef, useEffect, useState, useMemo } from 'react';
import {ListClient,List_Order_Master  } from '../../api/api3';
import { FormControl } from 'react-bootstrap';
import { loadUser, getrole,dispatcher } from '../../auth/user-service';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import { format, formatDistance, formatRelative, subDays } from 'date-fns';
import generateExcel from "zipcelx";
import { NavLink } from 'react-router-dom';

const apiClient = new ListClient('https://localhost:44325');

const List_Master: FC<{}> = (): ReactElement => {

    const [orders, setOrders] = useState<List_Order_Master[]>([]);
   

    async function getOrder() {
        const orderListVm = await apiClient.order_list('3.0')
        // console.log(orderListVm);
        setOrders(orderListVm.orders);
    }

    useEffect(() => {
        setTimeout(getOrder, 500);
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
                    <option className='option_text' value="Диагностика">диагностика</option>
                    <option className='option_text' value="Ремонт">Ремонт</option>
                    <option className='option_text' value='Выдача'>Выдача</option>
                </select>
            </span>

        )
    }

    const Columns: Column<List_Order_Master>[] = [
        {
            Header: 'ID',
            accessor: 'iD_Order',
            Filter: ColumnFilter,
            disableSortBy: true
        },
        {
            Header: 'Имя',
            accessor: 'name_Client',
            Filter: ColumnFilter

        },
        {
            Header: 'Фамилия',
            accessor: 'lastName_Client',
            Filter: ColumnFilter
        },
        {
            Header: 'Email',
            accessor: 'email_Client',
            Filter: ColumnFilter, 
            disableSortBy: true,
            disableFilters: true
        },
        {
            Header: 'Телефон',
            accessor: 'telefon',
            Filter: ColumnFilter,
            disableSortBy: true
        },
        {
            Header: 'Дата поступления',
            accessor: 'receipt_date',
            Cell: ({ value }) => { return format(new Date(value), 'dd/MM/yyyy') },
            Filter: ColumnFilter,
            disableSortBy: true,
        },
        {
            Header: 'Статус',
            accessor: 'status_Order',
            Filter: ColumnFilter2,
            disableSortBy: true
        },
        {
            Header: 'Цена',
            accessor: 'price',
            Filter: ColumnFilter,
            disableFilters: true,
            disableSortBy: true,
            Cell: ({ cell }) => (
                <div>
                    {cell.row.values.price}{"  "}
                    <div>
                        <NavLink to={`detail/${cell.row.values.iD_Order}`}>Детали</NavLink>
                    </div>
                </div>
            )
        },

    ]

    const columns = useMemo(() => Columns, []);
    //  const data = useMemo(()=>orderslist, [] )

    const tableInstance = useTable({
        columns,
        data: orders
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
                        <h1>Список заказов</h1>
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
export default List_Master;