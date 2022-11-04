package handlers

import (
	"encoding/json"
	"net/http"
	"rest_template/pkg/mocks"
)

// METHOD PARAMETERS ARE RESPONSE & REQUEST
func GetAllBooks(w http.ResponseWriter, req *http.Request) {
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)

	//returning mocks data item
	json.NewEncoder(w).Encode(mocks.Books)
}
