import { createContext, useEffect, useState } from "react";
import "../css/colors.css"

export const ThemeContext = createContext(null);

export function ThemeContextProvider({ children }) {
    const [darkThemeIsActive, setDarkThemeIsActive] = useState(false);

    function handleTheme() {
        setDarkThemeIsActive(!darkThemeIsActive);
        localStorage.setItem("theme", JSON.stringify(!darkThemeIsActive));
    }

    useEffect(() => {
        let value = JSON.parse(localStorage.getItem("theme"));
        if (value === undefined) return;
        setDarkThemeIsActive(value);
    }, []);

    useEffect(() => {
        if (!darkThemeIsActive) {
            document.documentElement.style.setProperty(
                "--font-color",
                "var(--fonte)"
            );
            document.documentElement.style.setProperty(
                "--font-secondary-color",
                "var(--fonte-secundaria)"
            );
            document.documentElement.style.setProperty(
                "--background-color",
                "var(--fundo)"
            );
            document.documentElement.style.setProperty(
                "--icon-color",
                "var(--icone)"
            );
            document.documentElement.style.setProperty(
                "--card-header-color",
                "var(--header-card)"
            );
            document.documentElement.style.setProperty(
                "--button-color",
                "var(--verde-primario)"
            );
        } else {
            document.documentElement.style.setProperty(
                "--font-color",
                "var(--fonte-contraste)"
            );
            document.documentElement.style.setProperty(
                "--font-secondary-color",
                "var(--fonte-secundaria-contraste)"
            );
            document.documentElement.style.setProperty(
                "--background-color",
                "var(--fundo-contraste)"
            );
            document.documentElement.style.setProperty(
                "--icon-color",
                "var(--icone-contraste)"
            );
            document.documentElement.style.setProperty(
                "--card-header-color",
                "var(--header-card-constraste)"
            );
            document.documentElement.style.setProperty(
                "--button-color",
                "var(--preto-primario)"
            );
        }
    }, [darkThemeIsActive]);

    return (
        <ThemeContext.Provider value={{ darkThemeIsActive, handleTheme }}>
            {children}
        </ThemeContext.Provider>
    );
}