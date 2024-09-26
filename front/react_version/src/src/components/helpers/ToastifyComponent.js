import { toast } from 'react-toastify';

export default () => {



    const showToastInfo = () => {
        toast.info("Hello Toast")
    }

    const showToastError = () => {
        toast.error("Error Toast")
    }

    return (
        <div>
            <button onClick={showToastInfo}>Info</button>
            <button onClick={showToastError}>Error</button>
        </div>
    )

}

