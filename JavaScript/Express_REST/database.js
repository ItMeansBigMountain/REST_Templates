// ***********************************************************************

// DATABASE INTEGRATION
// https://expressjs.com/en/guide/database-integration.html#mysql



// MYSQL CLIENT CONNECTION example

// const mysql = require('mysql')
// const connection = mysql.createConnection({
//     host: 'localhost',
//     user: 'dbuser',
//     password: 's3kreee7',
//     database: 'my_db'
// })

// connection.connect()


// connection.query('SELECT * FROM db_table', (err, rows, fields) => {
//     if (err) throw err
// })


// connection.end()
// ***********************************************************************





var sqlite3 = require('sqlite3').verbose()
var md5 = require('md5')





// FILENAME 
const DBSOURCE = "db.sqlite"




let db = new sqlite3.Database(DBSOURCE, (err) => {
    if (err) {
        // Cannot open database
        console.error(err.message)
        throw err
    } else {
        console.log('Connected to the SQLite database.')


        // CREATING DATABASE
        db.run(`CREATE TABLE user (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name text, 
            email text UNIQUE, 
            password text, 
            CONSTRAINT email_unique UNIQUE (email)
            )`,
            (err) => {
                if (err) {
                    // Table already created
                } else {
                    // Table just created, creating some rows
                    var insert = 'INSERT INTO user (name, email, password) VALUES (?,?,?)'
                    db.run(insert, ["admin", "admin@example.com", md5("admin123456")])
                    db.run(insert, ["user", "user@example.com", md5("user123456")])
                }
            });
    }
});


module.exports = db