import React, { useContext, useEffect, useState } from "react";
import './login.css'
import PageContainer from "../../Components/PageContainer";
import { Form, InputGroup } from "react-bootstrap";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { useAuth } from "../../Context/AuthContext";

import { BsEye, BsEyeSlash } from "react-icons/bs";
import { HiOutlineLockClosed } from "react-icons/hi";
import ButtonComponent from "../../Components/ButtonComponent";
import { ThemeContext } from "../../Context/ThemeContext";
import { toast } from "react-toastify";
import { api } from "../../api/api";
import axios from "axios";

export default function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [showPassword, setShowPassword] = useState(false);
    const { darkThemeIsActive } = useContext(ThemeContext);
    const history = useHistory();
    const { login } = useAuth();


    const handleTest = () => {
        toast.warning("Funciona");
    }

    const handleLogin = async (e) => {

        if (!email || !password) {
            toast.warning("Por favor, preencha todos os campos.")
            return;
        }

        try {
            const response = await api.post('/auth/login', {
            email: email,
            password: password
            });

            if (response.status >= 200 && response.status < 300) {
                const data = await response.data;

                localStorage.setItem("email", data.token.email)
                localStorage.setItem("token", data.token.token)
                localStorage.setItem("userId", data.token.usuarioId)
                localStorage.setItem("name", data.token.nome)


                login()
                history.push("/home");
                toast.success("Login realizado com sucesso")
            } else {
                const errorMessage = await response.data;

                toast.error(errorMessage || "Usuário ou senha incorretos, tente novamente.")
            }
        } catch (err) {
            toast.error("Erro de conexão.", err);
        }
    };

    const handlePasswordToggle = () => {
        setShowPassword(!showPassword);
    };

    const handlePasswordButton = (
        <button type="button" onClick={handlePasswordToggle} className="eyeButton">
            {showPassword ? (
                <BsEye />
            ) : (
                <BsEyeSlash />
            )}
        </button>
    )

    const handleKeyDown = (event) => {
        if (event.key === "Enter") {
            handleLogin();
        }
    };


    return (<>
        <PageContainer>
            <div className="content-container">
                <div className="container-login">
                    <div className="logoArea">
                        {darkThemeIsActive ? <img src="/logo.png" /> : <img src="/logoEscura.png" />}
                        <span>O controle na sua mão.</span>
                    </div>
                    <div style={{ display: "flex", flexDirection: "column", gap: "10px" }} > {/*onSubmit={handleLogin}*/}
                        <InputGroup className="mb-3">
                            <InputGroup.Text id="basic-addon1">@</InputGroup.Text>
                            <Form.Control
                                type="email"
                                placeholder="Digite seu e-mail"
                                onChange={(e) => { setEmail(e.target.value) }}
                                defaultValue={email}
                                onKeyDown={handleKeyDown}
                            />
                        </InputGroup>
                        <InputGroup className="mb-3">
                            <InputGroup.Text id="basic-addon3"><HiOutlineLockClosed /></InputGroup.Text>
                            <Form.Control
                                type={showPassword ? "text" : "password"}
                                placeholder="Digite sua senha"
                                onChange={(e) => { setPassword(e.target.value) }}
                                defaultValue={password}
                                onKeyDown={handleKeyDown}
                            />
                            <InputGroup.Text id="basic-addon5">{handlePasswordButton}</InputGroup.Text>
                        </InputGroup>
                        <ButtonComponent size={"18rem"} corBg={"var(--button-color)"} corTexto={"#fff"} action={handleLogin}
                        >Entrar</ButtonComponent>
                    </div>
                </div>
            </div>
        </PageContainer>
    </>);
}