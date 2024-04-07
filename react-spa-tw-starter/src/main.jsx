import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import {BrowserRouter, Route, Routes,} from "react-router-dom";
import {ProtectedRoute} from "@/components/ProtectedRoute.jsx";
import {AuthProvider} from "@/hooks/useAuth.jsx";
import Login from "./components/Login.jsx";
import Register from "./components/Register.jsx";
import {Layout} from "./components/layout.jsx";
import {About} from "./components/about.jsx";

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <AuthProvider>
        <Routes>
          <Route path="/" element={<ProtectedRoute>
            <Layout/>
          </ProtectedRoute>}>
            <Route index element={<App/>}/>
            <Route path="about" element={<About/>} />
          </Route>
          <Route path="login" element={<Login/>} />
          <Route path="register" element={<Register/>} />
        </Routes>
      </AuthProvider>      
    </BrowserRouter>

  </React.StrictMode>,
)