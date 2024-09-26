
//
import VendorsTableItem from "./VendorsTableItem";

export default (props) => {

    console.log(props)

    return(<>
        <table>
            {props.vendors.map((v, i) => (
                <VendorsTableItem
                    key={i} vendor={v} />
            ))}
        </table>
    </>)

}