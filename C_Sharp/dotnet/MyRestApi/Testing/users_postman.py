import requests

BASE_URL = "http://127.0.0.1:5221/api/UserAccounts"

def create_user(data):
    response = requests.post(BASE_URL, json=data)
    print("\n🚀 [POST] Create User")
    print("🔍 Status Code:", response.status_code)
    if response.status_code == 201:
        print("✅ Response JSON:", response.json())
    else:
        print("❌ Error:", response.text)
    return response.json().get('id')

def get_all_users():
    response = requests.get(BASE_URL)
    print("\n📚 [GET] All Users")
    print("🔍 Status Code:", response.status_code)
    if response.status_code == 200:
        print("✅ Response JSON:", response.json())
    else:
        print("❌ Error:", response.text)
    return response.json()

def get_user_by_id(user_id):
    response = requests.get(f"{BASE_URL}/{user_id}")
    print(f"\n🔍 [GET] User by ID: {user_id}")
    print("🔍 Status Code:", response.status_code)
    if response.status_code == 200:
        print("✅ Response JSON:", response.json())
    else:
        print("❌ Error:", response.text)
    return response.json()

def update_user(user_id, payload):
    response = requests.put(f"{BASE_URL}/{user_id}", json=payload)
    print(f"\n🔄 [PUT] Update User ID: {user_id}")
    print("🔍 Status Code:", response.status_code)
    if response.status_code == 204:
        print("✅ User updated successfully.")
    else:
        print("❌ Error:", response.text)

def delete_user(user_id):
    response = requests.delete(f"{BASE_URL}/{user_id}")
    print(f"\n🗑️ [DELETE] User ID: {user_id}")
    print("🔍 Status Code:", response.status_code)
    if response.status_code == 204:
        print("✅ User deleted successfully.")
    else:
        print("❌ Error:", response.text)

if __name__ == "__main__":
    # Data for the new user
    user_data = {
        "FirstName": "trapistan",
        "LastName": "zindabad",
        "Email": "john.doe@example.com",
        "Password": "password123",
        "Role": "User",
        "RegisteredAt": "2024-01-01T00:00:00"
    }

    # Create a new user
    user_id = create_user(user_data)

    # Get all users
    get_all_users()

    # Get the newly created user by ID
    get_user_by_id(user_id)

    # Update the user
    updated_data = {
        "FirstName": "trapin",
        "LastName": "dachi",
        "Email": "sosai.oyama@example.com",
        "Password": "newpassword456",
        "Role": "Admin",
        "RegisteredAt": "2024-01-01T00:00:00"
    }
    update_user(user_id, updated_data)

    # Delete the user
    delete_user(user_id)
