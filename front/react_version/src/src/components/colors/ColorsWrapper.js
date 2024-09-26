import {useEffect, useState} from "react";
import ColorItem from "./ColorItem";
import {toast} from "react-toastify";
import MyLog from "../../helpers/MyLog";
import {MyFetch} from "../../helpers/MyFetch";
import MyError from "../../helpers/MyError";
import ColorForm from "./ColorForm";

export default () => {


    const [colors, setColors] = useState([])

    const [paginate, setPaginate] = useState({})


    /**
     *
     * @param id
     */
    const delColor = (id) => {
        MyFetch('ApiColor/' + id, {
            method: "DELETE"
        })
            .then(res => {
                MyLog(res)
                setColors((prevColors) => prevColors.filter(color => color.id !== id));
            })
    }


    const getColors = () => {

        // const url = new URL('ApiColor');
        // url.searchParams.append('PageSize', PageSize); //https://PROJECT_TOKEN.mockapi.io/tasks?completed=false
        // url.searchParams.append('page', 1); //https://PROJECT_TOKEN.mockapi.io/tasks?completed=false&page=1
        // url.searchParams.append('limit', 10); //https://PROJECT_TOKEN.mockapi.io/tasks?completed=false&page=1&limit=10


        // MyFetch('ApiColor?' + 'PageSize=' + pageSize + '&page=' + currentPage )

        MyFetch('ApiColor')
            .then(res => {
                        setColors(res.data)
                        setPaginate(res.paginate)
            })

        // fetch('http://localhost:5227/api/ApiColor')
        //     .then(res => {
        //
        //         MyLog(res)
        //         MyLog(res.statusText)
        //
        //         // console.log(res)
        //         // console.log(res.status + " " + res.statusText)
        //         return res.json()
        //     })
        //     .then(res => {
        //         setColors(res.data)
        //         setPaginate(res.paginate)
        //         toast.info("Total Items: " + res.paginate.totalItems)
        //     })
        //     .catch(err=> {
        //         console.error(err)
        //         toast.error(err.message)
        //     })
    }

    // getColors()
    useEffect(() => {
        getColors()
    }, []);




    return (
    <>
        <h1> Colors </h1>
        <ul>
            {colors.map((color, i) => (
                // Добавил return и исправил ключи
                <ColorItem color={color}
                           delColor={delColor}
                           getColors={getColors}
                           key={i} />
            ))}
        </ul>

        <ColorForm
            getColors={getColors}
        />


    </>
    )

}