import { format } from 'date-fns';
import React from "react";
import "./style.css";

import { MdModeEdit } from "react-icons/md";
import { RiDeleteBin6Line } from "react-icons/ri";


export default function RevenueItem({ data, valor, descricao, fonte, handleShowDelete, handleShowEdit }) {
    


    const date = new Date(data)

    return (<>
        <div style={{ width: "100%", height: "4rem" }}>
            <div className="container">
                <div style={{ display: "flex", flexDirection: "column", justifyContent: "space-between", width: "100%" }}>
                    <div style={{ display: "flex", flexDirection: "row", justifyContent: "space-between" }}>
                        <p style={{ fontWeight: "bold", fontSize: "28px" }}>R$ {valor.toLocaleString("pt-br", { style: 'decimal', minimumFractionDigits: 2, maximumFractionDigits: 2 })}</p>
                        <p style={{ fontColor: "var(--font-secondary-color)", fontSize: "20px", marginTop: "8px" }}>{format(date, "dd/MM/yyyy")} </p>
                    </div>
                    <div style={{ display: "flex", flexDirection: "row", justifyContent: "space-between" }}>
                        <p style={{ fontSize: "18px" }}>{descricao}</p>
                        <p style={{ fontColor: "var(--font-secondary-color)", fontSize: "18px" }}>Fonte: {fonte}</p>
                    </div>
                </div>
                <div style={{ width: "1.5rem", marginLeft: "1.5rem", fontSize: "20px", display: "flex", flexDirection: "column", justifyContent: "space-around", height: "120%", marginTop: "-15px" }}>
                    <div className="deleteIcon" role="button" onClick={handleShowDelete}><RiDeleteBin6Line /></div>
                    <div className="editIcon" role="button" onClick={handleShowEdit}><MdModeEdit /></div>
                </div>
            </div>
            <hr />
        </div>
    </>)
}