# DEMO IS USING db.sqlite3


# make sure to run
- npm init

# PACKAGES
- npm install express
- npm install cors
- npm install sqlite3
- npm install md5
- npm install nodemon -D


# run file in developer mode
- nodemon index.js


# TESTING
- POST (create): curl -d "name=test&email=test%40example.com&password=test123" -X POST http://localhost:8000/user/


- PATCH (update): curl -d "name=test&email=imthebest%40example.com&password=test123" -X PATCH http://localhost:8000/user/1


- DELETE:  curl -d "name=test&email=imthebest%40example.com&password=test123" -X DELETE http://localhost:8000/user/3
