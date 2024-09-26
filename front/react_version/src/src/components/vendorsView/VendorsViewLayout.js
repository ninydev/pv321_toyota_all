import {useState} from "react";
import VendorsTableLayout from "./VendorsTableLayout";
import VendorsUlLayout from "./VendorsUlLayout";


export default () => {

    const [viewType, setViewType] = useState('table')

    const setViewTypeToTable = () => {
        setViewType('table')
    }

    const setViewTypeToList = () => {
        setViewType('list')
    }

    const someVal = "Hello Props"

    const [vendors, setVendors] = useState([
        {name: 'Apple', logoUrl: ''},
        {name: 'Samsung', logoUrl: ''},
        {name: 'Dell', logoUrl: ''}
    ]);

    return (<>
        <h1> Vendor List </h1>

        <p>
            <span onClick={setViewTypeToTable}>To Table </span>
            <span onClick={setViewTypeToList}> To List </span>
        </p>

        {viewType === 'table' ? (
            <VendorsTableLayout vendors={vendors} />
        ) : (
            <VendorsUlLayout vendors={vendors} />
        )}
    </>)
}


//
// <ul>
//     {vendors.map((v, i) => (
//         <li key={i}>{v.name}</li>
//     ))}
// </ul>

//
// <table>
//     {vendors.map((v, i) => (
//         <tr key={i}>
//             <td>    {v.name}</td>
//         </tr>
//     ))}
// </table>