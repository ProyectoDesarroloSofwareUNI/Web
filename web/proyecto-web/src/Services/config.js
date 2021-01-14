import axios from 'axios';

const BASE_URL = "http://localhost:10471/api/Matricula/logear";

const API= axios.create({
    baseURL:BASE_URL,
});
export default API;