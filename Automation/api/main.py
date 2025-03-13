from locust import HttpUser, task, between
from faker import Faker
import json
import uuid

fake = Faker()

baseurl = "http://localhost:6210"
class CustomerAppLoadTest(HttpUser):
    # Time between task execution in seconds (min, max)
    host = baseurl
    wait_time = between(1, 5)

    # Helper function to generate random data for customer
    def generate_customer_data(self):
        return {
            "customer": {
                "id": str(uuid.uuid4()),  # Generate a random GUID for 'id'
                "name": fake.first_name(),  # Use Faker to generate a random first name
                "surname": fake.last_name(),  # Use Faker to generate a random last name
                "email": fake.email(),  # Use Faker to generate a random email
                "telephone": fake.phone_number(),  # Use Faker to generate a random phone number
                "idNumber": fake.ssn(),  # Use Faker to generate a random SSN (used as IdNumber)
                "country": fake.country()  # Use Faker to generate a random country
            }
        }

    @task(3)
    def create_customer(self):
        customer_data = self.generate_customer_data()  # Generate customer data
        headers = {"Content-Type": "application/json"}
        self.client.post(f"{baseurl}/customers", data=json.dumps(customer_data), headers=headers)

    @task(2)
    def read_customer(self):
        customer_id = str(uuid.uuid4())  # Simulate a random customer ID (UUID)
        self.client.get(f"/customers")

    @task(1)
    def update_customer(self):
        customer_id = str(uuid.uuid4())  # Simulate a random customer ID (UUID)
        updated_data = self.generate_customer_data()  # Generate updated customer data
        headers = {"Content-Type": "application/json"}
        self.client.put(f"{baseurl}/customers/{customer_id}", data=json.dumps(updated_data), headers=headers)


    @task(1)
    def delete_customer(self):
        customer_id = str(uuid.uuid4())  # Simulate a random customer ID (UUID)
        self.client.delete(f"{baseurl}/customers/{customer_id}")

