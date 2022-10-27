const express = require("express")
const cors = require("cors")
var db = require("./database.js")
var md5 = require("md5")


// ***********************************************************************
// DATABASE INTEGRATION
// https://expressjs.com/en/guide/database-integration.html#mysql

// CREATE 'database.js' file in directory
// ***********************************************************************




// INIT EXPRESS.js VARIABLES
const app = express()
const PORT = process.env.PORT || 8000
app.use(cors())







// INCOMMING REQUESTS ARGUMENTS BODY PARAMETER READING [middlewear]
// body-parser will convert this string to a javascript object
var bodyParser = require("body-parser");
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());




// BROWSER PREFLIGHT CHECK [CORS] [middlewear]
app.options("*", (req, res, next) => {
    res.header("Access-Control-Allow-Origin", "*")
    res.header("Access-Control-Allow-Methods", "GET, PUT, POST, OPTIONS, DELETE, PATCH, HEAD")
    res.header("Access-Control-Allow-Headers", "Authorization, Content-Length, X-Requested-With")
    res.send(200)
})



// APPLY JSON FORMAT [middlewear]
app.use(express.json())
app.use(express.urlencoded({ extended: false }))





// LOGGER [middlewear]
app.use((req, res, next) => {
    console.log(`${req.method}  ${req.path} - ${req.ip}  `);
    next()
})








// ENDPOINTS


// homepage
app.get("/", (req, res) => {
    res.send("welcome! This was made using Express.js")
})



// echo url path variable (:word)
app.get("/:word/echo", (req, res) => {
    res.json({ "echo": req.params.word })
})





// fetch all users
app.get("/users", (req, res, next) => {
    var sql = "select * from user"
    var params = []
    db.all(sql, params, (err, rows) => {
        if (err) {
            res.status(400).json({ "error": err.message });
            return;
        }
        res.json({
            "message": "success",
            "data": rows
        })
    });
});









// fetch specific users
app.get("/users/:id", (req, res, next) => {
    var sql = "select * from user where id = ?"
    var params = [req.params.id]
    db.get(sql, params, (err, row) => {
        if (err) {
            res.status(400).json({ "error": err.message });
            return;
        }
        res.json({
            "message": "success",
            "data": row
        })
    });
});









// create users
app.post("/user/", (req, res, next) => {

    // VALIDATE REQUEST.ARGUMENT ERRORS
    var errors = []
    if (!req.body.password) {
        errors.push("No password specified");
    }
    if (!req.body.email) {
        errors.push("No email specified");
    }
    if (errors.length) {
        res.status(400).json({ "error": errors.join(",") });
        return;
    }

    // BUILD DATA OBJECT QUERY INTO DATABASE
    var data = {
        name: req.body.name,
        email: req.body.email,
        password: md5(req.body.password)
    }
    var sql = 'INSERT INTO user (name, email, password) VALUES (?,?,?)'
    var params = [data.name, data.email, data.password]


    // EXECUTE SQL QUERY
    db.run(sql, params,
        function (err, result) {
            if (err) {
                res.status(400).json({ "error": err.message })
                return;
            }
            // RETURN RESPONSE OUTPUT
            res.json({
                "message": "success",
                "data": data,
                "id": this.lastID
            })
        });
})














// update users
app.patch("/user/:id", (req, res, next) => {

    // BUILD DATABASE MODEL OBJECT
    var data = {
        name: req.body.name,
        email: req.body.email,
        password: req.body.password ? md5(req.body.password) : null
    }

    // EXECUTE SQL QUERY
    db.run(
        `UPDATE user set 
           name = COALESCE(?,name), 
           email = COALESCE(?,email), 
           password = COALESCE(?,password) 
           WHERE id = ?`,
        [data.name, data.email, data.password, req.params.id],

        // RETURN RESPONSE OUTPUT
        function (err, result) {
            if (err) {
                res.status(400).json({ "error": res.message })
                return;
            }
            res.json({
                message: "success",
                data: data,
                changes: this.changes
            })
        });
})













// delete user
app.delete("/user/:id", (req, res, next) => {

    // BUILD SQL QUERY
    db.run(
        'DELETE FROM user WHERE id = ?',
        req.params.id,

        // RETURN RESPONSE OUTPUT
        function (err, result) {
            if (err) {
                res.status(400).json({ "error": res.message })
                return;
            }
            res.json({ "message": "deleted", changes: this.changes })
        });

})






















// CATCH ALL INVALID ROUTES
app.get("*", (req, res) => {
    res.json({ "error": "Invalid URL route" })
    res.status(404)
})




// RUN DRIVER CODE
app.listen(PORT, () => { console.log(`Listening on ${PORT}`) })