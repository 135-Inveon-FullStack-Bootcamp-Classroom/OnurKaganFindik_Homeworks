const ToDoConroller = ({inputValue, setInputValue}) => {
  return (
    <div>
      <input value={inputValue} onChange={(e) => setInputValue(e.target.value)} />
      <button >Save</button>
    </div>
  )
};
 
export default ToDoConroller;

