import React, {useEffect, useState} from 'react';
import axios from "axios";
import {Button, DatePicker, Input} from "antd";
import RepairsLineComp from "./RepairsLineComp";
import "../Styels.css"

export interface PersonShortDTO {
    id: number,
    secondNameWithInitials: string,
}

export interface ServiceShortDTO {
    id: number,
    name: string,
    price: number,
}

export interface RepairDTO {
    id: number,
    worker: PersonShortDTO,
    client: PersonShortDTO,
    services: ServiceShortDTO[],
    car: string,
    start: string,
}

export interface RepairAddDTO {
    id: number,
    workerId: number,
    clientId: number,
    serviceIds: number[],
    car: string,
    start: string,
}

async function AddRepairAsync(repair: RepairAddDTO, setter: any){
    if (repair.workerId !== 0 && repair.car !== "" && repair.start !== "")
        try {
            await axios.put("/api/Repairs", {
                id: repair.id,
                workerId: repair.workerId,
                clientId: repair.clientId,
                serviceIds: repair.serviceIds,
                car: repair.car,
                start: repair.start});
            await GetRepairs(setter);
        }
        catch(e: any) {
            alert(e.message);
        }
}

async function GetRepairs(setter: any){
    try {
        let response = await axios.get<RepairDTO[]>("/api/Repairs");
        setter(response.data);
    }
    catch(e) {
        alert(e);
    }
}

export function ParseString(s: string): number[] {
    return s.split(' ').map(c => Number(c));
}

const RepairsPage = () => {
    const [repairs, setRepairs] = useState<RepairDTO[] | null>(null);
    const [isAdding, setAdding] = useState<boolean>(false);
    let repair: RepairAddDTO = { id:0, workerId: 0, clientId: 0, serviceIds: [], car: "", start: "12.12.2000", }
    let dateFormat = "DD.MM.YYYY"

    useEffect(() => {
        GetRepairs(setRepairs);
    }, [])

    return (
        <div>
            <table className={"table"}>
                <tr>
                    <th>ИД</th>
                    <th>Назначенный рабочий</th>
                    <th>Клиент</th>
                    <th>Услуги</th>
                    <th>Машина</th>
                    <th>Начало работ</th>
                    <th/>
                    <th/>
                    <th/>
                </tr>
                {repairs?.map((r) =>
                    <RepairsLineComp initRepair={r}/>)}
                {!isAdding ?
                    <tr>
                        <td/>
                        <td/>
                        <td/>
                        <td/>
                        <td/>
                        <td/>
                        <td><Button onClick={() => setAdding(true)}>
                            Добавить
                        </Button></td>
                    </tr>
                    :
                    <tr>
                        <td></td>
                        <td><Input onChange={(e) => {repair.workerId = Number(e.target.value)}}></Input></td>
                        <td><Input onChange={(e) => {repair.clientId = Number(e.target.value)}}></Input></td>
                        <td><Input onChange={(e) => {repair.serviceIds = ParseString(e.target.value)}}></Input></td>
                        <td><Input onChange={(e) => {repair.car = e.target.value}}></Input></td>
                        <td><DatePicker format={dateFormat}
                                        onChange={date => date !== null ? repair.start=(date.format(dateFormat)) : date}/></td>
                        <td><Button onClick={() => { AddRepairAsync(repair, setRepairs);setAdding(false); }}>
                            Ок
                        </Button></td>
                    </tr>}
            </table>
        </div>
    );
};

export default RepairsPage;