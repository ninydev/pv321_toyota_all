import {useState} from "react";

export default () => {

    // let txtValue = "keeper@ninydev.com"
    const [txtValue, setTxtValue] = useState("keeper@ninydev.com");

    const myOnChange = (event) => {
        setTxtValue(event.target.value);

        // console.log(event.target.value)
        // txtValue = event.target.value

        console.log("change")
    }


    return (<>
            <input type="text" value={txtValue} onChange={myOnChange}/>
            <input/>
        <div>{txtValue}</div>
        </>)
}