#include <iostream>
#include <mysql/mysql.h>

struct connection_details
{
    const char *server, *user, *password, *database;
};

// INIT CONNECTION
MYSQL *mySQL_connection_setup(struct connection_details connection_details_param)
{
    // CONNECT TO MYSQL
    MYSQL *connection = mysql_init(NULL);

    // CONNECTION ERROR HANDLING
    if (!mysql_real_connect(connection, connection_details_param.server, connection_details_param.user, connection_details_param.password, connection_details_param.database, 0, NULL, 0))
    {
        std::cout << "CONNECTION ERROR: " << mysql_error(connection) << std::endl;
        exit(1);
    }

    return connection;
}

// QUERY DATABASE
MYSQL_RES *mysql_execute_query(MYSQL *connection, const char *sql_query)
{

    // QUERY ERROR HANDLING
    if (mysql_query(connection, sql_query))
    {
        std::cout << "SQL QUERY ERROR: " << mysql_error(connection) << std::endl;
        exit(1);
    }

    return mysql_use_result(connection);
}

int main(int argc, char const *argv[])
{
    // DECLARING VARIABLES
    MYSQL *con;
    MYSQL_RES *result;
    MYSQL_ROW row;

    // init db details arguents
    struct connection_details db_details;
    db_details.server = "localhost";
    db_details.user = "root";
    db_details.password = "123never";
    db_details.database = "demo";

    // build connection with db
    con = mySQL_connection_setup(db_details);

    // query database
    result = mysql_execute_query(con, "select * from books");

    // OUTPUT
    std::cout << "QUERY OUTPUT: " << std::endl;
    while ((row = mysql_fetch_row(result)) != NULL)
    {
        std::cout << row[0] << " | " << row[1] << " | " << row[2] << " | " << row[3] << " | " << std::endl;
    }

    // CLEAN UP 
    mysql_free_result(result);
    mysql_close(con);
}
