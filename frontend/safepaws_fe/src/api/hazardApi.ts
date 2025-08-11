import axios from 'axios'

//base url
const apiClient = axios.create({
  baseURL: 'https://localhost:32775/api', // Adjust based on your .NET backend URL
  headers: {
    'Content-Type': 'application/json',
  },
})

export const fetchHazards = async () => {
  const response = await apiClient.get('/Hazards')
  return response.data
}

// Optionally, you can create other functions to post data or handle more API operations related to Hazards
// export const createHazard = (hazardData) => {
//   return apiClient.post('/Hazards', hazardData)
// }
