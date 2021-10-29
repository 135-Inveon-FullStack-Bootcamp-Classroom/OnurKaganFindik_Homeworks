import React, { useState, useEffect } from 'react';
import List from './components/List';
import Alert from './components/Alert';

const getLocalStorage = () => { // get local storage
  let list = localStorage.getItem('list');
  if (list) {
    return (list = JSON.parse(localStorage.getItem('list')))
  } else {
    return [];
  }

};

const App = () => { 
  const [name, setName] = useState(""); // set name
  const [list, setList] = useState(getLocalStorage()); // set list
  const [isEditing, setIdEditing] = useState(false);    // set isEditing
  const [editID, setEditID] = useState(null); // set editID
  const [alert, setAlert] = useState({ show: false, message: "", type: "" }); // set alert

  useEffect(() => { // useEffect is a hook that runs after the component is rendered
    localStorage.setItem("list", JSON.stringify(list));
  }, [list]);


  const handleSubmit = (e) => {
    e.preventDefault();
    if (!name) {
      showAlert(true, "danger", "Lütfen bir görev giriniz");
    } else if (name && isEditing) {
      setList(
        list.map(item => {
          if (item.id === editID) {
            return { ...item, name: name }
          }
          return item
        })
      );
      setName("");    // reset input
      setEditID(null);
      setIdEditing(false);
      showAlert(true, "success", "Görev düzenlendi");
    } else { // Add new item
      showAlert(true, "success", "Yeni görev eklendi");
      const newItem = { id: new Date().getTime().toString(), title: name };
      setList([...list, newItem]);
      setName("");
    }
  };
  const showAlert = (show = false, type = "", msg = "") => {
    setAlert({ show, type, msg });
  };
  const removeItem = (id) => { // remove item from list
    showAlert(true, "danger", "Görev silindi");
    setList(list.filter(item => item.id !== id));
  };
  const editItem = (id) => { // edit item from list
    const editItem = list.find((item) => item.id === id);
    setIdEditing(true);
    setEditID(id);
    setName(editItem.title);
  };
  const clearList = () => { // clear list
    showAlert(true, "danger", "Tüm liste silindi");
    setList([]);
  };

  return (
    <section className="section-center">
      <form onSubmit={handleSubmit}>
        {alert.show && <Alert {...alert} removeAlert={showAlert} list={list} />}
        <h3 style={{ marginBottom: "1.5rem", textAlign: "center" }}>
          Todo App
        </h3>
        <div className=" mb-3 form ">
          <input
            type="text"
            className="form-control" 
            placeholder="Yeni bir görev giriniz.." // input
            onChange={(e) => setName(e.target.value)} 
            value={name}
          /> 
          <button type="submit" className="btn btn-success"> 
            {isEditing ? "Düzenle" : "Ekle"}
          </button>
        </div>
      </form>
      {list.length > 0 && (
        <div style={{ marginTop: "2rem" }}>
          <List items={list} removeItem={removeItem} editItem={editItem} />
          <div className="text-center">
            <button className="btn btn-warning" onClick={clearList}>
              Tümünü Sil
            </button>
          </div>
        </div>
      )}
    </section>
  )
}

export default App