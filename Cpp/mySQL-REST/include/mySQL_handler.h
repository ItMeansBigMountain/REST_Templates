#pragma once

// IMPORT DATATYPES
#include <iostream>
#include <cstdint>
#include <string>
#include <stdio.h>

// DATABASE CONNECTORS
#include <mysql/mysql.h>

namespace learning
{

    class mySQL_handler
    {

    public:
        // QUERY OUTPUTS
        MYSQL_RES *result;
        MYSQL_ROW row;

        // DATABASE CONNECTION DETAIL STRUCTURE
        struct connection_details
        {
            const char *server, *user, *password, *database;
        };

        // CONSTRUCTORS
        mySQL_handler()
        {
            // init db details arguents
            struct connection_details db_details;
            db_details.server = "localhost";
            db_details.user = "root";
            db_details.password = "123never";
            db_details.database = "demo";

            // build connection with db
            con = mySQL_connection_setup(db_details);

            // Ensure application's table exists
            mysql_execute_query(con, "CREATE TABLE IF NOT EXISTS GameCharacters ("
                                     "id INT auto_increment,"
                                     "character_name VARCHAR(255),"
                                     "size VARCHAR(255),"
                                     "wins INT,"
                                     "primary key(id)) ");
        }

        mySQL_handler(const std::string &server, const std::string user, const std::string password, const std::string database)
        {
            // init db details arguents
            struct connection_details db_details;
            db_details.server = server.c_str();
            db_details.user = user.c_str();
            db_details.password = password.c_str();
            db_details.database = database.c_str();

            // build connection with db
            con = mySQL_connection_setup(db_details);

            // Ensure application's table exists
            mysql_execute_query(con, "CREATE TABLE IF NOT EXISTS GameCharacters ("
                                     "id INT auto_increment,"
                                     "character_name VARCHAR(255),"
                                     "size VARCHAR(255),"
                                     "wins INT,"
                                     "primary key(id)) ");
        }

        // DATABASE METHODS
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

        // CRUD METHODS
        // MYSQL_RES *AddPlayerToDb(const std::string &CharacterName, const learning::CharacterSize &Size, const int16_t &wins)
        MYSQL_RES *AddPlayerToDb(const std::string &CharacterName, const std::string &Size, const int16_t &wins)
        {
            mysql_free_result(result);

            // build query string
            std::string q = "INSERT INTO GameCharacters (character_name,size,wins) VALUES ('";
            q += CharacterName;
            q += "', '";
            q += Size;
            q += "', ";
            q += std::to_string(wins);
            q += ")";

            // execute database query
            result = mysql_execute_query(con, q.c_str());
            return result;
        }

        MYSQL_RES *UpdatePlayer(const std::string &CharacterName, const std::string &Size, const int16_t &wins, const int16_t &CharacterID)
        {
            mysql_free_result(result);

            // build query string
            std::string q = "UPDATE GameCharacters SET character_name='";
            q += CharacterName;
            q += "', size='";
            q += Size;
            q += "', wins=";
            q += std::to_string(wins);
            q += " WHERE id=";
            q += std::to_string(CharacterID);

            // query database
            result = mysql_execute_query(con, q.c_str());
            return result;
        }

        MYSQL_RES *DeletePlayer(const std::string &CharacterID)
        {
            mysql_free_result(result);

            // query database
            result = mysql_execute_query(con, "select * from books");
            return result;
        }

        MYSQL_RES *GetPlayers()
        {
            mysql_free_result(result);

            // query database
            result = mysql_execute_query(con, "select * from GameCharacters");
            return result;
        }

    private:
        MYSQL *con;
    };
}