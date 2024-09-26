import {toast} from "react-toastify";


export default (msg) => {
    console.error(msg)

    if (typeof (msg) === 'string') {
        toast.error(msg)
    }
}