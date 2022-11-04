package handlers

import (
	"encoding/json"
	"net/http"
	"rest_template/pkg/mocks"
	"strconv"

	"github.com/gorilla/mux"
)

func GetBook(w http.ResponseWriter, req *http.Request) {

	// read dynamic url parameter
	req_variables := mux.Vars(req)
	id, _ := strconv.Atoi(req_variables["id"])

	// fetch book with matching id
	for i := 0; i < len(mocks.Books); i++ {
		var book = mocks.Books[i]
		if book.Id == id {
			// return output VALID
			w.Header().Add("Content-Type", "application/json")
			w.WriteHeader(http.StatusOK)
			json.NewEncoder(w).Encode(book)
			return
		}
	}
	// return output NULL-ERROR
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusNotFound)
	json.NewEncoder(w).Encode("ERROR: not found")
}
