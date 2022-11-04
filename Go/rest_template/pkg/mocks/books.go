package mocks

import "rest_template/pkg/models"

var Books = []models.Book{
	{
		Id:     1,
		Title:  "Rest Test",
		Author: "itMeansBigMountain",
		Desc:   "This is a template for goLang REST APIs",
	},
}
