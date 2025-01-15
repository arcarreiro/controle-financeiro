import React, { useContext } from "react"
import ButtonComponent from "../ButtonComponent";
import { Modal } from "react-bootstrap";
import { DateContext } from "../../Context/DateContext";

function ModalDeleteExpense({handleClose, show, id}) {

    const { load, setLoad } = useContext(DateContext)

    const handleDelete = async () => {
        const token = localStorage.getItem('token')
        const response = await api.delete(`/despesas/${id}`,
            {
                headers: {
                "Authorization": `Bearer ${token}`
                }
            }
        )
        if(response) {
            setLoad(!load)
            toast.succes("Registro excluído com sucesso");
            handleClose()
            return
        } else {
            toast.error("Não foi possível excluir o registro")
            handleClose()
            return
        }

    }

    return (
        <Modal centered show={show} onHide={handleClose}>
            <Modal.Header closeButton>
            </Modal.Header>
            <Modal.Body style={{ fontSize: "20px", textAlign: "center" }}>
                <p tabIndex={0}>Tem certeza que deseja excluir a despesa?</p>
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

export default ModalDeleteExpense;