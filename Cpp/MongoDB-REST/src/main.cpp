#include <iostream>

#include "mongocxx/instance.hpp"

#include "mongodb_handler.h"
#include "Character_Size.h"

int main()
{
    mongocxx::instance instance;
    learning::MongoDBHandler mhandler;


    // mhandler.AddPlayerToDb( "Donkey Kong" , learning::CharacterSize::kLarge  , 0  );
    mhandler.AddPlayerToDb("Donkey Kong", "Large", 0);

}