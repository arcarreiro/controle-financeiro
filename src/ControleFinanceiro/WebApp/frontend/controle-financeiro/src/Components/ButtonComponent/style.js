import styled from "styled-components";
import "../../css/colors.css"

export const ButtonStyle = styled.div`
    .botao-default{
        width:${props => props.size} !important;
        background-color: ${props => props.corBg} !important;
        color:${props => props.corTexto} !important;
        border: none !important;
        transition: 0.3s;
        align-self: center;

        &:hover{
            filter: brightness(0.8);
        }
    }
`;