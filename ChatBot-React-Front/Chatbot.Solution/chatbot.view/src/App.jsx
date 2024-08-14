import { BrowserRouter, Routes, Route} from 'react-router-dom';
import Home from './pages/Home'
import NoPage from './pages/NoPage';
import './App.css';
import Atendimento from './pages/AtendentePage'
import FluxoBot from './pages/FluxoBot'
import Sidebar from './components/BaseComponents/sideBar'
export default function App() {

  const searchLocation = window.location.pathname;

  const urlQueteramSideBarENavBar = ['/', '/home', '/Atendimento','/FluxoBot'];
  
  function isNoPage(urlIndex, LocationIndex) {
    for (let i = 0; i < urlIndex.length; i++) {
      if (urlIndex[i] === LocationIndex) {
        return true;
      }
    }
    return false;
  }

  const IsTrue = isNoPage(urlQueteramSideBarENavBar, searchLocation);

  return (
    <BrowserRouter>
      <div className="container-fluid bg-warning min-vh-100">
        <div className="row bg-success min-vh-100">
          {IsTrue ? <Sidebar/> : null}
          <Routes>
            <Route index element={<Home />} />
            <Route path="/home" element={<Home />} />
            <Route path="/Atendimento" element={<Atendimento />} />
            <Route path="/FluxoBot" element={<FluxoBot />} />
            <Route path="*" element={<NoPage />} />
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  )

}

