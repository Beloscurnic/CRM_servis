import Reacr from 'react';

 export  const ColumnFilter = async({ column }) => {
    const {filterValue, setFilter}=column
    return(
        <span>
            Поиск:{' '}
            <input value={filterValue || ''} onChange={(e)=>setFilter(e.target.value)}></input>
        </span>
    )
}