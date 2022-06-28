import React, { FC, ReactElement, useRef, useEffect, ChangeEvent, ChangeEventHandler, useState,useMemo } from 'react';
import {  CreateClient,Create_CPUDto } from '../../api/api2';
import { NavLink,useParams } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import { Column, useTable, useSortBy, useFilters, usePagination, FilterProps } from "react-table";
import { Value } from 'sass';
import { Console } from 'console';
import { appendErrors, useForm } from 'react-hook-form'
import { useNavigate } from 'react-router-dom';
import Creat_CPU from './Creat_CPU';
import "./styles/Creat_Accessories.css"



const Creat_Accessories: FC<{}> = (): ReactElement => {
    const params = useParams();
    const name_Company = params.name_Company;


    
 return (
<div className='divwrapper'>
<div className='left_block'>
    <div className='div_orders'>
        <div className='creat_orders3'>
            <NavLink type="a" className="button-login2" to={`/create/cpu/${name_Company}`}> CPU </NavLink>    
        </div>                
	</div>
    </div>
    <div className='right_block'>
    <Creat_CPU/>
	</div>
</div>
 )
}
export default Creat_Accessories