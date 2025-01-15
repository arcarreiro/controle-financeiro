import React, { useContext } from "react"
import ButtonComponent from "../ButtonComponent";
import { Modal } from "react-bootstrap";
import { DateContext } from "../../Context/DateContext";
import { api } from "../../api/api";
import { toast } from "react-toastify";

function ModalDeleteRevenue({handleClose, show, id}) {

    const { load, setLoad } = useContext(DateContext)

    const handleDelete = async () => {
        const token = localStorage.getItem('token')
        const response = await api.delete(`/receitas/${id}`,
            {
                headers: {
                "Authorization": `Bearer ${token}`
                }
            }
        )
        if(response) {
            setLoad(!load)
            toast.succes("Registro excluído com sucesso");
            return
        } else {
            toast.error("Não foi possível excluir o registro")
            return
        }

    }

    return (
        <Modal centered show={show} onHide={handleClose}>
            <Modal.Header closeButton>
            </Modal.Header>
            <Modal.Body style={{ fontSize: "20px", textAlign: "center" }}>
                <p tabIndex={0}>Tem certeza que deseja excluir a receita?</p>
            </Modal.Body>
            <Modal.Footer style={{justifyContent: "center"}}>
                <ButtonComponent index={0} action={handleClose} corBg={"var(--cancel-button-color)"} size={"10rem"} corTexto={"var(--branco-primario)"}>
                    Cancelar
                </ButtonComponent>
                <ButtonComponent index={0} action={handleDelete} corBg={"var(--vermelho-perigo)"} size={"10rem"} corTexto={"var(--branco-primario)"}>
                    Excluir
                </ButtonComponent>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalDeleteRevenue;