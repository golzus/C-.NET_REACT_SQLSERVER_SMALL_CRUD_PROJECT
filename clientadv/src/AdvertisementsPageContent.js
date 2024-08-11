import React from "react";
import "./advertisementsPageContent.css";
import { useNavigate } from "react-router-dom";

const AdvertisementsPageContent = ({ location }) => {
  const navigate = useNavigate();

  const clickFuncLocalKeepLocation = () => {
    localStorage.setItem("clickedAdLocation", location);
    navigate("/login"); // הוספת הנתיב המלא
  };

  const clickFuncAddAdv = () => {
    clickFuncLocalKeepLocation();
    navigate("/login"); // הוספת הנתיב המלא
  };

  return (
    <div className="AdvertisementsPageContent">
      <button onClick={clickFuncAddAdv} className="btnAdvertiseHere">
        <h1>Advertise here</h1>
      </button>
    </div>
  );
};

export default AdvertisementsPageContent;
