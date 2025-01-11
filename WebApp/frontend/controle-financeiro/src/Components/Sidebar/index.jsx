import React, { useContext } from "react";
import { ThemeContext } from "../../Context/ThemeContext";
import { SidebarStyle } from "./style";
import { Col, Row } from "react-bootstrap";


export function Sidebar() {

    const { darkThemeIsActive, handleTheme } = useContext(ThemeContext);

    return <>
        <SidebarStyle>
            <Row>
                <Col className="column-container">
                <div className="logo-area">
                {/* Imagem AQUI */}
                </div>
                <hr/>
                <div className="container-botoes">

                </div>

                </Col>
            </Row>
        </SidebarStyle>
    </>


}