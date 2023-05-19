import React from 'react';
import { Route, Routes} from "react-router-dom";
import './App.css';
import HeaderComp from "./Components/HeaderComp";
import HomePage from "./Pages/Home/HomePage";
import WorkersPage from "./Pages/Workers/WorkersPage";
import ClientsPage from "./Pages/Clients/ClientsPage";
import RepairsPage from "./Pages/Repairs/RepairsPage";
import ArchivePage from "./Pages/Archive/ArchivePage";

function App() {
  return (
      <Routes>
        <Route path={"/"} element={<HeaderComp />}>
            <Route index element={<HomePage />}/>
            <Route path={"/Workers"} element={<WorkersPage />}/>
            <Route path={"/Clients"} element={<ClientsPage />}/>
            <Route path={"/Repairs"} element={<RepairsPage />}/>
            <Route path={"/Archive"} element={<ArchivePage />}/>
        </Route>
      </Routes>
  );
}

export default App;
