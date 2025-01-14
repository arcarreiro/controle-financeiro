import { React } from "react";
import Button from "react-bootstrap/Button";

import { ButtonStyle } from "./style";

function ButtonComponent({ size, corBg, corTexto, action, children, disabled, ...props }) {
  return (
    <ButtonStyle size={size} corBg={corBg} corTexto={corTexto} {...props}>
      <Button
      {...props}
        role="button"
        variant={corBg}
        className="botao-default"
        style={{ maxWidth: "100%" }}
        onClick={action}
        disabled={disabled}
      >
        {children}
      </Button>
    </ButtonStyle>
  );
}

export default ButtonComponent;
