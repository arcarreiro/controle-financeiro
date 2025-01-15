import React from "react";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom/cjs/react-router-dom.min";
import { Sidebar } from "../Components/Sidebar";
import Login from "../Pages/Login";
import ProtectedRoute from "../Components/ProtectedRoute";
import './routes.css'
import { useAuth } from "../Context/AuthContext";
import Home from "../Pages/Home";

function Routes() {

    return (
        <BrowserRouter>
            <Switch>
                <Route exact path="/">
                    <RedirectToHomeOrLogin />
                </Route>
                <div className="globalDiv">
                    <Sidebar />
                    <Route exact path="/login" component={Login} />
                    <ProtectedRoute exact path="/home" component={Home} />
                </div>
            </Switch>
        </BrowserRouter>
    )

}
function RedirectToHomeOrLogin() {
    const { isAuthenticated } = useAuth();

    return isAuthenticated ? <Redirect to="/home" /> : <Redirect to="/login" />;
}

export default Routes;