package models

// OBJECT MODEL
type Book struct {
	Id     int    `json:"id" gorm:"PrimaryKey"`
	Title  string `json:"title"`
	Author string `json:"author"`
	Desc   string `json:"desc"`
}
