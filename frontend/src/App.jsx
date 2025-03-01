import { useState } from 'react'
import './App.css'
import Login from './Components/login'
import UsersList from './Components/UsersList'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      
          <Login></Login>
          <UsersList></UsersList>
    </>
  )
}

export default App
