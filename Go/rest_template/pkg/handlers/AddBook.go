package handlers

import (
	"encoding/json"
	"io"
	"log"
	"math/rand"
	"net/http"
	"rest_template/pkg/mocks"
	"rest_template/pkg/models"
)

func AddBook(w http.ResponseWriter, req *http.Request) {
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

	// Append to the Book mocks
	book.Id = rand.Intn(100)
	mocks.Books = append(mocks.Books, book)

	// Send a 201 created response
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusCreated)
	json.NewEncoder(w).Encode(book)
}
