import axios from 'axios';
axios.defaults.baseURL = process.env.VARIABLE_NAME;

const apiUrl = process.env.VARIABLE_NAME;

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
    const result = await axios.get(`/getAll`) 
    console.log(result);
    return result.data;
  },

  addTask: async(name)=>{
    const result = await axios.post(`/add?name=${encodeURIComponent(name)}`);    console.log('addTask', result)
    return result.data;
  },

  setCompleted: async(id, isComplete)=>{
    const result = await axios.put(`/update/${id}`)
    console.log('setCompleted', {id, isComplete})
    console.log(result.data);    
    return {};
  },

  deleteTask:async(id)=>{
    const result = await axios.delete(`/delete/${id}`)
    console.log('deleteTask')
  }
};
