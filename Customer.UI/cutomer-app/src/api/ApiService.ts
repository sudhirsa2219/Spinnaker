// apiService.ts
import axios from 'axios';
import { Customer, UpdateCustomerRequest, CreateCustomerRequest } from './DataType';
import {v4 as uuidv4} from 'uuid';

// Create an Axios instance with default settings
const api = axios.create({
  baseURL: 'https://localhost:6200/', // Replace with your actual API URL
  headers: {
    'Access-Control-Allow-Origin': '*',
    'Content-Type': 'application/json',
  },
});

// API Methods
export const createCustomerApi = async (cust: Customer): Promise<Customer> => {
  cust.id = uuidv4();
  console.log(cust);
  const createRequest: CreateCustomerRequest = { Customer: cust };
  const response = await api.post('/customers', createRequest);
  return response.data;
};

export const getCustomersApi = async (): Promise<Customer[]> => {
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
