package handlers

import (
	"encoding/json"
	"fmt"
	"net/http"
	"rest_template/pkg/models"
	"strconv"

	"github.com/gorilla/mux"
)

func (h handler) GetBook(w http.ResponseWriter, req *http.Request) {

	// read dynamic url parameter
	req_variables := mux.Vars(req)
	id, _ := strconv.Atoi(req_variables["id"])

	// model datatype of queried item
	var book models.Book

	// SEARCH QUERY DATABASE with id
	result := h.DB.First(&book, id)

	// ERROR DETECTION
	if result.Error != nil {
		fmt.Println(result.Error)
	}

	// return output VALID
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode(book)
}
