package db

import (
	"log"
	"rest_template/pkg/models"

	"gorm.io/driver/mysql"
	"gorm.io/gorm"
)

func Init() *gorm.DB {
	dbURL := "root:123never@tcp(127.0.0.1:3306)/demo"
	db, err := gorm.Open(mysql.Open(dbURL), &gorm.Config{})

	if err != nil {
		log.Fatal(err)
	}

	db.AutoMigrate(&models.Book{})

	return db

}
