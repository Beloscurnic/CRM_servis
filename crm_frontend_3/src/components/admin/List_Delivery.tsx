import React, { FC, ReactElement, useRef, useEffect, useState, useMemo } from 'react';
import { GetAllClient,UpdateClient,List_Delivery,Update_DeliveryDto} from '../../api/api2';
import { FormControl } from 'react-bootstrap';
import { loadUser, getrole,admin } from '../../auth/user-service';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";

import { format, formatDistance, formatRelative, subDays } from 'date-fns';
import generateExcel from "zipcelx";
import { NavLink } from 'react-router-dom';


const apiClient2 = new UpdateClient('https://localhost:44325');
const apiClient = new GetAllClient('https://localhost:44325');

const List_delivery: FC<{}> = (): ReactElement => {

    const [delivery, setDelivery] = useState<List_Delivery[]>([]);
    async function getDelivery() {
        const DeliveryListVm = await apiClient.Get_delivery('2.0')
        // console.log(orderListVm);
        setDelivery(DeliveryListVm.list_Deliverys);
    }

    useEffect(() => {
        const interval = setInterval(() => {
            getDelivery()
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
                    <option className='option_text' value="Экспорт">Экспорт</option>
                    <option className='option_text' value='Импорт'>Импорт</option>
                    <option className='option_text' value='Закрыт'>Закрыт</option>   
                </select>
            </span>

        )
    }

    async function handleClick(id: string){
        const delivery: Update_DeliveryDto = {
            iD_Delevery :parseInt(id!),
         };
        await apiClient2.update_Delivery('2.0',delivery);
        getDelivery();
    }

    const Columns: Column<List_Delivery>[] = [
        {
            Header: 'ID',
            accessor: 'iD_Delevery',
            disableSortBy: true,
            Filter: ColumnFilter
        },
        {
            Header: 'Компания',
            accessor: 'name_Company',
            disableSortBy: true,
            Filter: ColumnFilter
        },
        {
            Header: 'ID компонента',
            accessor: 'iD_Accessories',
            disableSortBy: true,
            Filter: ColumnFilter
        },
        {
            Header: 'Имя компонента',
            accessor: 'name_Сomponent',
            Filter: ColumnFilter,
            disableFilters: true,
            disableSortBy: true,
        },
        {
            Header: 'Дата заказа',
            accessor: 'receipt_date',     
            Cell: ({ value }) => { return format(new Date(value), 'dd/MM/yyyy') },
            Filter: ColumnFilter,
            disableSortBy: true,
        },
        {
            Header: 'Дата поступления',
            accessor: 'issue_date',          
            Filter: ColumnFilter,
            disableSortBy: true,
        },
        {
            Header: 'лей/штука',
            accessor: 'price_Сomponent',
            Filter: ColumnFilter,
            disableSortBy: true,
            disableFilters: true
        },
        {
            Header: 'Количество',
            accessor: 'quantity_Сomponent',
            disableSortBy: true,
            Filter: ColumnFilter,
            disableFilters: true
        },
        {
            Header: 'Сумма',
            accessor: 'summa',
            disableSortBy: true,
            Filter: ColumnFilter,
            disableFilters: true
        },
        {
            Header: 'Статус',
            accessor: 'status',
            disableSortBy: true,
            Filter: ColumnFilter2,
            Cell: ({ cell }:{cell:any}) => (
                <div>
                {cell.row.values.status}{"  "}
                </div>   
            )
        },
    ]

    const columns = useMemo(() => Columns, []);
    //  const data = useMemo(()=>orderslist, [] )

    const tableInstance = useTable({
        columns,
        data: delivery
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
                                <h1>Список заказов на доставку</h1>
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
export default List_delivery;