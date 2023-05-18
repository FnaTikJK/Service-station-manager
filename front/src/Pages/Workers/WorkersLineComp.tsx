import React, {useState} from 'react';
import {WorkerDTO} from "./WorkersPage";
import axios from "axios";
import {Button, DatePicker, Input} from "antd";

type Props = {
    worker: WorkerDTO
}

async function UpdateValues(worker: WorkerDTO, setter: any){
    setter("read");
    try {
        axios.put("/api/Workers", {
            id: worker.id,
            firstName: worker.firstName,
            secondName: worker.secondName,
            thirdName: worker.thirdName,
            birthDate: worker.birthDate});
    }
    catch (e){
        alert(e);
    }
}

const WorkersLineComp = ({worker}: Props) => {
    const [state, setState] = useState<"read" | "write">("read");
    let birthDateFormat = "DD.MM.YYYY"

    return (
        <tr>
            <td>{worker.id}</td>
            <td>
                {state === "read" ? worker.firstName :
                    <Input placeholder={worker.firstName} onChange={(e) => {worker.firstName = e.target.value}}></Input>}
            </td>
            <td>
                {state === "read" ? worker.secondName :
                    <Input placeholder={worker.secondName} onChange={(e) => {worker.secondName = e.target.value}}></Input>}
            </td>
            <td>
                {state === "read" ? worker.thirdName :
                    <Input placeholder={String(worker.thirdName)} onChange={(e) => {worker.thirdName = e.target.value}}></Input>}
            </td>
            <td>
                {state === "read" ? worker.birthDate :
                    <DatePicker format={birthDateFormat}
                                onChange={date => date !== null ? worker.birthDate=(date.format(birthDateFormat)) : date}/>}
            </td>
            <td>
                <Button onClick={() => state === "read" ?
                    setState("write") :
                    UpdateValues(worker, setState)}>
                    {state === "read" ? "Редактировать" : "Ок"}
                </Button>
            </td>
        </tr>
    );
};

export default WorkersLineComp;