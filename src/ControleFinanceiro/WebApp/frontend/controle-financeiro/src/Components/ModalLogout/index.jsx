import React from "react"
import ButtonComponent from "../ButtonComponent";
import { Modal } from "react-bootstrap";

function ModalLogout({handleClose, handleLogout, show}) {

    return (
        <Modal centered show={show} onHide={handleClose}>
            <Modal.Header closeButton>
            </Modal.Header>
            <Modal.Body style={{ fontSize: "20px", textAlign: "center" }}>
                <p tabIndex={0}>Tem certeza que deseja sair?</p>
            </Modal.Body>
            <Modal.Footer style={{justifyContent: "center"}}>
                <ButtonComponent index={0} action={handleClose} corBg={"var(--cancel-button-color)"} size={"10rem"} corTexto={"var(--branco-primario)"}>
                    Cancelar
                </ButtonComponent>
                <ButtonComponent index={0} action={handleLogout} corBg={"var(--vermelho-perigo)"} size={"10rem"} corTexto={"var(--branco-primario)"}>
                    Sair
                </ButtonComponent>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalLogout;