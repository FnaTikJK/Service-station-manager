import React, {SetStateAction, useState} from 'react';
import {ParseString, RepairDTO} from "./RepairsPage";
import axios from "axios";
import {Button, DatePicker, Input} from "antd";

type Props = {
    initRepair: RepairDTO
}

async function UpdateValues(repair: RepairDTO, setter: any){
    setter("read");
    try {
        await axios.put("/api/Repairs", {
            id: repair.id,
            workerId: repair.worker.id,
            clientId: repair.client.id,
            serviceIds: repair.services.map(s => s.id),
            car: repair.car,
            start: repair.start});
        let response = await axios.get<RepairDTO>(`/api/Repairs/${repair.id}`);
        return response.data;
    }
    catch (e){
        alert(e);
    }
}

async function Archive(id: number, setter: any){
    try {
        await axios.put("/api/Archives", {
            id: 0,
            repairId: id,
            parts: "",
            end: "01.01.0001",
        })
        setter(true);
    }
    catch (e) {
        alert(e);
    }
}

async function Remove(id: number, setter: any){
    try {
        await axios.delete(`/api/Repairs/${id}`)
        setter(true);
    }
    catch (e) {
        alert(e);
    }
}

const RepairsLineComp = ({initRepair}: Props) => {
    const [state, setState] = useState<"read" | "write">("read");
    const [isRemoved, setRemove] = useState<boolean>(false);
    let [repair, setRep] = useState<RepairDTO>(initRepair);
    let dateFormat = "DD.MM.YYYY"
    if (isRemoved)
        return (<></>);

    return (
        <tr>
            <td>{repair.id}</td>
            <td>
                {state === "read" ? `${repair.worker.id} ${repair.worker.secondNameWithInitials}` :
                    <Input placeholder={String(repair.worker.id)} onChange={(e) => {repair.worker.id = Number(e.target.value)}}></Input>}
            </td>
            <td>
                {state === "read" ? `${repair.client.id} ${repair.client.secondNameWithInitials}` :
                    <Input placeholder={String(repair.client.id)} onChange={(e) => {repair.client.id = Number(e.target.value)}}></Input>}
            </td>
            <td>
                {state === "read" ? repair.services.map(s => <>{s.id} {s.name} {s.price}р<br/></>) :
                    <Input placeholder={repair.services.map(s => s.id).join(" ")} onChange={(e) => {repair.services = ParseString(e.target.value)
                        .map((s) => ({id:s, name:"", price:0}))}}></Input>}
            </td>
            <td>
                {state === "read" ? repair.car :
                    <Input placeholder={repair.car} onChange={(e) => {repair.car = e.target.value}}></Input>}
            </td>
            <td>
                {state === "read" ? repair.start :
                    <DatePicker format={dateFormat}
                                onChange={date => date !== null ? repair.start=(date.format(dateFormat)) : date}/>}
            </td>
            <td>
                <Button onClick={() => state === "read" ?
                    setState("write") :
                    UpdateValues(repair, setState).then((v) => Test(v))}>
                    {state === "read" ? "Редактировать" : "Ок"}
                </Button>
            </td>
            <td>
                <Button onClick={() => Archive(repair.id, setRemove)} color={"green"}>
                    В архив
                </Button>
            </td>
            <td>
                <Button onClick={() => Remove(repair.id, setRemove)} color={"red"}>
                    Удалить
                </Button>
            </td>
        </tr>
    );

    function Test(v: RepairDTO | undefined){
        if (v !== undefined){
            console.log(1)
            setRep(v);
        }
    }
};

export default RepairsLineComp;