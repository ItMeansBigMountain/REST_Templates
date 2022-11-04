package handlers

import (
	"net/http"
)

func Home(w http.ResponseWriter, req *http.Request) {
	// perform a db.Query
	insert, err := db.Query("select * from tbl_users")

	// if there is an error inserting, handle it
	if err != nil {
		panic(err.Error())
	}
	// be careful deferring Queries if you are using transactions
	defer insert.Close()
}
