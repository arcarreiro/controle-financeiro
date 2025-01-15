import React, { useContext, useState } from "react";
import { ThemeContext } from "../../Context/ThemeContext";
import { SidebarStyle } from "./style";
import { Col, Row } from "react-bootstrap";

import { MdContrast } from "react-icons/md";
import { HiOutlineSquares2X2 } from "react-icons/hi2";
import { BsPiggyBank } from "react-icons/bs";
import { LiaFileInvoiceDollarSolid } from "react-icons/lia";
import { PiTargetBold } from "react-icons/pi";
import { BiLogOut } from "react-icons/bi";
import { useHistory } from "react-router-dom";
import ModalLogout from "../ModalLogout";
import { useAuth } from "../../Context/AuthContext";
import ModalRegisterUser from "../ModalRegisterUser";
import ModalAddRevenue from "../ModalAddRevenue";
import ModalAddExpense from "../ModalAddExpense";
import { toast } from "react-toastify";



export function Sidebar() {
    const { isAuthenticated, logout } = useAuth();
    const { darkThemeIsActive, handleTheme } = useContext(ThemeContext);
    const [show, setShow] = useState(false);
    const [showRegister, setShowRegister] = useState(false);
    const [showRevenue, setShowRevenue] = useState(false);
    const [showExpense, setShowExpense] = useState(false);
    const history = useHistory();

    function handleClose() {
        setShow(false);
        setShowRegister(false);
        setShowRevenue(false);
        setShowExpense(false);
    }

    function handleShow() {
        setShow(true);
    }


    function handleShowRegister() {
        setShowRegister(true);
    }

    function handleShowRevenue() {
        handleClose();
        isAuthenticated ? setShowRevenue(true) :
            toast.error("Só é possível adicionar registros quando conectado.");
    }

    function handleShowExpense() {
        handleClose();
        isAuthenticated ? setShowExpense(true) :
            toast.error("Só é possível adicionar registros quando conectado.");
    }

    function handleLogout() {
        localStorage.removeItem("email")
        localStorage.removeItem("name")
        localStorage.removeItem("token")
        localStorage.removeItem("userId")

        logout();

        history.push("/login")
        handleClose();
    }

    function handleContrast() {
        handleTheme();
    }

    return <>
        <SidebarStyle>
            <Row>
                <Col className="column-container">
                    <div className="buttons-profile-separator">
                        <div className="logo-area">
                            <img src="/logo.png" alt="Logotipo My Wallet" className="banner-image" />
                        </div>
                        <hr />
                        <div className="sidebar-logout-separator">
                            <div className="sidebar-nav">
                                <div className="sidebar-nav-item"
                                    aria-label="Ativar alto contraste"
                                    aria-pressed={darkThemeIsActive}
                                    tabIndex={0}
                                    role="button"
                                    onClick={handleContrast}
                                >
                                    <MdContrast />
                                    <span>Contraste</span>
                                </div>
                                <div className="sidebar-nav-item" type="button" onClick={handleShowRevenue}>
                                    <BsPiggyBank />
                                    <span>Adicionar Receita</span>
                                </div>
                                <div className="sidebar-nav-item" type="button" onClick={handleShowExpense}>
                                    <LiaFileInvoiceDollarSolid />
                                    <span>Adicionar Despesa</span>
                                </div>
                                <div className="sidebar-nav-item">
                                    <PiTargetBold />
                                    <span>Definir Meta de Gastos</span>
                                </div>
                            </div>
                            {isAuthenticated &&
                                <div className="logout" role="button" onClick={handleShow}>
                                    <BiLogOut />
                                    <span>Logout</span>
                                </div>
                            }
                        </div>
                        <hr />
                        {isAuthenticated ?
                            <div className="profile">
                                <span className="profile-name">{localStorage.getItem("name")}</span>
                            </div> :
                            <div className="profile" role="button" onClick={handleShowRegister}>
                                <span className="profile-name">Cadastre-se</span>
                            </div>
                        }
                    </div>
                </Col>
            </Row>
        </SidebarStyle >
        <ModalLogout handleClose={handleClose} handleLogout={handleLogout} show={show} />
        <ModalRegisterUser handleClose={handleClose} show={showRegister} />
        <ModalAddRevenue handleClose={handleClose} show={showRevenue} />
        <ModalAddExpense handleClose={handleClose} show={showExpense} />
    </>


}