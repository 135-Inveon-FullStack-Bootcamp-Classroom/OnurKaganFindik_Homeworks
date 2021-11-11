import { createSlice } from '@reduxjs/toolkit'

// The initial state of the counter
export const counter = createSlice({
    
    name: 'counter',
    initialState: {
        value: 1,
    },
    // The reducer function
    reducers: { 
        increment: state => {

            state.value += 1
        },  

        decrement: state => {

            state.value -= 1
        },

        reset: state => {
            state.value = 0
        },
        
        incrementByAmount: (state, action) => { state += action.payload
        },
    
        decrementByAmount: (state, action) => {
            state -= action.payload
        },

    }
})

export const { increment, decrement, incrementByAmount, reset, decrementByAmount } = counter.actions
export default counter.reducer