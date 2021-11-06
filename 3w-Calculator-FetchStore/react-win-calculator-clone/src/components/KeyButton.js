import { useState, useContext } from "react";
import { CalcContext } from "../contexts/CalcContext";

// Styles

const styles = {
  keyContainer: {
    width: '24.2%',
    height: '18.5%',
    border: '1px solid black',
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
  },
  keyText: {
    color: "#a5a5a5",
    fontFamily: '1.5em',
    fontSize: 15,
  },
};

//description: returns the style of the key when hovered

const getHoveredStyle = (isBlue) => {
  let hoveredStyle = { cursor: "pointer", backgroundColor: "#999" };
  if (isBlue) hoveredStyle = { ...hoveredStyle, backgroundColor: "#24567a" };

  return hoveredStyle;
};

const getHoveredKeyTextStyle = (hovered) => {
  if (hovered) return { color: "black" };
};

const KeyButton = ({ label, isBlue, isNumber, operator }) => {
  const { theme } = useContext(CalcContext);
  console.log(theme);
  const [hovered, setHovered] = useState(false);

  const isBlueStyle = isBlue ? { backgroundColor: "#134569" } : {};
  const isNumberStyle = isNumber ? { backgroundColor: "#070707" } : {};
  const isHoveredStyle = hovered ? getHoveredStyle(isBlue) : {};

  return (
    <div
      style={{
        ...styles.keyContainer,
        ...isBlueStyle,
        ...isNumberStyle,
        ...isHoveredStyle,
      }}
      onMouseEnter={() => setHovered(true)}
      onMouseLeave={() => setHovered(false)}
    >
      <span style={{
        ...styles.keyText,
        ...getHoveredKeyTextStyle(hovered)
      }}>
        {label}
      </span>
    </div>
  );
};

export default KeyButton;