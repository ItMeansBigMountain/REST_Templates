package handlers

import (
	"encoding/json"
	"fmt"
	"io"
	"log"
	"net/http"
	"rest_template/pkg/models"
)

func (h handler) AddBook(w http.ResponseWriter, req *http.Request) {
	// Read to request body
	defer req.Body.Close() // defer will close the body once this function finishes
	body, err := io.ReadAll(req.Body)

	// error handling
	if err != nil {
		log.Fatalln(err)
	}

	// serializing user input into Book object
	var book models.Book
	json.Unmarshal(body, &book)

	// Add new Object into database
	result := h.DB.Create(&book)

	// ERROR HANDLING
	if result.Error != nil {
		fmt.Println(result.Error)
	}

	// Send a 201 created response
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(book)
}
