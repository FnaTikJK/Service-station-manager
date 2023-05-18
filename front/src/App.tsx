import React from 'react';
import { Route, Routes} from "react-router-dom";
import './App.css';
import HeaderComp from "./Components/HeaderComp";
import HomePage from "./Pages/Home/HomePage";
import WorkersPage from "./Pages/Workers/WorkersPage";

function App() {
  return (
      <Routes>
        <Route path={"/"} element={<HeaderComp />}>
            <Route index element={<HomePage />}/>
            <Route path={"/Workers"} element={<WorkersPage />}/>
        </Route>
      </Routes>
  );
}

export default App;
