// IGNORE WARNINGS
// #pragma warning (disable : 4820 4619 4668)


// APPLICATION DEPENDENCIES
#include <iostream>
#include "mySQL_handler.h"
#include "Character_Size.h"



// HTTP SERVER DEPENDENCIES
#include "served/multiplexer.hpp"
#include "http_server.h"


int main()
{
    learning::mySQL_handler h;

    // ADD PLAYERS
    // h.AddPlayerToDb("Donkey Kong", learning::CharacterSize::kLarge, 0);
    // h.AddPlayerToDb("Ghost", "small", 5);

    // UPDATE PLAYERS
    // h.UpdatePlayer("luigi", "medium", 0, 5 );

    // DELETE PLAYERS
    // h.DeletePlayer(6);

    // RETRIEVE PLAYERS
    // h.QueryPlayers();

    // DISPLAY OUTPUT
    // std::cout << "QUERY OUTPUT: " << std::endl;
    // while ((h.row = mysql_fetch_row(h.result)) != NULL)
    // {
    //     std::cout << h.row[0] << " | " << h.row[1] << " | " << h.row[2] << " | " << h.row[3] << " | " << std::endl;
    // }


    // JSON TESTING
    // std::cout << h.getAllPlayers()["Players"] << std::endl;



    // SERVER DRIVER CODE
    served::multiplexer multiplexer;
    learning::HttpServer http_server(multiplexer);

    http_server.initialize_endpoints();
    http_server.start_server();





}
