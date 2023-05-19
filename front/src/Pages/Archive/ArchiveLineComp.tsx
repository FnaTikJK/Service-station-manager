import React, {useState} from 'react';
import {ArchiveDTO} from "./ArchivePage";
import {Button, DatePicker, Input} from "antd";
import {RepairDTO} from "../Repairs/RepairsPage";
import axios from "axios";

type Props = {
    initArchive: ArchiveDTO
}

async function UpdateValues(archive: ArchiveDTO, setter: any, archiveSetter: any){
    setter(false);
    try {
        await axios.put("/api/Archives", {
            id: archive.id,
            repairId: archive.repair.id,
            parts: archive.parts,
            end: archive.end});
        let response = await axios.get<RepairDTO>(`/api/Archives/${archive.id}`);
        archiveSetter(response.data);
    }
    catch (e){
        alert(e);
    }
}

async function Remove(id: number, setter: any){
    try {
        await axios.delete(`/api/Archives/${id}`)
        setter(true);
    }
    catch (e) {
        alert(e);
    }
}

const ArchiveLineComp = ({initArchive}: Props) => {
    const [isRemoved, setRemoved] = useState<boolean>(false);
    const [state, setState] = useState<boolean>(false);
    let [archive, setArchive] = useState<ArchiveDTO>(initArchive);
    let dateFormat = "DD.MM.YYYY"

    if (isRemoved)
        return (<></>);

    return (
        <tr>
            <td>{archive.id}</td>
            <td>{archive.repair.worker.id} {archive.repair.worker.secondNameWithInitials}</td>
            <td>{archive.repair.client.id} {archive.repair.client.secondNameWithInitials}</td>
            <td>{archive.repair.services.map(s => <>{s.id} {s.name} {s.price}р<br/></>)}</td>
            <td>{!state ? (archive.parts === "" ? "" : archive.parts.split(", ").map((p) => <>{p}р<br/></>)) :
                <Input placeholder={archive.parts} onChange={(e) => {archive.parts = e.target.value}}></Input>}</td>
            <td>{archive.repair.car}</td>
            <td>{archive.repair.start}</td>
            <td>{!state ? archive.end
                : <DatePicker format={dateFormat}
                              onChange={date => date !== null ? archive.end=(date.format(dateFormat)) : date}/>}</td>
            <td>
                {archive.repair.services.map(s => s.price).reduce((total, value) => total + value)
                    + (archive.parts === "" ?
                    0 :
                    archive.parts.split(", ").map(p => Number(p.split(" ")[1])).reduce((total, value) => total+value))}
            </td>
            <td>
                <Button onClick={() => !state ?
                    setState(true) :
                    UpdateValues(archive, setState, setArchive)}>
                    {!state ? "Редактировать" : "Ок"}
                </Button>
            </td>
            <td>
                <Button onClick={() => Remove(archive.id, setRemoved)} color={"red"}>
                    Удалить
                </Button>
            </td>
            <td></td>
        </tr>
    );
};

export default ArchiveLineComp;