//
import {useState} from "react";

export default (props) => {

    console.log(props)

    const [viewType, setViewType] = useState('view')

    const setEdit = () => {setViewType('edit')}
    const setView= () => {setViewType('view')}



    return (<>
        <tr>
            <td>
                {viewType === 'view' ? (
                    <>
                        {props.vendor.name}
                        <span onClick={setEdit}> edit </span>
                    </>
                ) : (
                    <>
                    <input
                        type='text' value={props.vendor.name}/>
                        <span onClick={setView}> close </span>
                    </>

                )}

            </td>
        </tr>
    </>)

}