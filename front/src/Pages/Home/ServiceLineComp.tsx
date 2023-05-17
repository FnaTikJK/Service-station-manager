import React, {useState} from 'react';
import {Button, Input} from "antd";
import {ServiceDTO} from "./HomePage";
import axios from "axios";

type Props = {
    service: ServiceDTO
}

async function UpdateValues(service: ServiceDTO, setter: any){
    setter("read");
    try {
        axios.put("/api/Services", {id: service.id, name: service.name, price: service.price});
    }
    catch (e){
        alert(e);
    }
}

const ServiceLineComp = ({service}: Props) => {
    const [state, setState] = useState<"read" | "write">("read");

    return (
        <tr>
            <td>{service.id}</td>
            <td>
                {state === "read" ? service.name :
                <Input placeholder={service.name} onChange={(e) => {service.name = e.target.value}}></Input>}
            </td>
            <td>
                {state === "read" ? service.price :
                    <Input placeholder={String(service.price)} onChange={(e) => {service.price = Number(e.target.value)}}></Input>}
            </td>
            <td>
                <Button onClick={() => state === "read" ?
                    setState("write") :
                    UpdateValues(service, setState)}>
                    {state === "read" ? "Редактировать" : "Ок"}
                </Button>
            </td>
        </tr>
    );

};

export default ServiceLineComp;