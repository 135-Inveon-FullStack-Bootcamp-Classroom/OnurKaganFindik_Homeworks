import React, { useState, createContext } from "react";

export const CalcContext = createContext();

export const CalcProvider = ({ children }) => {
  const [mainText, setMainText] = useState("0");
  const [resetMainTextNextTime, setResetMainTextNextTime] = useState(true);

  const [lastResult, setLastResult] = useState("");
  const [currentOperation, setCurrentOperation] = useState("");

  // handle numbers and operators in the main text field 

  const handleKeyClick = (isNumber, dot, label, operator) => {
    // if the main text is 0 and the user clicks a number, the main text will be replaced by the number
    if (isNumber || dot) {
      if (resetMainTextNextTime) {
        setMainText(label);
        setResetMainTextNextTime(false);
      } else {
        setMainText((mainText) => {
          return mainText + label;
        });
      }
    }

    // handle operators
    // if the last character is an operator, replace it with the new operator
    if (operator) {
      setCurrentOperation(label);
      setResetMainTextNextTime(true);
      switch (label) {
        case "%":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult((lastResult * Number(mainText)) / 100);
            setMainText((lastResult * Number(mainText)) / 100);
          }
          break;
        case "CE":
          setMainText(0)
          break;
        case "C":
          setLastResult("")
          setMainText(0)
          break;
        case "<-":
          if (lastResult !== "") {
            setLastResult("")
          }
          // if the main text is not 0, remove the last character
          else if (mainText !== "0" || mainText !== 0) {
            setMainText(mainText.toString().substring(0, mainText.length - 1))
            if (mainText.length === 1) setMainText("0")
          }
          break;


        case "1/x":
          setLastResult(`1/(${mainText})`)
          setMainText((1 / mainText).toFixed(3))
          break;
        case "x^2":
          setLastResult(`sqr(${mainText})`)
          setMainText(mainText * mainText)
          break;
        case "√¯x":
          setLastResult(`√¯x(${mainText})`)
          setMainText(Math.sqrt(Number(mainText)))
          break;
        case "/":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult / Number(mainText));
            setMainText(lastResult / Number(mainText));
          }
          break;

        case "x":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult * Number(mainText));
            setMainText(Number(mainText) * lastResult);
          }
          break;

        case "-":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult - Number(mainText));
            setMainText(lastResult - Number(mainText));
          }
          break;

        case "+":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(Number(mainText) + lastResult);
            setMainText(Number(mainText) + lastResult);
          }
          break;

        case "+/-":
          let sign = mainText.toString().substring(0, 1)
          if (sign !== "-") {
            setMainText("-" + mainText)
          }
          else {
            setMainText(mainText.toString().substring(1, mainText.length))
          }
          break;

        case "=":
          if (currentOperation === "+") {
            setMainText(Number(mainText) + lastResult);
            setLastResult("");
          }
          else if (currentOperation === "-") {
            setMainText(lastResult - Number(mainText));
            setLastResult("");
          }
          else if (currentOperation === "x") {
            setMainText(lastResult * Number(mainText));
            setLastResult("");
          }
          else if (currentOperation === "/") {
            setMainText(lastResult / Number(mainText));
            setLastResult("");
          }
          else if (currentOperation === "%") {
            setMainText((lastResult * Number(mainText)) / 100);
            setLastResult("");
          }
          break;

        default:
          break;
      }
    }
  };

  // return the context to the parent component
  return (
    <CalcContext.Provider
      value={{
        mainText,
        setMainText,
        handleKeyClick,
        resetMainTextNextTime,
        setResetMainTextNextTime,
        lastResult,
        currentOperation,
      }}
    >
      {children}
    </CalcContext.Provider>
  );
};
