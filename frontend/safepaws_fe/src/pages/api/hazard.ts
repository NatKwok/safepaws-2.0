import type { NextApiRequest, NextApiResponse } from 'next';

export default async function handler(req: NextApiRequest, res: NextApiResponse) {
  const { method } = req;

  // Map your .NET API endpoint
  const apiUrl = `https://localhost:5001/api/hazards`;

  try {
    // Forward the request to your .NET API
    const response = await fetch(apiUrl, {
      method, // Forward the HTTP method (GET, POST, etc.)
      headers: {
        'Content-Type': 'application/json'
      },
      body: method !== 'GET' ? JSON.stringify(req.body) : undefined, // Pass body for POST/PUT requests
    });

    // Handle the response from .NET API
    const data = await response.json();

    // Respond to the client
    res.status(response.status).json(data);
  } catch (error) {
    console.error('Error proxying request:', error);
    res.status(500).json({ message: 'Error proxying request', error });
  }
}
