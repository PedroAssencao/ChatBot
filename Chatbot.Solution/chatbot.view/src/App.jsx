import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home'
import { urlBase, UsuarioLogado } from './appsettings';
import NoPage from './pages/NoPage';
import './App.css';
import Login from './pages/Login'
import Atendimento from './pages/AtendentePage'
import FluxoBot from './pages/FluxoBot'
import DashBoard from './pages/DashBoard'
import Usuario from './pages/Usuario'
import Sidebar from './components/BaseComponents/sideBar'
export default function App() {

  const searchLocation = window.location.pathname.toLocaleLowerCase();

  const urlQueteramSideBarENavBar = ['/', '/home', '/atendimento', '/fluxobot', '/dashboard', '/Usuario'].map(url => url.toLowerCase());

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
        <div className="row bg-light min-vh-100">
          {IsTrue ? <Sidebar /> : null}
          <Routes>
            <Route index element={<Home />} />
            <Route path="/home" element={<Home />} />
            <Route path="/Atendimento" element={<Atendimento />} />
            <Route path="/FluxoBot" element={<FluxoBot />} />
            <Route path="/Login" element={<Login />} />
            <Route path="/DashBoard" element={<DashBoard />} />
            <Route path="/Usuario" element={<Usuario />} />
            <Route path="*" element={<NoPage />} />
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  )

}

