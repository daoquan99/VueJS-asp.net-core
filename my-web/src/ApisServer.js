// export default {
//     HOST: "https://localhost:44348/",
//     BASE_API: "https://localhost:44348/api",
//     AUTH_LOGIn: "https://localhost:44348/api/auth/login",
//     BASE_API_ODATA: "https://localhost:44348/odata",
// };
//https://localhost:44348/


import axios from 'axios';

const instance = axios.create({
    baseURL: 'https://localhost:44348/api/'
})
export default instance;