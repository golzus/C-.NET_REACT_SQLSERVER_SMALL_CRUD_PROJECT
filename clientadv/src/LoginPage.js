// import React, { useState } from "react";
// import axios from "axios";
// import "./login-page.css";
// import { useNavigate } from "react-router-dom";

// const LoginPage = () => {
//   const [email, setEmail] = useState("");
//   const [password, setPassword] = useState("");
//   const [status, setStatus] = useState("login");
//   const navigate = useNavigate();
//   const [systemMessage, setsystemMessage] = useState("");
//   const handleSubmit = async (event) => {
//     event.preventDefault();
//     if (status === "login") {
//       try {
//         const response = await axios.post("https://localhost:7086/users/find", {
//           email,
//           password,
//         });
//         console.log(response, "response");
//         // ניתן לטפל בתשובה מהשרת כאן, למשל:

//         if (response.data === true) {
//           setsystemMessage("המשתמש רשום");
//           navigate("/dash/orders");
//         }
//       } catch (error) {
//         setsystemMessage("המשתמש לא רשום");
//       }
//     }

//     if (status === "register") {
//       try {
//         const response = await axios.post("https://localhost:7086/users/add", {
//           email,
//           password,
//         });
//         // ניתן לטפל בתשובה מהשרת כאן, למשל:
//         if (response.status === 200) {
//           setsystemMessage(response.data);
//         }
//       } catch (error) {
//         setsystemMessage(error.response.data);
//       }
//     }
//   };
//   const onChangeEmailFunc = (e) => {
//     setsystemMessage("");
//     setEmail(e.target.value);
//   };
//   return (
//     <div className="login-page">
//       <form className="login-page-form" onSubmit={handleSubmit}>
//         <h1>{status}</h1>
//         <input
//           type="text"
//           required
//           name="email"
//           id="email"
//           placeholder="מייל"
//           value={email}
//           onChange={onChangeEmailFunc}
//         />
//         <input
//           type="password"
//           required
//           name="password"
//           id="password"
//           placeholder="סיסמא"
//           value={password}
//           onChange={(e) => setPassword(e.target.value)}
//         />
//         {systemMessage && <h1 style={{ color: "red" }}>{systemMessage}</h1>}

//         <button type="submit">כניסה</button>
//       </form>
//       {status === "register" && (
//         <button onClick={() => setStatus("login")}>login</button>
//       )}
//       {status === "login" && (
//         <button onClick={() => setStatus("register")}>register</button>
//       )}
//     </div>
//   );
// };

// export default LoginPage;
import React, { useState } from "react";
import axios from "axios";
import "./login-page.css";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [status, setStatus] = useState("login");
  const navigate = useNavigate();
  const [systemMessage, setsystemMessage] = useState("");
  const handleSubmit = async (event) => {
    event.preventDefault();
    if (status === "login") {
      try {
        const response = await axios.post("https://localhost:7086/users/find", {
          email,
          password,
        });
        console.log(response, "response");
        // ניתן לטפל בתשובה מהשרת כאן, למשל:

        if (response.data === true) {
          setsystemMessage("המשתמש רשום");
          navigate("/dash/orders");
        }
        else if(response.data===false)
        setsystemMessage("המשתמש לא רשום");
      } catch (error) {
        setsystemMessage("המשתמש לא רשום");
      }
    }

    if (status === "register") {
      try {
        const response = await axios.post(" https://localhost:7086/users/add", {
          email,
          password,
        });
        // ניתן לטפל בתשובה מהשרת כאן, למשל:
        if (response.data === true) {
          setsystemMessage("נרשמת בהצלחה");
        }
        if(response.data===false)
        setsystemMessage("didnt succedd");
      } catch (error) {
        setsystemMessage(error.response.data);
      }
    }
  };
  const onChangeEmailFunc = (e) => {
    setsystemMessage("");
    setEmail(e.target.value);
  };
  return (
    <div className="login-page">
      <form className="login-page-form" onSubmit={handleSubmit}>
        <h1>{status}</h1>
        <input
          type="text"
          required
          name="email"
          id="email"
          placeholder="מייל"
          value={email}
          onChange={onChangeEmailFunc}
        />
        <input
          type="password"
          required
          name="password"
          id="password"
          placeholder="סיסמא"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        {systemMessage && <h1 style={{ color: "red" }}>{systemMessage}</h1>}

        <button type="submit">כניסה</button>
      </form>
      {status === "register" && (
        <button onClick={() => setStatus("login")}>login</button>
      )}
      {status === "login" && (
        <button onClick={() => setStatus("register")}>register</button>
      )}
    </div>
  );
};

export default LoginPage;