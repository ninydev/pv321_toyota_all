import {toast} from "react-toastify";


export default (msg) => {
    console.log(msg)

    if (typeof (msg) === 'string') {
        toast.info(msg)
    }
}