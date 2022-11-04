package handlers

import (
	"encoding/json"
	"fmt"
	"net/http"
	"rest_template/pkg/models"
)

// METHOD PARAMETERS ARE RESPONSE & REQUEST
func (h handler) GetAllBooks(w http.ResponseWriter, req *http.Request) {
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)

	// FETCH ALL BOOKS FROM DB
	var books []models.Book
	result := h.DB.Find(&books)

	// ERROR HANDLING
	if result.Error != nil {
		fmt.Println(result.Error)
	}

	//returning mocks data item
	json.NewEncoder(w).Encode(books)
}
