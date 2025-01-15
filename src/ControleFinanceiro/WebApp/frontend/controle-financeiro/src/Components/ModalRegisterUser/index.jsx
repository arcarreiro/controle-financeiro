import React, { useState } from "react"
import ButtonComponent from "../ButtonComponent";
import { Form, InputGroup, Modal } from "react-bootstrap";
import { api } from "../../api/api";
import { toast } from "react-toastify";

function ModalRegisterUser({ handleClose, show }) {

    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleRegister = async () => {
        try {

            const response = await api.post('/usuarios', {
                nome: name,
                email: email,
                senha: password
            });
            toast.success("Damos a você as boas vindas " + response.data.nome + "! Faça login com suas credenciais.")
            handleClose();
        } catch (e) {
            toast.error(e.status || "Não foi possível realizar o cadastro, tente novamente mais tarde.")
        }
    }

    return (
        <Modal centered show={show} onHide={handleClose}>
            <Modal.Header closeButton>
            </Modal.Header>
            <Modal.Body style={{ fontSize: "20px", textAlign: "center" }}>
                <InputGroup className="mb-3">
                    <Form.Control
                        type="text"
                        placeholder="Digite seu nome"
                        onChange={(e) => { setName(e.target.value) }}
                        defaultValue={name}
                    />
                </InputGroup>
                <InputGroup className="mb-3">
                    <Form.Control
                        type="email"
                        placeholder="Digite seu e-mail"
                        onChange={(e) => { setEmail(e.target.value) }}
                        defaultValue={email}
                    />
                </InputGroup>
                <InputGroup className="mb-3">
                    <Form.Control
                        type={"text"}
                        placeholder="Digite sua senha"
                        onChange={(e) => { setPassword(e.target.value) }}
                        defaultValue={password}
                    />
                </InputGroup>
            </Modal.Body>
            <Modal.Footer style={{ justifyContent: "center" }}>
                <ButtonComponent index={0} action={handleRegister} corBg={"var(--button-color)"} size={"10rem"} corTexto={"var(--branco-primario)"}>
                    Cadastrar
                </ButtonComponent>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalRegisterUser;