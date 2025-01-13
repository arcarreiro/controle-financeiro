import styled from "styled-components";

export const PageContainerStyle = styled.div`
     

    width: 85.5vw;
    height: 100vh;
    margin-left: 16.5vw;
    padding: 1rem;
    background-color: var(--background-color);
    box-shadow: 1px 1px 5px var(--preto-primario);
    overflow: hidden;
    color: var(--font-color);

    @media(max-width: 991px)  {
        margin: 0;
        margin-top: 2rem;
        align-self: center;
    }
`;