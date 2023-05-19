import React, {useEffect, useState} from 'react';
import {Button, DatePicker, Input} from "antd";
import axios from "axios";
import {ServiceDTO} from "../Home/HomePage";
import WorkersLineComp from "./WorkersLineComp";
import "../Styels.css"

export interface WorkerDTO {
    id: number,
    firstName: string,
    secondName: string,
    thirdName: string,
    birthDate: string
}

async function GetWorkers(setter: any){
    try {
        let response = await axios.get<WorkerDTO[]>("/api/Workers");
        setter(response.data);
    }
    catch(e) {
        alert(e);
    }
}

async function AddWorkerAsync(worker: WorkerDTO, setter: any){
    if (worker.firstName !== "" && worker.secondName !== "")
        try {
            await axios.put<ServiceDTO[]>("/api/Workers", {
                id: worker.id,
                firstName: worker.firstName,
                secondName: worker.secondName,
                thirdName: worker.thirdName,
                birthDate: worker.birthDate});
            await GetWorkers(setter);
        }
        catch(e) {
            alert(e);
        }
}

const WorkersPage = () => {
    const [workers, setWorkers] = useState<WorkerDTO[] | null>(null);
    const [isAdding, setAdding] = useState<boolean>(false);
    let worker: WorkerDTO = { id:0, firstName:"", secondName:"", thirdName:"", birthDate:"01.01.2000" }
    let birthDateFormat = "DD.MM.YYYY"

    useEffect(() => {
        GetWorkers(setWorkers);
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
                    <th></th>
                </tr>
                {workers?.map((w) =>
                    <WorkersLineComp client={w}/>)}
                {!isAdding ?
                    <tr>
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
                        <td><Input onChange={(e) => {worker.firstName = e.target.value}}></Input></td>
                        <td><Input onChange={(e) => {worker.secondName = e.target.value}}></Input></td>
                        <td><Input onChange={(e) => {worker.thirdName = e.target.value}}></Input></td>
                        <td><DatePicker format={birthDateFormat}
                                        onChange={date => date !== null ? worker.birthDate=(date.format(birthDateFormat)) : date}/></td>
                        <td><Button onClick={() => { AddWorkerAsync(worker, setWorkers);setAdding(false); }}>
                            Ок
                        </Button></td>
                    </tr>}
            </table>
        </div>
    );
};

export default WorkersPage;