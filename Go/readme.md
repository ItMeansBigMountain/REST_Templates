
# INITIALIZE MODULE IN GO
-    go mod init PROJECT_NAME




# ADD REMOTE MODULE AS DEPENDENCY
    go get GIT_URL

    EXAMPLE: 
        go get https://github.com/gorilla/mux.git





# SQL LIBRARY DEPENDENCY
    db, SQL_err := sql.Open("DATABASE_ENGINE", "username:password@tcp(127.0.0.1:3306)/SCHEMA")
    
    EXAMPLE:
        db, SQL_err := sql.Open("mysql", "root:123never@tcp(127.0.0.1:3306)/demo")



# GO [ORM] 
    Object-Relational Mapping (ORM) is a technique that lets you query and manipulate data from a database using an object-oriented paradigm.



# DOWNLOAD ORM DEPENDENCIES
        - go get -u gorm.io/gorm
        - go get -u gorm.io/driver/mysql


# DOCUMENTATION FOR mysql
        https://gorm.io/docs/connecting_to_the_database.html






# POINTERS AND DEREFRENCE OPERATORS (& and *) 

    & - when placed in front of a variable, 
        this is talking about the memory location (pointer)

    * - when placed in front of a variable,
        changing the pointer stop referencing whatever it used to

            "within local scope of a function, you may change the memory location's value which will act like changing the global value of the variable"





# DEPENDENCY INJECTION
    we cannot keep recreating a variable (like the db connection) every time a file is referenced (endpoint handler)
        therefore we use DEPENDENCY INJECTION

    - create a handler struct

    - extend functions with handler struct (look at AddBook.go for reference)

    - on main.go , init the database object, then pass into handler struct that you also init

    - change route function calls into handler_struct's child function extention 

