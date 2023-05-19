import React, {useEffect, useState} from 'react';
import axios from "axios";
import ServiceLineComp from "./ServiceLineComp";
import {Button, Input} from "antd";
import "../Styels.css"

export interface ServiceDTO {
    id: number,
    name: string,
    price: number
}

async function GetServices(setter: any){
    try {
        var response = await axios.get<ServiceDTO[]>("/api/Services");
        setter(response.data);
    }
    catch(e) {
        alert(e);
    }
}

async function AddServiceAsync(service: ServiceDTO, setter: any){
    if (service.name !== "" && service.price > 0)
    try {
        await axios.put<ServiceDTO[]>("/api/Services", { id: service.id, name: service.name, price: service.price});
        await GetServices(setter);
    }
    catch(e) {
        alert(e);
    }
}

const HomePage = () => {
    const [services, setServices] = useState<ServiceDTO[] | null>(null);
    const [isAdding, setAdding] = useState<boolean>(false);
    let service: ServiceDTO = { id:0, name:"", price:0 }

    useEffect(() => {
        GetServices(setServices);
    }, [])

    return (
        <div>
            <table className={"table"}>
                <tr>
                    <th>ИД</th>
                    <th>Название</th>
                    <th>Цена</th>
                    <th></th>
                </tr>
                {services?.map((s) =>
                    <ServiceLineComp service={s}/>)}
                {!isAdding ?
                <tr>
                    <td/>
                    <td/>
                    <td/>
                    <Button onClick={() => setAdding(true)}>
                        Добавить
                    </Button>
                </tr>
                :
                <tr>
                    <td></td>
                    <td><Input onChange={(e) => {service.name = e.target.value}}></Input></td>
                    <td><Input onChange={(e) => {service.price = Number(e.target.value)}}></Input></td>
                    <td><Button onClick={() => { AddServiceAsync(service, setServices);setAdding(false); }}>
                        Ок
                    </Button></td>
                </tr>}
            </table>
        </div>
    )
};

export default HomePage;