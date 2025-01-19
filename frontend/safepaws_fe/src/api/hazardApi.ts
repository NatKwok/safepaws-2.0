import axios from 'axios'

// Set up the base URL and default headers
const apiClient = axios.create({
  baseURL: 'http://localhost:5000/api/', // Adjust based on your .NET backend URL
  headers: {
    'Content-Type': 'application/json',
  },
})

// Get Hazards data from the backend
export const fetchHazards = async () => {
  const response = await apiClient.get('/hazards')
  return response.data
}

// Optionally, you can create other functions to post data or handle more API operations related to Hazards
// export const createHazard = (hazardData) => {
//   return apiClient.post('/Hazards', hazardData)
// }
