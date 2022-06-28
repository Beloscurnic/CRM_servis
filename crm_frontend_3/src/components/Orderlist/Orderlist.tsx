import React, { FC, ReactElement, useRef, useEffect, useState, useMemo } from 'react';
import { Create_Order_ClientDto, Client, List_Order_Client } from '../../api/api';
import { FormControl } from 'react-bootstrap';
import { loadUser, getrole,dispatcher } from '../../auth/user-service';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import './table.css';
import { format, formatDistance, formatRelative, subDays } from 'date-fns';
import generateExcel from "zipcelx";
import { NavLink } from 'react-router-dom';




interface Order_List {
    iD_Order: number;
    name_Client?: string;
}


const apiClient = new Client('https://localhost:44325');

const OrderList: FC<{}> = (): ReactElement => {

    // let textInput = useRef(null);
    const [orders, setOrders] = useState<List_Order_Client[]>([]);
   

    async function getOrder() {
        const orderListVm = await apiClient.getAll('1.0')
        // console.log(orderListVm);
        setOrders(orderListVm.orders);
    }

    useEffect(() => {
            getOrder()
    }, []);

    const [orderslist, setOrderslist] = useState<Order_List[]>([]);

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
                    <option className='option_text' value='Выдано'>Выдано</option>
                </select>
            </span>

        )
    }

    async function list(order: List_Order_Client[] | undefined) {
        let structur = [];

        for (let i = 0; i < order!.length; i++) {
            structur[i] = {
                iD_Order: order![i]['iD_Order'],
                name_Client: order![i]['name_Client'],
            };
        }
        setOrderslist(structur);
    }

    // const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
    //     if (event.key === 'Enter') {
    //         const order: Create_Order_ClientDto = {
    //             iD_Client: parseInt(event.currentTarget.value),
    //         };
    //         createOrder(order);
    //         event.currentTarget.value = '';
    //         setTimeout(getOrder, 500);
    //     }
    // };

    function NavLinkButton({
        row: data,
    }: FilterProps<List_Order_Client>) {
        const list_order = data.iD_Order
        return (
            <div>
                <NavLink type="button" className="btn btn--m btn--blue" to={`${list_order}`}>Детали</NavLink>
            </div>
        )
    }

    const Columns: Column<List_Order_Client>[] = [
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
                        <NavLink to={`${cell.row.values.iD_Order}`}>Детали</NavLink>
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

    function getHeader(column: any) {
        if (column.totalHeaderCount === 1) {
            return [
                {
                    value: column.Header,
                    type: "string"
                }
            ];
        } else {
            return [
                {
                    value: column.Header,
                    type: "string"
                },

            ];
        }
    }


    function getExcel() {

        const config = {
            filename: "general-ledger-Q1",
            sheet: {
                data: [] as any
            }
        };

        const dataSet = config.sheet.data;

        // review with one level nested config
        // HEADERS
        headerGroups.forEach(headerGroup => {
            const headerRow: { value: any; type: string; }[] = [];
            if (headerGroup.headers) {
                headerGroup.headers.forEach(column => {
                    headerRow.push(...getHeader(column));
                });
            }

            dataSet.push(headerRow);
        });

        // FILTERED ROWS
        if (rows.length > 0) {
            rows.forEach(row => {
                const dataRow: { value: any; type: string; }[] = [];

                Object.values(row.values).forEach(value =>
                    dataRow.push({
                        value,
                        type: typeof value === "number" ? "number" : "string"
                    })
                );

                dataSet.push(dataRow);
            });
        } else {
            dataSet.push([
                {
                    value: "No data",
                    type: "string"
                }
            ]);
        }
        return generateExcel(config);
    }
    return (
        <div>

            <section>
                <table className='header_table'>
                    <tr>
                        <td>
                            <div className='div_orders'>
                                <h1>Список заказов</h1>
                            </div>
                        </td>
                        <td>
                            {/* <button onClick={getExcel}>Get Excel</button> */}
                            <div className='creat_orders'>
                                <NavLink type="a" className="btn btn--m btn--blue" to={"create"}> <li>Cоздать заказ</li></NavLink>
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

};
export default OrderList;