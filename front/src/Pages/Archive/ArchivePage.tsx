import React, {useEffect, useState} from 'react';
import {RepairDTO} from "../Repairs/RepairsPage";
import axios from "axios";
import ArchiveLineComp from "./ArchiveLineComp";
import "../Styels.css"

export interface ArchiveDTO {
    id: number,
    repair: RepairDTO,
    parts: string,
    end: string,
}

async function GetArchives(setter: any){
    try {
        let response = await axios.get<ArchiveDTO[]>("/api/Archives");
        setter(response.data);
    }
    catch(e) {
        alert(e);
    }
}

const ArchivePage = () => {
    const [archives, setArchives] = useState<ArchiveDTO[] | null>(null);

    useEffect(() => {
        GetArchives(setArchives);
    }, [])

    return (
        <div>
            <table className={"table"}>
                <tr>
                    <th>ИД</th>
                    <th>Назначенный рабочий</th>
                    <th>Клиент</th>
                    <th>Услуги</th>
                    <th>Детали</th>
                    <th>Машина</th>
                    <th>Начало работ</th>
                    <th>Конец работ</th>
                    <th>Итого</th>
                    <th/>
                    <th/>
                    <th/>
                </tr>
                {archives?.map((a) =>
                    <ArchiveLineComp initArchive={a}/>)}
            </table>
        </div>
    );
};

export default ArchivePage;