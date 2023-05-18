import React, {useState} from 'react';
import {Button, DatePicker, Input} from "antd";
import {ClientDTO} from "./ClientsPage";
import axios from "axios";

type Props = {
    client: ClientDTO
}

async function UpdateValues(client: ClientDTO, setter: any){
    setter("read");
    try {
        await axios.put("/api/Workers", {
            id: client.id,
            firstName: client.firstName,
            secondName: client.secondName,
            thirdName: client.thirdName,
            birthDate: client.birthDate});
    }
    catch (e){
        alert(e);
    }
}

const ClientsLineComp = ({client}: Props) => {
    const [state, setState] = useState<"read" | "write">("read");
    let birthDateFormat = "DD.MM.YYYY"

    return (
        <tr>
            <td>{client.id}</td>
            <td>
                {state === "read" ? client.firstName :
                    <Input placeholder={client.firstName} onChange={(e) => {client.firstName = e.target.value}}></Input>}
            </td>
            <td>
                {state === "read" ? client.secondName :
                    <Input placeholder={client.secondName} onChange={(e) => {client.secondName = e.target.value}}></Input>}
            </td>
            <td>
                {state === "read" ? client.thirdName :
                    <Input placeholder={String(client.thirdName)} onChange={(e) => {client.thirdName = e.target.value}}></Input>}
            </td>
            <td>
                {state === "read" ? client.birthDate :
                    <DatePicker format={birthDateFormat}
                                onChange={date => date !== null ? client.birthDate=(date.format(birthDateFormat)) : date}/>}
            </td>
            <td>
                <Button onClick={() => state === "read" ?
                    setState("write") :
                    UpdateValues(client, setState)}>
                    {state === "read" ? "Редактировать" : "Ок"}
                </Button>
            </td>
        </tr>
    );
};

export default ClientsLineComp;