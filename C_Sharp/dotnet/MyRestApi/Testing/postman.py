import unittest
import requests
import json

BASE_URL = 'http://localhost:5000/api/UserAccounts'

class TestUserAccountsAPI(unittest.TestCase):

    def setUp(self):
        self.user_id = None

    def print_response(self, response):
        print(f'Status Code: {response.status_code}')
        try:
            print('Response JSON:', response.json())
        except json.JSONDecodeError:
            print('Response Text:', response.text)
        print()

    def test_01_add_user(self):
        new_user = {
            "FirstName": "John",
            "LastName": "Doe",
            "Email": "john.doe@example.com",
            "Password": "password123",
            "Role": "Member",
            "RegisteredAt": "2024-01-01T00:00:00"
        }
        response = requests.post(BASE_URL, json=new_user)
        self.print_response(response)
        self.assertEqual(response.status_code, 201)
        self.user_id = response.json().get('id')

    def test_02_get_all_users(self):
        response = requests.get(BASE_URL)
        self.print_response(response)
        self.assertEqual(response.status_code, 200)

    def test_03_get_user_by_id(self):
        if self.user_id is None:
            self.skipTest("User ID is not set. Skipping test.")
        response = requests.get(f'{BASE_URL}/{self.user_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 200)

    def test_04_update_user(self):
        if self.user_id is None:
            self.skipTest("User ID is not set. Skipping test.")
        updated_user = {
            "FirstName": "John",
            "LastName": "Doe",
            "Email": "john.doe@example.com",
            "Password": "newpassword456",
            "Role": "Admin",
            "RegisteredAt": "2024-01-01T00:00:00"
        }
        response = requests.put(f'{BASE_URL}/{self.user_id}', json=updated_user)
        self.print_response(response)
        self.assertEqual(response.status_code, 204)

    def test_05_delete_user(self):
        if self.user_id is None:
            self.skipTest("User ID is not set. Skipping test.")
        response = requests.delete(f'{BASE_URL}/{self.user_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 204)

    def test_06_confirm_deletion(self):
        if self.user_id is None:
            self.skipTest("User ID is not set. Skipping test.")
        response = requests.get(f'{BASE_URL}/{self.user_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 404)

if __name__ == '__main__':
    unittest.main(verbosity=2)
