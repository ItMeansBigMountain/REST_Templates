import unittest
import requests
import json

BASE_URL = 'http://localhost:5221/api/UserAccounts'

class TestUserAccountsAPI(unittest.TestCase):
    user_id = None  # Class-level variable to store the user ID

    def setUp(self):
        self.fetch_user_id()

    def fetch_user_id(self):
        response = requests.get(BASE_URL)
        users = response.json()
        if users:
            TestUserAccountsAPI.user_id = users[0]['id']

    def print_response(self, response):
        print(f'Status Code: {response.status_code}')
        try:
            if response.status_code != 204:  # Avoid parsing JSON for No Content response
                print('Response JSON:', response.json())
            else:
                print('Response Text:', response.text)
        except json.JSONDecodeError:
            print('Response Text:', response.text)
        print()

    # curl -X POST http://localhost:5221/api/UserAccounts -H "Content-Type: application/json" -d '{"firstName":"John","lastName":"Doe","email":"john.doe@example.com","password":"password123","role":"Member","registeredAt":"2024-01-01T00:00:00"}'
    def test_01_add_user(self):
        new_user = {
            "firstName": "John",
            "lastName": "Doe",
            "email": "john.doe@example.com",
            "password": "password123",
            "role": "Member",
            "registeredAt": "2024-01-01T00:00:00"
        }
        response = requests.post(BASE_URL, json=new_user)
        self.print_response(response)
        self.assertEqual(response.status_code, 201)
        self.fetch_user_id()  # Update the user_id after adding a new user

    # curl -X GET http://localhost:5221/api/UserAccounts
    def test_02_get_all_users(self):
        response = requests.get(BASE_URL)
        self.print_response(response)
        self.assertEqual(response.status_code, 200)

    # curl -X GET http://localhost:5221/api/UserAccounts/{id}
    def test_03_get_user_by_id(self):
        if TestUserAccountsAPI.user_id is None:
            self.skipTest("No users available. Skipping test.")
        response = requests.get(f'{BASE_URL}/{TestUserAccountsAPI.user_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 200)

    # curl -X PUT http://localhost:5221/api/UserAccounts/{id} -H "Content-Type: application/json" -d '{"firstName":"John","lastName":"Doe","email":"john.doe@example.com","password":"newpassword456","role":"Admin","registeredAt":"2024-01-01T00:00:00"}'
    def test_04_update_user(self):
        if TestUserAccountsAPI.user_id is None:
            self.skipTest("No users available. Skipping test.")
        updated_user = {
            "firstName": "John",
            "lastName": "Doe",
            "email": "john.doe@example.com",
            "password": "newpassword456",
            "role": "Admin",
            "registeredAt": "2024-01-01T00:00:00"
        }
        response = requests.put(f'{BASE_URL}/{TestUserAccountsAPI.user_id}', json=updated_user)
        self.print_response(response)
        self.assertEqual(response.status_code, 204)

    # curl -X DELETE http://localhost:5221/api/UserAccounts/{id}
    def test_05_delete_user(self):
        if TestUserAccountsAPI.user_id is None:
            self.skipTest("No users available. Skipping test.")
        response = requests.delete(f'{BASE_URL}/{TestUserAccountsAPI.user_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 204)

if __name__ == '__main__':
    unittest.main(verbosity=2)
