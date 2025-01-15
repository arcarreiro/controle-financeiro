import React, { useContext, useEffect, useState } from "react";
import "./style.css";
import ExpenseItem from "../ExpenseItem";
import { DateContext } from "../../Context/DateContext";
import { api } from "../../api/api";
import ModalDeleteExpense from "../ModalDeleteExpense";
import ModalEditExpense from "../ModalEditExpense";

export default function ExpensesHistory() {
    const { selectedMonthData, load } = useContext(DateContext);
    const [despesas, setDespesas] = useState([]);
    const [showDelete, setShowDelete] = useState(false);
    const [showEdit, setShowEdit] = useState(false);
    const [modalIndex, setModalIndex] = useState(0);
    const [modalItem, setModalItem] = useState(null);
    

    const handleClose = () => {
        setShowDelete(false);
        setShowEdit(false);
        setModalItem(null)
    }

    const handleShowDelete = (id) => {
        setModalIndex(id)
        handleClose()
        setShowDelete(true)
    }
    const handleModalItem = (id) => {
        setModalItem(id)
    }

    useEffect(() => {
            if (modalItem !== null){
                setShowEdit(true);
            }
        }, [modalItem])


    const getDespesas = async () => {

        const ano = selectedMonthData.year;
        const mes = selectedMonthData.month;
        const usuario = localStorage.getItem('userId')
        const token = localStorage.getItem('token')

        const response = await api.get(`/despesas/mes/${ano}/${mes}/usuario/${usuario}`,
            {
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            }
        )

        setDespesas(response.data.despesas)
    }

    useEffect(() => {
        getDespesas();
    }, [load, selectedMonthData])


    return (<>
        <div className="globalExpensesHistory">
            {despesas.map((item, index) => {
                return (<div style={{ width: "100%", height: "4rem" }} key={index}>
                    <ExpenseItem data={item.data} valor={item.valor} descricao={item.descricao} tipo={item.tipo} 
                    handleShowDelete={() =>{handleShowDelete(item.id)}} handleShowEdit={() => {handleModalItem(item.id)}}/>
                </div>
                )
            })}
            <ModalDeleteExpense handleClose={handleClose} id={modalIndex} show={showDelete}/>
            <ModalEditExpense id={modalItem} handleClose={handleClose} show={showEdit} />
        </div>
    </>);
}