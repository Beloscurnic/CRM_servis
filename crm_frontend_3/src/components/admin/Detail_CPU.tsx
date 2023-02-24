import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import {AccessoriesClient,Accessories_CPUVm,TypeClient,Type_AccessoriesVm,Get_AccessoriesVm,Update_AccessoriesDto,UpdateClient,CreateClient,Creat_DeliveryDto } from '../../api/api2';
import { NavLink,useParams ,useNavigate} from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';
import '../Orderlist/squere.css'

import jsPDF from "jspdf";
import autoTable from 'jspdf-autotable';
import '../Orderlist/detail_order.css';
import { appendErrors, useForm,Controller } from 'react-hook-form'