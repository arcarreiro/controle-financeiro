import React from "react";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom/cjs/react-router-dom.min";
import { Sidebar } from "../Components/Sidebar";
import Login from "../Pages/Login";
import ProtectedRoute from "../Components/ProtectedRoute";
import Overview from "../Pages/Overview";
import './routes.css'
import Revenue from "../Pages/Revenue";
import Expenses from "../Pages/Expenses";
import Goals from "../Pages/Goals";
import { useAuth } from "../Context/AuthContext";

function Routes() {

    return (
        <BrowserRouter>
            <Switch>
                <Route exact path="/">
                    <RedirectToHomeOrLogin />
                </Route>
                <div className="globalDiv">
                    <Sidebar />
                    <ProtectedRoute exact path="/login" component={Login} />
                    <ProtectedRoute exact path="/home" component={Overview} />
                    <ProtectedRoute exact path="/revenue" component={Revenue} />
                    <ProtectedRoute exact path="/expenses" component={Expenses} />
                    <ProtectedRoute exact path="/goals" component={Goals} />
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