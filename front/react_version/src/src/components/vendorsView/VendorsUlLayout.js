
//
import VendorsUlItem from "./VendorsUlItem";

export default (props) => {

    return(<>
        <h2>{props.propName}</h2>
        <ul>
            {props.vendors.map((v, i) => (
                <VendorsUlItem key={i} vendor={v} />
            ))}
        </ul>
    </>)

}