// import React, { useEffect, useState } from "react";
// import "./advertisementsPage.css";
// import AdvertisementsPageContent from "./AdvertisementsPageContent";

// const AdvertisementsPage = () => {
//   const [advertisements, setAdvertisements] = useState([]);
//   const [imagePathArr, setImagePathArr] = useState([null, null, null, null]); // Array of image paths

//   const fetchAdvertisements = async () => {
//     try {
//       const response = await fetch(
//         "https://localhost:7086/advertisement/byVisits"
//       );
//       const data = await response.json();
//      console.log("hthh",data)
//       setAdvertisements(data);
   
//     } catch (error) {
//       console.error("Error fetching advertisements:", error);
//       console.log("fgsg");
//     }
//   };
//   // const fetchAdvertise = async () => {
//   //   try {
//   //     const response = await fetch("https://localhost:7086/advertisement/byVisits");
  
//   //     if (!response.ok) {
//   //       throw new Error(`HTTP error! Status: ${response.status}`);
//   //     }
  
//   //     // קריאה לתגובה כטקסט
//   //     const text = await response.text();
//   //     console.log("Text received:", text);
  
//   //     // שימוש בטקסט אם זה מה שאתה מצפה
//   //     // לדוגמה, אם התגובה היא פשוט "Hello World"
//   //     setAdvertisements({ Message: text });
  
//   //   } catch (error) {
//   //     console.error("Error fetching advertisements:", error);
//   //   }
//   // };
  
  
  
//   useEffect(() => {
//      fetchAdvertisements();
//   }, []);

//   useEffect(() => {
//     const newArray = [...imagePathArr];
//     advertisements.forEach((adv) => {
//       switch (adv.location) {
//         case "Lower right":
//           if (!newArray[0]) newArray[0] = adv.path;
//           break;
//         case "Lower left":
//           if (!newArray[1]) newArray[1] = adv.path;
//           break;
//         case "Upper right":
//           if (!newArray[2]) newArray[2] = adv.path;
//           break;
//         case "Upper left":
//           if (!newArray[3]) newArray[3] = adv.path;
//           break;
//         default:
//           console.log("No correct location!");
//           break;
//       }
//     });
//     setImagePathArr(newArray);
//   }, [advertisements]);

//   console.log(advertisements, "Advertisements Data");
//   console.log(imagePathArr, "Image Paths");

//   return (
//     <div className="AdvertisementsContent">
//       <div>
//         {!imagePathArr[0] ? (
//           <AdvertisementsPageContent location="Lower right" />
//         ) : (
//           <img
//             src={imagePathArr[0]}
//             alt="Advertisement Lower Right"
//             className="adv"
//           />
//         )}
//       </div>

//       <div>
//         {!imagePathArr[1] ? (
//           <AdvertisementsPageContent location="Lower left" />
//         ) : (
//           <img
//             src={imagePathArr[1]}
//             alt="Advertisement Lower Left"
//             className="adv"
//           />
//         )}
//       </div>

//       <div>
//         {!imagePathArr[2] ? (
//           <AdvertisementsPageContent location="Upper right" />
//         ) : (
//           <img
//             src={imagePathArr[2]}
//             alt="Advertisement Upper Right"
//             className="adv"
//           />
//         )}
//       </div>

//       <div>
//         {!imagePathArr[3] ? (
//           <AdvertisementsPageContent location="Upper left" />
//         ) : (
//           <img
//             src={imagePathArr[3]}
//             alt="Advertisement Upper Left"
//             className="adv"
//           />
//         )}
//       </div>
//     </div>
//   );
// };

// export default AdvertisementsPage;

import React, { useEffect, useState } from "react";
import "./advertisementsPage.css";
import AdvertisementsPageContent from "./AdvertisementsPageContent";

const AdvertisementsPage = () => {
  const [advertisements, setAdvertisements] = useState([]);
  const [imagePathArr, setImagePathArr] = useState([null, null, null, null]);

  const fetchAdvertisements = async () => {
    try {
      const response = await fetch("https://localhost:7086/advertisement/byVisits");
      const data = await response.json();
      setAdvertisements(data);
    } catch (error) {
      console.error("Error fetching advertisements:", error);
    }
  };

  useEffect(() => {
    fetchAdvertisements();
  }, []);

  useEffect(() => {
    const newArray = [...imagePathArr];
    advertisements.forEach((adv) => {
      switch (adv.location) {
        case "Lower right":
          if (!newArray[0]) newArray[0] = adv.path;
          break;
        case "Lower left":
          if (!newArray[1]) newArray[1] = adv.path;
          break;
        case "Upper right":
          if (!newArray[2]) newArray[2] = adv.path;
          break;
        case "Upper left":
          if (!newArray[3]) newArray[3] = adv.path;
          break;
        default:
          console.log("No correct location!");
          break;
      }
    });
    setImagePathArr(newArray);
  }, [advertisements]);

  return (
    <div className="AdvertisementsContent">
      {imagePathArr.map((path, index) => (
        <div key={index} className="ad-container">
          {!path ? (
            <AdvertisementsPageContent location={getLocation(index)} />
          ) : (
            <img src={path} alt={`Advertisement ${getLocation(index)}`} className="adv" />
          )}
        </div>
      ))}
    </div>
  );
};

const getLocation = (index) => {
  switch (index) {
    case 0:
      return "Lower right";
    case 1:
      return "Lower left";
    case 2:
      return "Upper right";
    case 3:
      return "Upper left";
    default:
      return "Unknown";
  }
};

export default AdvertisementsPage;
