import React, {useState} from 'react';
import {Button, DatePicker, Input} from "antd";
import {ClientAddDTO, ClientOutDTO} from "./ClientsPage";
import axios from "axios";

type Props = {
    initClient: ClientOutDTO
}

async function UpdateValues(client: ClientOutDTO, setter: any, clientSetter: any){
    setter("read");
    try {
        await axios.put("/api/Clients", {
            id: client.id,
            firstName: client.firstName,
            secondName: client.secondName,
            thirdName: client.thirdName,
            birthDate: client.birthDate});
        var response = await axios.get<ClientOutDTO>(`/api/Clients/${client.id}`)
        clientSetter(response.data);
    }
    catch (e){
        alert(e);
    }
}

async function RemoveAsync(id: number, setter: any){
    try {
        await axios.delete(`/api/Clients/${id}`);
        setter(true);
    }
    catch (e) {
        alert(e);
    }
}

const ClientsLineComp = ({initClient}: Props) => {
    const [state, setState] = useState<"read" | "write">("read");
    const [isRemoved, setIsRemoved] = useState<boolean>(false);
    let [client, setClient] = useState<ClientOutDTO>(initClient);
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
            <td>{client.cars.map(c => <>{c}<br/></>)}</td>
            <td>
                <Button onClick={() => state === "read" ?
                    setState("write") :
                    UpdateValues(client, setState, setClient)}>
                    {state === "read" ? "Редактировать" : "Ок"}
                </Button>
            </td>
        </tr>
    );
};

export default ClientsLineComp;