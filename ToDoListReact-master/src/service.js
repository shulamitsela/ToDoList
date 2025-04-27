import axios from 'axios';
axios.defaults.baseURL = process.env.REACT_APP_VARIABLE_NAME;

const apiUrl = process.env.REACT_APP_VARIABLE_NAME;

axios.interceptors.response.use(
  response => {
    return response;
  },
  error => {
    console.error('שגיאה בבקשה:', error.response ? error.response.data : error.message);
    return Promise.reject(error);
  }
);

export default {
  getTasks: async () => {
    const result = await axios.get(`${apiUrl}/getAll`) 
    console.log(result);
    return result.data;
  },

  addTask: async(name)=>{
    const result = await axios.post(`${apiUrl}/addItem?name=${encodeURIComponent(name)}`);   
     console.log('addTask', result)
    return result.data;
  },

  setCompleted: async(id, isComplete)=>{
    const result = await axios.put(`${apiUrl}/updateItem/${id}`)
    console.log('setCompleted', {id, isComplete})
    console.log(result.data);    
    return {};
  },

  deleteTask:async(id)=>{
    const result = await axios.delete(`${apiUrl}/deleteItem/${id}`)
    console.log('deleteTask')
  }
};
