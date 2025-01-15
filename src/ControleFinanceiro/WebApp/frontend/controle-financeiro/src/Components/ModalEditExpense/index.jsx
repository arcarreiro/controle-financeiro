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

function ModalEditExpense({ handleClose, show, id }) {

    const [description, setDescription] = useState(null);
    const [amount, setAmount] = useState(null);
    const [date, setDate] = useState(null);
    const [type, setType] = useState(null);
    const { load, setLoad } = useContext(DateContext)


    const handleAdd = async () => {

        const despesaData = {
            descricao : description,
            valor : amount,
            data: date,
            tipo: type
        };
    
        const cleanData = Object.fromEntries(
            Object.entries(despesaData).filter(([_, value]) => value != null)
        );

        const token = localStorage.getItem('token')
        
        try {

            const response = await api.put(`/despesas/${id}`, cleanData,
            {
                headers: {
                "Authorization": `Bearer ${token}`
                }
            });
            
            toast.success("Despesa alterada com sucesso!")
            setLoad(!load)
            handleClose();
            setAmount(null)
            setDate(null)
            setDescription(null)
            setType(null)
        } catch (e) {
            toast.error("Não foi possível alterar a despesa, tente novamente mais tarde.")
        }
    }

    const handleSelectChange = (event) => {
        switch (event) {
            case "Habitação":
                setType("Habitacao");
            case "Serviços Essenciais":
                setType("ServicosEssenciais");
            case "Transporte":
                setType("Transporte");
            case "Entretenimento":
                setType("Entretenimento");
            case "Compras":
                setType("Compras");
            default:
                setType("Outros");
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
                    <Form.Select
                        placeholder="Tipo de despesa"
                        onChange={handleSelectChange}
                        defaultValue={type}
                    >
                        <option>Habitação</option>
                        <option>Serviços Essenciais</option>
                        <option>Transporte</option>
                        <option>Entretenimento</option>
                        <option>Compras</option>
                        <option>Outros</option>
                    </Form.Select>
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

export default ModalEditExpense;