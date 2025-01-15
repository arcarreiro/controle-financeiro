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

function ModalEditRevenue({ handleClose, show, revenue }) {

    const [description, setDescription] = useState(null);
    const [amount, setAmount] = useState(null);
    const [date, setDate] = useState(null);
    const [source, setSource] = useState(null);
    const { load, setLoad } = useContext(DateContext)

    const handleAdd = async () => {
        const token = localStorage.getItem('token')
        const id = revenue.id
        try {

            const response = await api.put(`/receitas/${id}`, {
                descricao: descricao,
                valor: valor,
                data: new Date(date),
                fonte: fonte,
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
            toast.error("Não foi possível alterar a receita, tente novamente mais tarde.")
        }
    }

    return (
        <Modal centered show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Alterar Receita</Modal.Title>
            </Modal.Header>
            <Modal.Body style={{ fontSize: "20px"}}>
                <div style={{marginBottom: "1rem"}}>
                <DatePicker selected={date} onChange={(e) => setDate(e)} locale={ptBR}/>
                </div>
                <InputGroup className="mb-3">
                    <Form.Control
                        type="number"
                        placeholder="Valor"
                        onChange={(e) => { setAmount(e.target.value) }}
                        defaultValue={amount}
                    />
                </InputGroup>
                <InputGroup className="mb-3">
                    <Form.Control
                        type={"text"}
                        placeholder="Fonte"
                        onChange={(e) => { setSource(e.target.value) }}
                        defaultValue={source}
                    />
                </InputGroup>
                <InputGroup className="mb-3">
                    <Form.Control
                        type={"text"}
                        placeholder="Descrição"
                        value={description}
                        onChange={(e) => { setDescription(e.target.value) }}
                    />
                </InputGroup>
                <p style={{color: "var(--vermelho-perigo)", fontSize: "14px"}}>*Edite apenas os campos que deseja alterar!</p>
            </Modal.Body>
            <Modal.Footer style={{ justifyContent: "center" }}>
                <ButtonComponent index={0} action={handleAdd} corBg={"var(--button-color)"} size={"10rem"} corTexto={"var(--branco-primario)"}>
                    Alterar
                </ButtonComponent>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalEditRevenue;