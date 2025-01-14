import styled from "styled-components";
import "../../css/colors.css";

export const SidebarStyle = styled.div`
font-size: 100%;
  margin: 0 !important;
  width: 16.5vw;
  height: 100vh;
  padding: 1rem;
  background-color: var(--fundo-sidebar);
  position: fixed;
  z-index: 9999;
  transition: 0.3s;
  overflow: hidden;

  .banner-image {
  width: 80%;
  margin-left: 10%;
  margin-top: 1rem;
}

hr {
  color: var(--cinza-terciario);
}

.buttons-profile-separator{
  height: 95vh;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.sidebar-logout-separator {
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.sidebar-nav {
  display: flex;
  flex-direction: column;
  padding: 1rem;
}

.sidebar-nav-item {
  color: var(--cinza-terciario);
  height: 3.2rem;
  font-size: 1.2rem;
  display: flex;
  gap: 1.2rem;
  align-items: center;
  svg {
        font-size: 24px;
      }

      &:hover {
        cursor: pointer;
        background-color: var(--cinza-secundario);
      }
}

.logout {
  color: var(--cinza-terciario);
  padding-right: 1rem;
  height: 3.2rem;
  font-size: 1.2rem;
  display: flex;
  justify-content: flex-end;
  gap: 1.2rem;
  align-items: center;
  svg {
        font-size: 24px;
      }

      &:hover {
        cursor: pointer;
        background-color: var(--cinza-secundario);
      }
}

.profile {
  padding-right: 1rem;
  align-items: flex-end;
  font-size: 1.2rem;
  color: var(--cinza-terciario);
  display: flex;
  flex-direction: column;
}

.profile-option {
  font-size: 0.9rem;
  color: var(--cinza-secundario);

}

`