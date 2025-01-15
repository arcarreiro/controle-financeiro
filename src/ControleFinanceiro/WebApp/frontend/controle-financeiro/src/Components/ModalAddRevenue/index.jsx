import React, { useContext, useState } from "react"
import ButtonComponent from "../ButtonComponent";
import { Form, InputGroup, Modal } from "react-bootstrap";
import { api } from "../../api/api";
import { toast } from "react-toastify";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "./style.css"
import { ptBR } from "date-fns/locale";
import { DateContext } from "../../Context/DateContext";

function ModalAddRevenue({ handleClose, show }) {

    const [descricao, setDescricao] = useState("");
    const [valor, setValor] = useState("");
    const [date, setDate] = useState(new Date().now);
    const [fonte, setFonte] = useState("");
    const { load, setLoad } = useContext(DateContext)

    const handleAdd = async () => {
        const token = localStorage.getItem('token')
        try {

            const response = await api.post('/receitas', {
                descricao: descricao,
                valor: valor,
                data: new Date(date),
                fonte: fonte,
                idUsuario: localStorage.getItem("userId")
            },
            {
                headers: {
                "Authorization": `Bearer ${token}`
                }
            });
            
            toast.success("Receita adicionada com sucesso!")
            setLoad(!load)
            handleClose();
        } catch (e) {
            toast.error(e.status + "Não foi possível adicionar a receita, tente novamente mais tarde.")
        }
    }

    return (
        <Modal centered show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Adicionar Receita</Modal.Title>
            </Modal.Header>
            <Modal.Body style={{ fontSize: "20px"}}>
                <div style={{marginBottom: "1rem"}}>
                <DatePicker selected={date} onChange={(e) => setDate(e)} locale={ptBR}/>
                </div>
                <InputGroup className="mb-3">
                    <Form.Control
                        type="number"
                        placeholder="Valor da receita"
                        onChange={(e) => { setValor(e.target.value) }}
                        defaultValue={valor}
                    />
                </InputGroup>
                <InputGroup className="mb-3">
                    <Form.Control
                        type={"text"}
                        placeholder="Fonte pagadora"
                        onChange={(e) => { setFonte(e.target.value) }}
                        defaultValue={fonte}
                    />
                </InputGroup>
                <InputGroup className="mb-3">
                    <Form.Control
                        type={"text"}
                        placeholder="Digite uma descrição para a receita"
                        onChange={(e) => { setDescricao(e.target.value) }}
                        defaultValue={descricao}
                    />
                </InputGroup>

            </Modal.Body>
            <Modal.Footer style={{ justifyContent: "center" }}>
                <ButtonComponent index={0} action={handleAdd} corBg={"var(--button-color)"} size={"10rem"} corTexto={"var(--branco-primario)"}>
                    Cadastrar
                </ButtonComponent>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalAddRevenue;