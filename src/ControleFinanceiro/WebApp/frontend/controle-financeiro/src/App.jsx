import { useState } from 'react'
import { ThemeContextProvider } from './Context/ThemeContext'
import { Sidebar } from './Components/Sidebar'

import "../node_modules/bootstrap/dist/css/bootstrap.min.css";

import "./css/colors.css";


import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";

import "./Global.css";
import PageContainer from './Components/PageContainer';
import Login from './Pages/Login';
import { AuthProvider } from './Context/AuthContext';
import Routes from './Routes/Routes';

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    <AuthProvider>
     <ThemeContextProvider>
      <Routes/>
     </ThemeContextProvider>
    </AuthProvider>
    </>
  )
}

export default App
