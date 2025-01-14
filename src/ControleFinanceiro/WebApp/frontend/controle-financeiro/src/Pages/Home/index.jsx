import React from "react";
import './home.css';
import PageContainer from "../../Components/PageContainer";
import RevenueTotal from "../../Components/RevenueTotal";
import RevenueHistory from "../../Components/RevenueHistory";
import ExpensesTotal from "../../Components/ExpensesTotal";
import ExpensesHistory from "../../Components/ExpensesHistory";

export default function Home() {


    return (<>
        <PageContainer>
            <div className="global">
                <div className='revenue'>
                    <div className="monthTotal">
                        <RevenueTotal/>
                    </div>
                    <div className="revenueHistory">
                        <RevenueHistory/>
                    </div>
                </div>
                <div className='expenses'>
                    <div className="monthTotal">
                        <ExpensesTotal/>
                    </div>
                    <div className="revenueHistory">
                        <ExpensesHistory/>
                    </div>
                </div>
            </div>

        </PageContainer>
    </>);
}