import { useState } from 'react'
import { ThemeContextProvider } from './Context/ThemeContext'
import { Sidebar } from './Components/Sidebar'

import "../node_modules/bootstrap/dist/css/bootstrap.min.css";

import "./css/colors.css";


import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";

import "./Global.css";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
     <ThemeContextProvider>
      <Sidebar/>
     </ThemeContextProvider>
    </>
  )
}

export default App
