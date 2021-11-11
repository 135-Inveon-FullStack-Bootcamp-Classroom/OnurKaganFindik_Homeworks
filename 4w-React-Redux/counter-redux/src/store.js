import { configureStore } from '@reduxjs/toolkit'
import counterReducer from './stores/counter'

export default configureStore({
  reducer: {
    counter: counterReducer
  },
})