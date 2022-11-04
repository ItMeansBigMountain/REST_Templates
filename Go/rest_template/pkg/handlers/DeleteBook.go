package handlers

import (
	"encoding/json"
	"net/http"
	"rest_template/pkg/mocks"
	"strconv"

	"github.com/gorilla/mux"
)

func DeleteBook(w http.ResponseWriter, req *http.Request) {

	// read dynamic url parameter
	req_variables := mux.Vars(req)
	id, _ := strconv.Atoi(req_variables["id"])

	// search database
	for i := 0; i < len(mocks.Books); i++ {
		var book = mocks.Books[i]
		// if book was found
		if book.Id == id {
			// Delete book
			mocks.Books = append(mocks.Books[:i], mocks.Books[i+1:]...)

			// return output VALID
			w.Header().Add("Content-Type", "application/json")
			w.WriteHeader(http.StatusOK)
			json.NewEncoder(w).Encode(book)
			return
		}
	}

}
