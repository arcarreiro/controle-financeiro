import React from "react";
import "./style.css";
import { format } from 'date-fns';

import { RiDeleteBin6Line } from "react-icons/ri";
import { MdModeEdit } from "react-icons/md";

import { FaHome } from "react-icons/fa"; //habitação
import { SiPaperswithcode } from "react-icons/si"; //serviços essenciais
import { FaCar } from "react-icons/fa"; //tranporte
import { GiFilmProjector } from "react-icons/gi"; //entretenimento
import { TiShoppingCart } from "react-icons/ti"; //compras
import { LuLayoutDashboard } from "react-icons/lu"; //outros
//mover para despesas


export default function ExpenseItem({data, valor, descricao, tipo, idUsuario}) {
    
    const date = new Date(data)

    const getIconByType = (type) => {
        switch (type) {
            case 'Habitacao':
                return <FaHome title="Habitação"/>;
            case 'ServicosEssenciais':
                return <SiPaperswithcode title="Serviços Esenciais"/>;
            case 'Transporte':
                return <FaCar title="Transporte"/>;
            case 'Entretenimento':
                return <GiFilmProjector title="Entretenimento"/>;
            case 'Compras':
                return <TiShoppingCart title="Compras"/>;
            default:
                return <LuLayoutDashboard title="Outros"/>;
        }
    };

    const getType = (type) => {
        switch (type) {
            case 'Habitacao':
                return "Habitação";
            case 'ServicosEssenciais':
                return "Serviços Esenciais";
            case 'Transporte':
                return "Transporte";
            case 'Entretenimento':
                return "Entretenimento";
            case 'Compras':
                return "Compras";
            default:
                return "Outros";
        }
    };

    return (<>
    <div style={{ width: "100%"}}>
        <div className="container">
            <div style={{backgroundColor: "var(--header-card)", color: "var(--cinza-secundario)", width: "3rem", height: "3rem", fontSize: "2rem", display: "flex", alignItems: "center", justifyContent: "center", marginRight: "1rem", borderRadius: "10px"}}>
                {getIconByType(tipo)}
            </div>
            <div style={{display: "flex", flexDirection: "column", justifyContent: "space-between", width: "100%"}}>
                <div style={{ display: "flex", flexDirection: "row", justifyContent: "space-between" }}>
                    <p style={{fontWeight: "bold", fontSize: "28px"}}>R$ {valor.toLocaleString("pt-br", {style: 'decimal', minimumFractionDigits: 2, maximumFractionDigits: 2})}</p>
                    <p style={{fontColor: "var(--font-secondary-color)", fontSize: "20px", marginTop: "8px"}}>{format(date, "dd/MM/yyyy")} </p>
                </div>
                <div style={{ display: "flex", flexDirection: "row", justifyContent: "space-between"}}>
                    <p style={{fontSize: "18px"}}>{descricao}</p>
                    <p style={{fontColor: "var(--font-secondary-color)", fontSize: "18px"}}>{getType(tipo)}</p>
                </div>
            </div>
            <div style={{width: "1.5rem", marginLeft: "1.5rem", fontSize: "20px", display: "flex", flexDirection: "column", justifyContent: "space-around", height: "120%", marginTop: "-15px"}}>
                <div className = "deleteIcon"><RiDeleteBin6Line/></div>
                <div className = "editIcon"><MdModeEdit/></div>
            </div>
        </div>
        <hr />
        </div>
    </>)
}