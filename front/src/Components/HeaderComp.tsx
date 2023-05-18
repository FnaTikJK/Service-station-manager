import React from 'react';
import {Outlet, useNavigate} from 'react-router-dom'
import {Radio} from "antd";

const HeaderComp = () => {
    const navigate = useNavigate();

    return (
        <>
            <header>
                <Radio.Group defaultValue={"a"}>
                    <Radio.Button value={"a"} onClick={() => navigate("/")}>Услуги</Radio.Button>
                    <Radio.Button value={"b"} onClick={() => navigate("/Workers")}>Работники</Radio.Button>
                    <Radio.Button value={"c"} onClick={() => navigate("/Clients")}>Клиенты</Radio.Button>
                    <Radio.Button value={"f"} onClick={() => navigate("/Repairs")}>В ремонте</Radio.Button>
                    <Radio.Button value={"g"} onClick={() => navigate("/Archive")}>Архив</Radio.Button>
                </Radio.Group>
            </header>
            <Outlet />
        </>
    );
};

export default HeaderComp;