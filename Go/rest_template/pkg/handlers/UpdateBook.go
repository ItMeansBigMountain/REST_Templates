package handlers

import (
	"encoding/json"
	"fmt"
	"io"
	"log"
	"net/http"
	"rest_template/pkg/models"
	"strconv"

	"github.com/gorilla/mux"
)

func (h handler) UpdateBook(w http.ResponseWriter, req *http.Request) {

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

	// read dynamic url parameter
	req_variables := mux.Vars(req)
	id, _ := strconv.Atoi(req_variables["id"])

	// Find object in database
	var book models.Book
	queried_book_result := h.DB.First(&book, id)
	// ERROR HANDLING
	if queried_book_result.Error != nil {
		fmt.Println(queried_book_result.Error)
	}

	// serializing user input into a new Book object
	var updated_book models.Book
	json.Unmarshal(body, &updated_book)

	//  UPDATE OBJECT
	book.Title = updated_book.Title
	book.Author = updated_book.Author
	book.Desc = updated_book.Desc

	// SAVE INTO DATABASE AS UPDATED
	result := h.DB.Save(&book)
	// ERROR HANDLING
	if result.Error != nil {
		fmt.Println(result.Error)
	}

	// return output VALID
	w.Header().Add("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode(book)

}
