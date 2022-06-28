import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { Create_Order_ClientDto, Client, List_Order_Client } from '../../api/api';
import { FormControl } from 'react-bootstrap';
import styles from './styles.module.css';
import AuthProvider from '../../auth/auth-provider';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import DetailOrder from './DetailOrder';
import { NavLink } from 'react-router-dom';
import matchSorter from "match-sorter";
import Select from "react-select";
import { render } from "react-dom";
import ReactTable from 'react-table';
import getOrder from './Orderlist';
// import "react-select/dist/react-select.css";
// import "react-table/react-table.css";

class Table_Orders extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        orders: getOrder(),
        filtered: [],
        select2: undefined
      };
    };
    onFilteredChangeCustom = (value, accessor) => {
      let filtered = this.state.filtered;
      let insertNewFilter = 1;
  
      if (filtered.length) {
        filtered.forEach((filter, i) => {
          if (filter["id"] === accessor) {
            if (value === "" || !value.length) filtered.splice(i, 1);
            else filter["value"] = value;
  
            insertNewFilter = 0;
          }
        });
      }
  
      if (insertNewFilter) {
        filtered.push({ id: accessor, value: value });
      }
  
      this.setState({ filtered: filtered });
    };
    render() {
      const { orders } = this.state;
      return (
        <div>
          <ReactTable
            orders ={orders }
            filterable
            filtered={this.state.filtered}
            onFilteredChange={(filtered, column, value) => {
              this.onFilteredChangeCustom(value, column.id || column.accessor);
            }}
            defaultFilterMethod={(filter, row, column) => {
              const id = filter.pivotId || filter.id;
              if (typeof filter.value === "object") {
                return row[id] !== undefined
                  ? filter.value.indexOf(row[id]) > -1
                  : true;
              } else {
                return row[id] !== undefined
                  ? String(row[id]).indexOf(filter.value) > -1
                  : true;
              }
            }}
            columns={[
              {
                Header: "Name",
                columns: [
                  {
                    Header: "First Name",
                    accessor: "name_Client"
                  },
                  {
                    Header: "Last Name",
                    id: "lastName_Client",
                    accessor: d => d.lastName_Client
                  }
                ]
              },
              {
                Header: "Info",
                columns: [
                  {
                    Header: "Age",
                    accessor: "price",
                    sortable: false,
                    filterable: false,
                  },
                  {
                    Header: "Over 21",
                    accessor: " price",
                    filterMethod: (filter, row) => {
                      if (filter.value.indexOf("all") > -1) {
                        return true;
                      }
                      if (filter.value.indexOf("true") > -1) {
                        return row[filter.id] >= 21;
                      }
                      return row[filter.id] < 21;
                    },
                    Filter: ({ filter, onChange }) => {
                      return (
                        <select
                          onChange={event => {
                            let selectedOptions = [].slice
                              .call(event.target.selectedOptions)
                              .map(o => {
                                return o.value;
                              });
  
                            this.onFilteredChangeCustom(selectedOptions, "over");
                          }}
                          style={{ width: "100%" }}
                          value={filter ? filter.value : ["all"]}
                          multiple={true}
                        >
                          <option value="all">Show All</option>
                          <option value="true">Can Drink</option>
                          <option value="false">Can't Drink</option>
                        </select>
                      );
                    }
                  }
                ]
              }
            ]}
            defaultPageSize={10}
            className="-striped -highlight"
          />
          <br />
        </div>
      );
    }
}
export default Table_Orders;