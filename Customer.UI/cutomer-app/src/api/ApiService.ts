// apiService.ts
import axios from 'axios';
import { Customer, UpdateCustomerRequest, CreateCustomerRequest } from './DataType';
import {v4 as uuidv4} from 'uuid';

let ServiceUrl = import.meta.env.VITE_MICRO_SERVICE_URL
// Create an Axios instance with default settings
console.log(ServiceUrl);

console.log("VITE_MICRO_SERVICE_URL from Vite:", import.meta.env.VITE_MICRO_SERVICE_URL);
console.log("API Base URL used by Axios:", ServiceUrl);

const api = axios.create({
  //baseURL: 'https://localhost:6200/', // Replace with your actual API URL
  baseURL:ServiceUrl,
  headers: {
    'Access-Control-Allow-Origin': '*',
    'Content-Type': 'application/json',
  },
});

// API Methods
export const createCustomerApi = async (cust: Customer): Promise<Customer> => {
  cust.id = uuidv4();
  console.log(ServiceUrl);
  const createRequest: CreateCustomerRequest = { Customer: cust };
  const response = await api.post('/customers', createRequest);
  return response.data;
};

export const getCustomersApi = async (): Promise<Customer[]> => {
  console.log("VITE_MICRO_SERVICE_URL from Vite:", import.meta.env.VITE_MICRO_SERVICE_URL);
  const response = await api.get('/customers');
  console.log(response);
  return response.data.customers.data;
};

export const updateCustomerApi = async (cust: Customer): Promise<Customer> => {
  const updateRequest: UpdateCustomerRequest = { Customer: cust };
  const response = await api.put('/customers', updateRequest);
  return response.data;
};

export const deleteCustomerApi = async (custId: string): Promise<void> => {
  await api.delete(`/customers/${custId}`);
};
