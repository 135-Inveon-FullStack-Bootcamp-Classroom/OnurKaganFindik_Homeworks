import {increment,decrement,reset, incrementByAmount, decrementByAmount} from "../stores/counter"
import  {useDispatch} from "react-redux"

// Action Creators
function CounterActions({count,setCount}) {

    const dispatch = useDispatch()

    return (
        <div>
            <button onClick={()=> dispatch(decrementByAmount)}>Decrease By Amount (-)</button>
            <button onClick={()=> dispatch(decrement)}>Decrease (-)</button>
            <button onClick={()=> dispatch(reset)}>Reset (0)</button>
            <button onClick={()=> dispatch(increment)}>Increase (+)</button>
            <button onClick={()=> dispatch(incrementByAmount)}>Increment By Amount (-)</button>



        </div>
    )
}

export default CounterActions;