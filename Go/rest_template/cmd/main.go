package main

import (
	"log"
	"net/http"
	"rest_template/pkg/db"
	"rest_template/pkg/handlers"

	"github.com/gorilla/mux"
)

func main() {
	// INIT HTTP OJECTS
	router := mux.NewRouter()

	// INIT mySQL object
	DataBase := db.Init()
	H := handlers.Create(DataBase)

	// ENDPOINTS
	router.HandleFunc("/books", H.GetAllBooks).Methods(http.MethodGet)
	router.HandleFunc("/books", H.AddBook).Methods(http.MethodPost)
	router.HandleFunc("/books/{id}", H.GetBook).Methods(http.MethodGet)
	router.HandleFunc("/books/{id}", H.UpdateBook).Methods(http.MethodPut)
	router.HandleFunc("/books/{id}", H.DeleteBook).Methods(http.MethodDelete)

	// RUN DRIVER CODE
	log.Println("API is running!")
	http.ListenAndServe(":4000", router)
}
