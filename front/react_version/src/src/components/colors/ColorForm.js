import {MyFetch} from "../../helpers/MyFetch";
import MyLog from "../../helpers/MyLog";

export default (props) => {


    const onSubmit = (ev) => {
        ev.preventDefault()

        const frmData = new  FormData(ev.target)

        MyLog(frmData)

        MyFetch('ApiColor', {
            method: "POST",
            body: frmData
        })
            .then(res => {
                MyLog(res)
                props.getColors()
            })

        return false;
    }


    return (
            <form onSubmit={onSubmit} method='POST'  enctype="multipart/form-data">
                <input type='text' name='Name'/>
                <input type='color' name='RGB'/>
                <input type='file' name='file'/>
                <input type='text' name='Code'/>
                <input type='submit'/>
            </form>
    )

}