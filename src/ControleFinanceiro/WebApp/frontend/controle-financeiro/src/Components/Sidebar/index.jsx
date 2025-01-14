import React, { useContext } from "react";
import { ThemeContext } from "../../Context/ThemeContext";
import { SidebarStyle } from "./style";
import { Col, Row } from "react-bootstrap";

import { MdContrast } from "react-icons/md";
import { HiOutlineSquares2X2 } from "react-icons/hi2";
import { GiTakeMyMoney } from "react-icons/gi";
import { BsPiggyBank } from "react-icons/bs";
import { LiaFileInvoiceDollarSolid } from "react-icons/lia";
import { PiTargetBold } from "react-icons/pi";
import { BiLogOut } from "react-icons/bi";



export function Sidebar() {

    const { darkThemeIsActive, handleTheme } = useContext(ThemeContext);

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

                                <div className="sidebar-nav-item">
                                    <HiOutlineSquares2X2 />
                                    <span>Visão Geral</span>
                                </div>
                                <div className="sidebar-nav-item">
                                    <BsPiggyBank />
                                    <span>Receitas</span>
                                </div>
                                <div className="sidebar-nav-item">
                                    <LiaFileInvoiceDollarSolid />
                                    <span>Despesas</span>
                                </div>
                                <div className="sidebar-nav-item">
                                    <PiTargetBold />
                                    <span>Metas</span>
                                </div>
                            </div>
                            <div className="logout">
                                <BiLogOut />
                                <span>Logout</span>
                            </div>
                        </div>
                        <hr />
                        <div className="profile">
                            <span className="profile-name">Arthur</span>
                            <span className="profile-option">Ver Perfil</span>
                        </div>
                    </div>
                </Col>
            </Row>
        </SidebarStyle >
    </>


}