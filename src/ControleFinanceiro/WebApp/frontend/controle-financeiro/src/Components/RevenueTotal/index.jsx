import React, { useEffect, useState } from "react";
import "./style.css";
import { api } from "../../api/api";
import { MonthInput, MonthPicker } from "react-lite-month-picker";

export default function RevenueTotal() {
    const [receita, setReceita] = useState(0);
    const [selectedMonthData, setSelectedMonthData] = useState({
        month: new Date().getMonth() + 1,
        year: new Date().getFullYear()
    })
    const [isPickerOpen, setIsPickerOpen] = useState(false);


    const getReceita = async () => {

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

        setReceita(response.data.total)
    }

    useEffect(() => {
        getReceita();
    }, [selectedMonthData])

    return (<>
        <div className="globalTotal">
            <div style={{ display: "flex", flexDirection: "column" }}>
                <p style={{ fontSize: "24px" }}>Receita do mês</p>
                <p style={{ fontSize: "40px", fontWeight: "bold" }}>R$ {receita}</p>
            </div>
            <div className="monthpicker">
                <MonthInput
                    selected={selectedMonthData}
                    setShowMonthPicker={setIsPickerOpen}
                    showMonthPicker={isPickerOpen}
                    lang={"pt"}
                    size={"small"}
                    bgColor={"var(--fbackground-color)"}
                    bgColorHover={"var(--cinza-primario)"}
                />
                {isPickerOpen ? (
                    <MonthPicker
                        setIsOpen={setIsPickerOpen}
                        selected={selectedMonthData}
                        onChange={setSelectedMonthData}
                        lang={"pt"}
                        size={"small"}
                        bgColor={"var(--background-color)"}
                        bgColorMonthActive={"var(--cinza-terciario)"}
                        bgColorHover={"var(--cinza-primario)"}
                    />
                ) : null}
            </div>
        </div>
    </>);
}