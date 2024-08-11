import React, { useEffect } from 'react'

const users = () => {
    useEffect(()=>{
        Axios.get(`https://localhost:7086/users`)
        .then(res=> console.log(res.data,"hhh") )
        },[])
  return (
    <div>users</div>
  )
}

export default users