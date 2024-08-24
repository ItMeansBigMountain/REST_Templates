import requests

# GET Request - Get all books
# r = requests.get("http://127.0.0.1:5221/api/BooksLibrary")
# print("GET All Books Response:", r.status_code, r.json())




# # GET Request - Get a book by ID
# pk = 3  # Replace with the ID of the book you want to retrieve
# r = requests.get(f"http://127.0.0.1:5221/api/BooksLibrary/{pk}")
# print("GET Book by ID Response:", r.status_code, r.json())


# # POST Request - Add a New Book
data = {
    "Title": "The Great Gatsby",
    "Author": "F. Scott Fitzgerald",
    "Genre": "Classic",
    "Quantity": 10,
    "CheckedOut": False,
    "ReleaseDate": "1925-04-10T00:00:00",
    "DueDate": "2024-01-01T00:00:00"
}
r = requests.post("http://127.0.0.1:5221/api/BooksLibrary", json=data)
print("POST Response:", r.status_code, r.json())

# # PUT Request - Update an Existing Book
# pk = 3  # Replace with the ID of the book you want to update
# payload = {
#     "Title": "The Great Gatsby",
#     "Author": "F. Scott Fitzgerald",
#     "Genre": "Classic",
#     "Quantity": 5,
#     "CheckedOut": True,
#     "ReleaseDate": "1925-04-10T00:00:00",
#     "DueDate": "2024-01-10T00:00:00"
# }
# r = requests.put(f"http://127.0.0.1:5221/api/BooksLibrary/{pk}", json=payload)
# print("PUT Response:", r.status_code, r.json())

# # DELETE Request - Delete a Book
# pk = 3  # Replace with the ID of the book you want to delete
# r = requests.delete(f"http://127.0.0.1:5221/api/BooksLibrary/{pk}")
# print("DELETE Response:", r.status_code)
