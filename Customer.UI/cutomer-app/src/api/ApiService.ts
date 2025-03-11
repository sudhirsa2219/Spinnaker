// apiService.ts
import axios from 'axios';
import { Customer } from './DataType';

// Create an Axios instance with default settings
const api = axios.create({
  baseURL: 'https://localhost:6200/', // Replace with your actual API URL
  headers: {
    'Content-Type': 'application/json',
  },
});

// API Methods
export const createCustomerApi = async (cust: Customer): Promise<Customer> => {
  const response = await api.post('/customers', cust);
  return response.data;
};

export const getCustomersApi = async (): Promise<Customer[]> => {
  const response = await api.get('/customers');
  return response.data;
};

export const updateCustomerApi = async (cust: Customer): Promise<Customer> => {
  const response = await api.put(`/customers/${cust.id}`, cust);
  return response.data;
};

export const deleteCustomerApi = async (custId: string): Promise<void> => {
  await api.delete(`/customers/${custId}`);
};
