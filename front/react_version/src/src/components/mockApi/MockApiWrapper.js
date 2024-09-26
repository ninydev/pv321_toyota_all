import {useEffect, useState} from "react";
import MockApiFetch from "./MockApiFetch";

export default () => {


    const [products, setProducts] = useState([]);
    const [page, setPage] = useState(1);
    const [limit, setLimit] = useState(10);


    const getData = () => {

        const searchParams = [
            {name: 'page', value: page},
            {name: 'limit', value: limit},
        ]

        MockApiFetch(searchParams)
            .then(data => {
                setProducts(data)
            })
    }

    const doSetLimit = (ev) => {
        const v = ev.target.value
        if (v < 1 || v > 20) {return}

        setLastPageLoadMore(0)
        setLimit(v)
    }

    const doSetPage = (ev) => {
        const v = ev.target.value
        if (v < 1 || v > 20) {return}
        setLastPageLoadMore(0)
        setPage(v)

    }

    const [lastPageLoadMore, setLastPageLoadMore] = useState(0)

    const doLoadMore = () => {
        if (lastPageLoadMore === 0 ) {
            setLastPageLoadMore(parseInt(page) + 1)
        } else {
            setLastPageLoadMore(parseInt(lastPageLoadMore) + 1);
        }
    }

    useEffect(() => {
        if (lastPageLoadMore === 0 ) { return }
        const searchParams = [
            {name: 'page', value: lastPageLoadMore},
            {name: 'limit', value: limit},
        ]

        MockApiFetch(searchParams)
            .then(data => {
                setProducts(prevProducts => [...prevProducts, ...data]);
            })
    }, [lastPageLoadMore])




    useEffect(() => {
        getData()
    }, [limit, page]);


    return (<>
            <h1> Data from MockApi</h1>
        <div>
            <label>Limit: <input type='number'
                                 value={limit}
                                 onChange={doSetLimit}/></label>

            <label>Page: <input type='number'
                                 value={page}
                                 onChange={doSetPage}/></label>
        </div>
        <ul>
            {products.map((p, i) =>
                (<li key={i}>
                    <p>{p.name}</p>
                    <img src={p.photo} width='50px' />
                    </li>))}
            </ul>
        <button onClick={doLoadMore}> Load More </button>
        </>)
}