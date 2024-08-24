import unittest
import requests
import json

BASE_URL_BOOKS = 'http://localhost:5221/api/BooksLibrary'
BASE_URL_USERS = 'http://localhost:5221/api/UserAccounts'

class TestApiEndpoints(unittest.TestCase):
    book_id = None  # Class-level variable to store the book ID
    user_id = None  # Class-level variable to store the user ID

    def print_response(self, response):
        print(f'Status Code: {response.status_code}')
        try:
            print('Response JSON:', response.json())
        except json.JSONDecodeError:
            print('Response Text:', response.text)
        print()

    # ---------- BOOKS API TESTS ----------

    def test_01_add_book(self):
        new_book = {
            "Title": "The Great Gatsby",
            "Author": "F. Scott Fitzgerald",
            "Genre": "Classic",
            "Quantity": 10,
            "CheckedOut": False,
            "ReleaseDate": "1925-04-10T00:00:00",
            "DueDate": "2024-01-01T00:00:00"
        }
        response = requests.post(BASE_URL_BOOKS, json=new_book)
        self.print_response(response)
        self.assertEqual(response.status_code, 201)
        TestApiEndpoints.book_id = response.json().get('id')

    def test_02_get_all_books(self):
        response = requests.get(BASE_URL_BOOKS)
        self.print_response(response)
        self.assertEqual(response.status_code, 200)

    def test_03_get_book_by_id(self):
        if TestApiEndpoints.book_id is None:
            self.skipTest("No books available. Skipping test.")
        response = requests.get(f'{BASE_URL_BOOKS}/{TestApiEndpoints.book_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 200)

    def test_04_update_book(self):
        if TestApiEndpoints.book_id is None:
            self.skipTest("No books available. Skipping test.")
        updated_book = {
            "Title": "The Great Gatsby",
            "Author": "F. Scott Fitzgerald",
            "Genre": "Classic",
            "Quantity": 5,
            "CheckedOut": True,
            "ReleaseDate": "1925-04-10T00:00:00",
            "DueDate": "2024-01-10T00:00:00"
        }
        response = requests.put(f'{BASE_URL_BOOKS}/{TestApiEndpoints.book_id}', json=updated_book)
        self.print_response(response)
        self.assertEqual(response.status_code, 204)

    def test_05_delete_book(self):
        if TestApiEndpoints.book_id is None:
            self.skipTest("No books available. Skipping test.")
        response = requests.delete(f'{BASE_URL_BOOKS}/{TestApiEndpoints.book_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 204)

    # ---------- USERS API TESTS ----------

    def test_06_add_user(self):
        new_user = {
            "FirstName": "John",
            "LastName": "Doe",
            "Email": "john.doe@example.com",
            "Password": "password123",
            "Role": "Member",
            "RegisteredAt": "2024-01-01T00:00:00"
        }
        response = requests.post(BASE_URL_USERS, json=new_user)
        self.print_response(response)
        self.assertEqual(response.status_code, 201)
        TestApiEndpoints.user_id = response.json().get('id')

    def test_07_get_all_users(self):
        response = requests.get(BASE_URL_USERS)
        self.print_response(response)
        self.assertEqual(response.status_code, 200)

    def test_08_get_user_by_id(self):
        if TestApiEndpoints.user_id is None:
            self.skipTest("No users available. Skipping test.")
        response = requests.get(f'{BASE_URL_USERS}/{TestApiEndpoints.user_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 200)

    def test_09_update_user(self):
        if TestApiEndpoints.user_id is None:
            self.skipTest("No users available. Skipping test.")
        updated_user = {
            "FirstName": "Jane",
            "LastName": "Doe",
            "Email": "jane.doe@example.com",
            "Password": "newpassword456",
            "Role": "Admin",
            "RegisteredAt": "2024-01-01T00:00:00"
        }
        response = requests.put(f'{BASE_URL_USERS}/{TestApiEndpoints.user_id}', json=updated_user)
        self.print_response(response)
        self.assertEqual(response.status_code, 204)

    def test_10_delete_user(self):
        if TestApiEndpoints.user_id is None:
            self.skipTest("No users available. Skipping test.")
        response = requests.delete(f'{BASE_URL_USERS}/{TestApiEndpoints.user_id}')
        self.print_response(response)
        self.assertEqual(response.status_code, 204)

if __name__ == '__main__':
    unittest.main(verbosity=2)
