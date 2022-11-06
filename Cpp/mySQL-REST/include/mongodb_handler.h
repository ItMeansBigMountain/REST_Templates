#pragma once

// IMPORT DATATYPES
#include <cstdint>
#include <string>

// IMPORT LIBRARIES
#include "bsoncxx/builder/stream/document.hpp"
#include "bsoncxx/json.hpp"
#include "bsoncxx/oid.hpp"

#include "mongocxx/client.hpp"
#include "mongocxx/database.hpp"
#include "mongocxx/uri.hpp"

namespace learning
{
    constexpr char kMongoDB_uri[] = "mongodb://172.64.0.1:27017";
    constexpr char kMongoDB_database_name[] = "learning_mongocxx";
    constexpr char kMongoDB_collection_name[] = "GameCharacters";

    class MongoDBHandler
    {

    public:
        // CONSTRUCTOR
        MongoDBHandler() : uri(mongocxx::uri(kMongoDB_uri)),
                           client(mongocxx::client(uri)),
                           db(client[kMongoDB_database_name]) {}

        // METHODS
        bool AddPlayerToDb(const std::string &CharacterName, const std::string &Size, const int16_t &wins)
        {

            mongocxx::collection collection = db[kMongoDB_collection_name];
            auto builder = bsoncxx::builder::stream::document{};

            bsoncxx::document::value doc_to_add =
                builder << "characterName" << CharacterName
                        << "size" << Size
                        << "wins" << wins << bsoncxx::builder::stream::finalize;

            collection.insert_one(doc_to_add.view());

            std::string rawResult = bsoncxx::to_json(doc_to_add.view());
            // std::cout << doc_to_add.view()  << std::endl;

            return true;
        }

        bool UpdatePlayerWins(const std::string &CharacterID)
        {
            return true;
        }

        bool DeletePlayer(const std::string &CharacterID)
        {
            return true;
        }

    private:
        mongocxx::uri uri;
        mongocxx::client client;
        mongocxx::database db;
    };
}