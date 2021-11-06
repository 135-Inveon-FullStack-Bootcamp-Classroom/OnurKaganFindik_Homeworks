const styles = {
  appContainer: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    width: "100vw",
    height: "100vh",
    backgroundColor: "#e5e5e5",
  },

  calculatorContainer: {
    backgroundColor: "#333",
    width: "20vw",
    height: "70vw",
    minWidth: 250,
    maxWidth: 500,
    maxHeight: 450,
  },
};

// describtion: AppContainer is the main container of the application.

const AppContainer = ({ children }) => {
  console.log({ children });
  return (
    <div style={styles.appContainer}>
      <div style={styles.calculatorContainer}>
        {children}
      </div>
    </div>
  );
};

export default AppContainer;