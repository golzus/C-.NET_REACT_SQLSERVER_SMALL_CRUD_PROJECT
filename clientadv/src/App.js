import Login from "./LoginPage";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Outlet,
} from "react-router-dom";
import MainContent from "./MainContent";
import AdvertisementsPage from "./AdvertisementsPage";
import AdvertisementOrdered from "./AdvertisementOrdered";

function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path="/" element={<AdvertisementsPage />} />
          {/* <Route index element={<h1>Site</h1>} /> */}
          <Route path="login" element={<Login />} />
          <Route path="dash/content" element={<MainContent />} />
          <Route path="dash/orders" element={<AdvertisementOrdered />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
