import React, { useContext, useEffect, useState } from "react";
import "./style.css";
import RevenueItem from "../RevenueItem";
import { DateContext } from "../../Context/DateContext";
import { api } from "../../api/api";
import ModalDeleteRevenue from "../ModalDeleteRevenue";

export default function RevenueHistory() {
    const { selectedMonthData, load } = useContext(DateContext);
    const [receitas, setReceitas] = useState([]);
    const [showDelete, setShowDelete] = useState(false);
    const [showEdit, setShowEdit] = useState(false);
    const [modalIndex, setModalIndex] = useState(0);

    const handleClose = () => {
        setShowDelete(false);
    }

    const handleShowDelete = (id) => {
        setModalIndex(id)
        handleClose()
        setShowDelete(true)
    }
    const handleShowEdit = () => {
        handleClose()
        setShowEdit(true)
    }


    const getReceitas = async () => {

        const ano = selectedMonthData.year;
        const mes = selectedMonthData.month;
        const usuario = localStorage.getItem('userId')
        const token = localStorage.getItem('token')

        const response = await api.get(`/receitas/mes/${ano}/${mes}/usuario/${usuario}`,
            {
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            }
        )

        setReceitas(response.data.receitas)
    }

    useEffect(() => {
        getReceitas();
    }, [load, selectedMonthData])

    return (<>
        <div className="globalRevenueHistory">
            {receitas.map((item, index) => {
                return (<div style={{width: "100%", height: "4rem"}} key={index}>
                    <RevenueItem data={item.data} valor={item.valor} descricao={item.descricao} fonte={item.fonte}
                    handleShowDelete={handleShowDelete} handleShowEdit={handleShowEdit}/>
                </div>
                )
            })}
            <ModalDeleteRevenue handleClose={handleClose} id={modalIndex} show={showDelete}/>
        </div>
    </>);
}