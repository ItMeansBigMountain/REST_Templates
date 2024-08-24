import requests


# GET Request - Get all users
r = requests.get("http://127.0.0.1:5221/api/UserAccounts")
print("GET All Users Response:", r.status_code, r.json())



# GET Request - Get a user by ID
# pk = 7
# r = requests.get(f"http://127.0.0.1:5221/api/UserAccounts/{pk}")
# print("GET User by ID Response:", r.status_code, r.json())







# POST Request - Add a New User
# data = {
#     "FirstName": "Affan",
#     "LastName": "Sosai",
#     "Email": "john.doe@example.com",
#     "Password": "password123",
#     "Role": "Admin",
#     "RegisteredAt": "2024-01-01T00:00:00"
# }
# r = requests.post("http://127.0.0.1:5221/api/UserAccounts", json=data)
# print("POST Response:", r.status_code, r.json())






# # PUT Request - Update an Existing User
# pk = 7
# payload = {
#     "FirstName": "Sosai",
#     "LastName": "Oyama",
#     "Email": "sosai.oyama@example.com",
#     "Password": "newpassword456",
#     "Role": "Sensei",
#     "RegisteredAt": "2024-01-01T00:00:00"
# }
# r = requests.put(f"http://127.0.0.1:5221/api/UserAccounts/{pk}", json=payload)
# print("PUT Response:", r.status_code)






# DELETE Request - Delete a User
# pk = 8
# r = requests.delete(f"http://127.0.0.1:5221/api/UserAccounts/{pk}")
# print("DELETE Response:", r.status_code)
