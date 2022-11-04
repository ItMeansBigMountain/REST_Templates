package main

import (
	"database/sql"
	"log"
	"net/http"
	"rest_template/pkg/handlers"

	"github.com/gorilla/mux"
)

func main() {
	// INIT HTTP OJECTS
	router := mux.NewRouter()

	// INIT mySQL object
	db, SQL_err := sql.Open("mysql", "root:123never@tcp(127.0.0.1:3306)/demo")
	if SQL_err != nil {
		panic(SQL_err.Error())
	}

	// defer the close till after the main function has finished
	// executing
	defer db.Close()

	// ENDPOINTS
	router.HandleFunc("/", handlers.Home).Methods(http.MethodGet)
	router.HandleFunc("/books", handlers.GetAllBooks).Methods(http.MethodGet)
	router.HandleFunc("/books", handlers.AddBook).Methods(http.MethodPost)
	router.HandleFunc("/books/{id}", handlers.GetBook).Methods(http.MethodGet)
	router.HandleFunc("/books/{id}", handlers.UpdateBook).Methods(http.MethodPut)
	router.HandleFunc("/books/{id}", handlers.DeleteBook).Methods(http.MethodDelete)

	// RUN DRIVER CODE
	log.Println("API is running!")
	http.ListenAndServe(":4000", router)
}
