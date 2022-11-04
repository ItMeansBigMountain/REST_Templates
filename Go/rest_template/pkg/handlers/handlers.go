package handlers

import "gorm.io/gorm"

type handler struct {
	DB *gorm.DB
}

func Create(db *gorm.DB) handler {
	return handler{db}
}
