import MyLog from "../../helpers/MyLog";
import MyError from "../../helpers/MyError";
import {toast} from "react-toastify";


export default async (searchParams = null, options = null) =>  {

    // Базове посилання до мого API
    const url = new URL( 'https://66f58e32436827ced9745ccb.mockapi.io/products');

    // Якщо є параметри - побудувати запит у url
    if (searchParams) {
        searchParams.map (p => {
            // url = url + 'name' + '=' + value
            url.searchParams.append(p.name, p.value)
        })
    }

    toast.info(url.toString())


    try {
        const response = await fetch(url, {
            headers: {
            },
            ...options,
        });

        return await response.json();
    } catch (error) {
        MyError(error)
    }
}