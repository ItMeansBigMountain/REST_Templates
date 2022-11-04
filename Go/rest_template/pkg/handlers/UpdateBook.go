package handlers

import (
	"encoding/json"
	"io"
	"log"
	"net/http"
	"rest_template/pkg/mocks"
	"rest_template/pkg/models"
	"strconv"

	"github.com/gorilla/mux"
)

func UpdateBook(w http.ResponseWriter, req *http.Request) {

	// Read to request body
	defer req.Body.Close() // defer will close the body once this function finishes
	body, err := io.ReadAll(req.Body)

	// error handling
	if err != nil {
		log.Fatalln(err)
		// return output ERROR
		w.Header().Add("Content-Type", "application/json")
		w.WriteHeader(http.StatusInternalServerError)
		json.NewEncoder(w).Encode(err)
	}

	// serializing user input into a new Book object
	var updated_book models.Book
	json.Unmarshal(body, &updated_book)

	// read dynamic url parameter
	req_variables := mux.Vars(req)
	id, _ := strconv.Atoi(req_variables["id"])

	// search database
	for i := 0; i < len(mocks.Books); i++ {
		var book = mocks.Books[i]
		// if book was found
		if book.Id == id {
			// update book
			book.Author = updated_book.Author
			book.Desc = updated_book.Desc
			book.Title = updated_book.Title
			mocks.Books[i] = book

			// return output VALID
			w.Header().Add("Content-Type", "application/json")
			w.WriteHeader(http.StatusOK)
			json.NewEncoder(w).Encode(updated_book)
			return
		}
	}

	// return output NULL-ERROR
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusNotFound)
	json.NewEncoder(w).Encode("ERROR: not found")

}
