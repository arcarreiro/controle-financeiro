import React from "react";
import './revenue.css'
import PageContainer from "../../Components/PageContainer";
import MonthRevenueChart from "../../Components/Charts/MonthRevenueChart";

export default function Revenue() {

    const domContainer = document.querySelector('#app');

    return (<>
        <PageContainer>
            <div>
                <MonthRevenueChart />
                {ReactDOM.render(<MonthRevenueChart />, domContainer)}
            </div>

            <button>adicionar receita</button>
            <modal>adicional receita</modal>

        </PageContainer>
    </>);
}