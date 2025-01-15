import React, { createContext, useState } from "react";


const DateContext = createContext();

const DateProvider = ({ children }) => {
    const [selectedMonthData, setSelectedMonthData] = useState({
        month: new Date().getMonth() + 1,
        year: new Date().getFullYear()
    });
    const [load, setLoad] = useState(false);

    
    return (
        <>
            <DateContext.Provider value={{
                selectedMonthData, setSelectedMonthData, load, setLoad
            }}>
                {children}
            </DateContext.Provider>
        </>
    )
}

export { DateContext, DateProvider }