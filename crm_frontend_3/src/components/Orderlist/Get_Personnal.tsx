import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import {  Client, Order_Client_DetailsVm, PersonnalVm } from '../../api/api';
import { NavLink,useParams } from 'react-router-dom';
import userManager, { loadUser} from '../../auth/user-service';

const apiClient = new Client('https://localhost:44325');


const Get_Personnal: FC<{name:string}> = (childre, name): ReactElement => {

    console.log(name);
    const [personnal, setPersonnal] = useState<PersonnalVm>();
//   const  { prodId }  = useParams();
        const params = useParams();
        const prodId = params.id;

        async function getPersonnal(id: string) {
            // console.log(prodId);
             const personalVm = await apiClient.personnal(id!, '1.0')
             setPersonnal(personalVm);
             console.log(personalVm);
         }
     
         useEffect(() => { 
             getPersonnal('bded96ad-7dee-45a4-8bd7-a1951aca487d');
         }, []);
     
     
         return (
             <div>
                    {personnal?.name} {personnal?.last_Name}
             </div>
         );
     };
export default Get_Personnal;