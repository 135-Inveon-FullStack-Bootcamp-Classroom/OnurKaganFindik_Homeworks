import './App.css';

import AppContainer from './components/AppContainer';
import KeysSection from './components/KeysSection';
import ScreenSection from './components/ScreenSection';
import TopHeader from './components/TopHeader';

function App() {
  return (
    <AppContainer>
      <TopHeader />
      <ScreenSection />
      <KeysSection />
    </AppContainer>
  );
}

export default App;
