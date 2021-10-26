import React, {useState} from "react";
import Header from "./Components/Header";
import ToDoConroller from "./Components/ToDoConroller";

function App() {
  const [imputValue, setImputValue] = useState("");

  return (
    <div>
      <Header />
      <ToDoConroller imputValue={imputValue} setInputValue={setImputValue} />
      <h2>{imputValue}</h2>
    </div>
  );

}

export default App;
