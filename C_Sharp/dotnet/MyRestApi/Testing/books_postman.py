import requests

BASE_URL = "http://127.0.0.1:5221/api/BooksLibrary"

def create_book(data):
    response = requests.post(BASE_URL, json=data)
    print("\n🚀 [POST] Create Book")
    if response.status_code == 201:
        print("✅ Book Created Successfully")
        print("📄 Response:", response.status_code)
        print("📚 Book Details:", response.json())
    else:
        print("❌ Failed to Create Book")
        print("📄 Response:", response.status_code)
        print("🔍 Error:", response.text)
    return response.json().get('id')

def update_book(book_id, updated_data):
    response = requests.put(f"{BASE_URL}/{book_id}", json=updated_data)
    print(f"\n🔄 [PUT] Update Book ID: {book_id}")
    if response.status_code == 204:
        print(f"✅ Book ID {book_id} Updated Successfully")
    else:
        print(f"❌ Failed to Update Book ID {book_id}")
        print("📄 Response:", response.status_code)
        print("🔍 Error:", response.text)

def get_book_by_id(book_id):
    response = requests.get(f"{BASE_URL}/{book_id}")
    print(f"\n🔍 [GET] Book by ID: {book_id}")
    if response.status_code == 200:
        print(f"✅ Retrieved Book ID {book_id}")
        print("📄 Response:", response.status_code)
        print("📚 Book Details:", response.json())
    else:
        print(f"❌ Failed to Retrieve Book ID {book_id}")
        print("📄 Response:", response.status_code)
        print("🔍 Error:", response.text)
    return response.json()

def delete_book(book_id):
    response = requests.delete(f"{BASE_URL}/{book_id}")
    print(f"\n🗑️ [DELETE] Book ID: {book_id}")
    if response.status_code == 204:
        print(f"✅ Book ID {book_id} Deleted Successfully")
    else:
        print(f"❌ Failed to Delete Book ID {book_id}")
        print("📄 Response:", response.status_code)
        print("🔍 Error:", response.text)

def get_all_books():
    response = requests.get(BASE_URL)
    print("\n📚 [GET] All Books")
    if response.status_code == 200:
        print("✅ Retrieved All Books")
        print("📄 Response:", response.status_code)
        print("📚 Books List:", response.json())
    else:
        print("❌ Failed to Retrieve All Books")
        print("📄 Response:", response.status_code)
        print("🔍 Error:", response.text)
    return response.json()

if __name__ == "__main__":
    # Define the book data
    book_data = {
        "Title": "The Great Gatsby",
        "Author": "F. Scott Fitzgerald",
        "Genre": "Classic",
        "Quantity": 10,
        "CheckedOut": False,
        "ReleaseDate": "1925-04-10T00:00:00",
        "DueDate": "2024-01-01T00:00:00"
    }

    # Create a new book
    book_id = create_book(book_data)

    # Update the book
    updated_data = {
        "Title": "The Great Gatsby",
        "Author": "F. Scott Fitzgerald",
        "Genre": "Classic",
        "Quantity": 5,
        "CheckedOut": True,
        "ReleaseDate": "1925-04-10T00:00:00",
        "DueDate": "2024-01-10T00:00:00"
    }
    update_book(book_id, updated_data)

    # Get the updated book by ID
    get_book_by_id(book_id)

    # Delete the book
    delete_book(book_id)

    # Get all books
    get_all_books()
