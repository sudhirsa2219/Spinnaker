export interface Customer {
    id: string;
    name: string;
    surname:string;
    email: string;
    telephone:string;
    idNumber:string
    country: string;
  }

  export interface UpdateCustomerRequest{
    Customer: Customer;
  }

  export interface CreateCustomerRequest{
    Customer: Customer;
  }