const styles = {
    topHeader: {
      width: "100%",
      height: "5%",
    },
    text: {
      color: "#fff",
      fontSize: 10,
      margin: 5,
    },
  };
   // desciription: "Header",
  
  const TopHeader = () => (
    <div style={styles.topHeader}>
      <span style={styles.text}>Win Calculator</span>
    </div>
  );
  
  export default TopHeader;