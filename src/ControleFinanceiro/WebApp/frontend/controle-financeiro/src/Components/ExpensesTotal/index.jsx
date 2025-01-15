import React, { useContext, useEffect, useState } from "react";
import "./style.css";
import { DateContext } from "../../Context/DateContext";
import { api } from "../../api/api";

export default function ExpensesTotal() {
    const { selectedMonthData, load } = useContext(DateContext);
    const [despesa, setDespesa] = useState(0);

    const getReceita = async () => {

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

        setDespesa(response.data.total)
    }

    useEffect(() => {
        getReceita();
    }, [selectedMonthData, load])


    return (<>
        <div className="globalExpensesTotal">
            <div style={{ display: "flex", flexDirection: "column" }}>
                <p style={{ fontSize: "24px" }}>Despesas do mês</p>
                <p style={{ fontSize: "40px", fontWeight: "bold" }}>R$ {despesa.toLocaleString("pt-br", { style: 'decimal', minimumFractionDigits: 2, maximumFractionDigits: 2 })}</p>
            </div>
        </div>
    </>);
}