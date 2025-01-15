import React, { useContext, useState } from "react"
import ButtonComponent from "../ButtonComponent";
import { Form, InputGroup, Modal } from "react-bootstrap";
import { api } from "../../api/api";
import { toast } from "react-toastify";
import DatePicker from "react-datepicker";
import { ptBR } from "date-fns/locale";
import { DateContext } from "../../Context/DateContext";
import './style.css'

function ModalAddExpense({ handleClose, show }) {

    const [descricao, setDescricao] = useState("");
    const [valor, setValor] = useState("");
    const [date, setDate] = useState(new Date().now);
    const [tipo, setTipo] = useState("");
    const { load, setLoad } = useContext(DateContext)

    const handleAdd = async () => {
        const token = localStorage.getItem('token')
        try {

            const response = await api.post('/despesas', {
                descricao: descricao,
                valor: valor,
                data: new Date(date),
                tipo: tipo,
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

    const handleSelectChange = (event) => {
        switch (event) {
            case "Habitação":
                setTipo("Habitacao");
            case "Serviços Essenciais":
                setTipo("ServicosEssenciais");
            case "Transporte":
                setTipo("Transporte");
            case "Entretenimento":
                setTipo("Entretenimento");
            case "Compras":
                setTipo("Compras");
            default:
                setTipo("Outros");
        }
    }

    return (
        <Modal centered show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title style={{textAlign: "center"}}>Adicionar Despesa</Modal.Title>
            </Modal.Header>
            <Modal.Body style={{ fontSize: "20px"}}>
                <div style={{marginBottom: "1rem"}}>
                <DatePicker selected={date} onChange={(e) => setDate(e)} locale={ptBR}/>
                </div>
                <InputGroup className="mb-3">
                    <Form.Control
                        type="number"
                        placeholder="Valor da despesa"
                        onChange={(e) => { setValor(e.target.value) }}
                        defaultValue={valor}
                    />
                </InputGroup>
                <InputGroup className="mb-3">
                    <Form.Control
                        type="text"
                        placeholder="Digite uma descrição para a despesa"
                        onChange={(e) => { setDescricao(e.target.value) }}
                        defaultValue={descricao}
                    />
                </InputGroup>
                <InputGroup className="mb-3">
                    <Form.Select
                        placeholder="Tipo de despesa"
                        onChange={handleSelectChange}
                        defaultValue={tipo}
                    >
                        <option>Habitação</option>
                        <option>Serviços Essenciais</option>
                        <option>Transporte</option>
                        <option>Entretenimento</option>
                        <option>Compras</option>
                        <option>Outros</option>
                    </Form.Select>
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

export default ModalAddExpense;