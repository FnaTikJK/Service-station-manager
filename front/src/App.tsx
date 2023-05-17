import React from 'react';
import { Route, Routes} from "react-router-dom";
import './App.css';
import HeaderComp from "./Components/HeaderComp";
import HomePage from "./Pages/HomePage";

function App() {
  return (
      <Routes>
        <Route path={"/"} element={<HeaderComp />}>
          <Route index element={<HomePage />}/>
        </Route>
      </Routes>
  );
}

export default App;
