import React, { useState, useEffect, useRef } from "react";
import axios from "axios";
import "./advertisementOrdered.css";
import { useNavigate } from "react-router-dom";

const AdvertisementOrdered = () => {
  const [adLocation, setAdLocation] = useState(null);
  const navigate = useNavigate();
  const formRef = useRef(null);

  useEffect(() => {
    const location = localStorage.getItem("clickedAdLocation");
    setAdLocation(location);
    console.log(adLocation, "adlocation");
  }, [adLocation]);

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const formData = new FormData(formRef.current);
      const advObj = Object.fromEntries(formData.entries());
      console.log(advObj);
      advObj.status=true
      advObj.email=''
      advObj.visitsSoFar=0
      const rr={
        "id": 0,
        "status": true,
        "path": "string",
        "location": "string",
        "email": "string",
        "visitsSoFar": 0,
        "desiredVisits": 0
      }
      const response = await axios.post(
        "https://localhost:7086/advertisement/byVisits/add",
        advObj
      );
      console.log(response.data,"response");
      navigate("/");
    } catch (error) {
      console.error(error, "error");
    }
  };

  return (
    <div>
      <form className="formClass" ref={formRef} onSubmit={handleSubmit}>
        <h1>טופס הזמנת פרסומת</h1>
        <input
          type="text"
          name="location"
          style={{ display: "none" }}
          value={adLocation || ""}
          readOnly
        />
        <div>
          <label>כמה ביקורים הנך רוצה</label>
          <input type="text" name="desiredVisits" />
        </div>
        <div>
          <label> בחר תמונה: </label>
          <select className="chooseAnImage" name="path" id="path">
            <option value="1.jpg">1</option>
            <option value="2.jpg">2</option>
            <option value="3.jpg">3</option>
            <option value="4.jpg">4</option>
            <option value="5.jpg">5</option>
            <option value="6.jpg">6</option>
            <option value="7.jpg">7</option>
            <option value="8.jpg">8</option>
            <option value="9.jpg">9</option>
          </select>
        </div>
        <button type="submit">שליחה</button>
      </form>
    </div>
  );
};

export default AdvertisementOrdered;
