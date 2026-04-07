import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5219/api' // Đây là cổng API của PaulShop.API
});

export default api;