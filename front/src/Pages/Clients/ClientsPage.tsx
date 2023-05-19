import React, {useEffect, useState} from 'react';
import axios from "axios";
import {ServiceDTO} from "../Home/HomePage";
import {Button, DatePicker, Input} from "antd";
import ClientsLineComp from "./ClientsLineComp";
import "../Styels.css"

export interface ClientAddDTO {
    id: number,
    firstName: string,
    secondName: string,
    thirdName: string,
    birthDate: string
}

export interface ClientOutDTO {
    id: number,
    firstName: string,
    secondName: string,
    thirdName: string,
    birthDate: string,
    cars: string[]
}

async function AddClientAsync(client: ClientAddDTO, setter: any){
    if (client.firstName !== "" && client.secondName !== "")
        try {
            await axios.put<ServiceDTO[]>("/api/Clients", {
                id: client.id,
                firstName: client.firstName,
                secondName: client.secondName,
                thirdName: client.thirdName,
                birthDate: client.birthDate});
            await GetClients(setter);
        }
        catch(e) {
            alert(e);
        }
}

async function GetClients(setter: any){
    try {
        let response = await axios.get<ClientOutDTO[]>("/api/Clients");
        setter(response.data);
    }
    catch(e) {
        alert(e);
    }
}

const ClientsPage = () => {
    const [clients, setClients] = useState<ClientOutDTO[] | null>(null);
    const [isAdding, setAdding] = useState<boolean>(false);
    let client: ClientAddDTO = { id:0, firstName:"", secondName:"", thirdName:"", birthDate:"01.01.2000" }
    let birthDateFormat = "DD.MM.YYYY"

    useEffect(() => {
        GetClients(setClients);
    }, [])

    return (
        <div>
            <table className={"table"}>
                <tr>
                    <th>ИД</th>
                    <th>Фамилия</th>
                    <th>Имя</th>
                    <th>Отчество</th>
                    <th>Дата рождения</th>
                    <th>Машины</th>
                    <th></th>
                </tr>
                {clients?.map((c) =>
                    <ClientsLineComp initClient={c}/>)}
                {!isAdding ?
                    <tr>
                        <td/>
                        <td/>
                        <td/>
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
                        <td><Input onChange={(e) => {client.firstName = e.target.value}}></Input></td>
                        <td><Input onChange={(e) => {client.secondName = e.target.value}}></Input></td>
                        <td><Input onChange={(e) => {client.thirdName = e.target.value}}></Input></td>
                        <td><DatePicker format={birthDateFormat}
                                        onChange={date => date !== null ? client.birthDate=(date.format(birthDateFormat)) : date}/></td>
                        <td/>
                        <td><Button onClick={() => { AddClientAsync(client, setClients);setAdding(false); }}>
                            Ок
                        </Button></td>
                    </tr>}
            </table>
        </div>
    );
};

export default ClientsPage;