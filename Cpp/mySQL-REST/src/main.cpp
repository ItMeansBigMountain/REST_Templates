#include <iostream>

// APPLICATION HELPERS
#include "mySQL_handler.h"
#include "Character_Size.h"

int main()
{
    learning::mySQL_handler h;

    // ADD PLAYERS
    // h.AddPlayerToDb("Donkey Kong", learning::CharacterSize::kLarge, 0);
    h.AddPlayerToDb("Ghost", "small", 5);

    // RETRIEVE PLAYERS
    h.GetPlayers();

    // UPDATE PLAYERS
    // h.UpdatePlayer()

    // DELETE PLAYERS
    // h.DeletePlayer()

    // DISPLAY OUTPUT
    std::cout << "QUERY OUTPUT: " << std::endl;
    while ((h.row = mysql_fetch_row(h.result)) != NULL)
    {
        std::cout << h.row[0] << " | " << h.row[1] << " | " << h.row[2] << " | " << h.row[3] << " | " << std::endl;
    }
}
