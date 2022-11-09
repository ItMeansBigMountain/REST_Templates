#pragma once

// IMPORT DATATYPES
#include <iostream>
#include <string>

// JSON AND SERVER DEPENDENCIES
#include "SimpleJSON/json.hpp"
#include "served/multiplexer.hpp"
#include "served/net/server.hpp"

// DATABASE HANDLER
#include "mySQL_handler.h"

namespace learning
{

    // ENDPOINT URLS
    constexpr char k_Create_Endpoint[] = "/add";
    constexpr char k_Retrieve_Endpoint[] = "/get";
    constexpr char k_Update_Endpoint[] = "/update";
    constexpr char k_Delete_Endpoint[] = "/delete";

    // SERVER HOST DETAILS
    constexpr char k_IP_Address[] = "0.0.0.0";
    constexpr char k_PORT[] = "5000";

    // MAX THREADS
    constexpr int k_threads = 10;

    class HttpServer
    {
    public:
        // LAMBDA ENDPOINT FUNCTIONALITY
        auto CreatePlayerEndpoint()
        {
            return [&](served::response &response, const served::request &request)
            {
                // read body of request
                json::JSON request_body = json::JSON::Load(request.body());

                // take fields from body needed to create db object
                std::cout << request_body << std::endl;

                // use mySQL_handler.hpp to add to database
                h.AddPlayerToDb(
                    request_body['name'].ToString(),
                    request_body['size'].ToString(),
                    request_body['wins'].ToInt());

                // return bool if insert was successfull or not
                served::response::stock_reply(200, response);
            };
        };
        auto RetrievePlayerEndpoint()
        {
            return [&](served::response &response, const served::request &request)
            {
                // read body of request
                json::JSON request_body = json::JSON::Load(request.body());

                // take fields from body needed to create db object
                std::cout << request_body << std::endl;

                // return all items from table
                json::JSON all_rows = h.getAllPlayers();
                std::ostringstream stream;
                stream << all_rows;
                response << stream.str();
            };
        };
        auto UpdatePlayerEndpoint()
        {
            return [&](served::response &response, const served::request &request)
            {
                // read body of request
                json::JSON request_body = json::JSON::Load(request.body());

                // take fields from body needed to create db object
                std::cout << request_body << std::endl;

                // use mySQL_handler.hpp to add to database
                h.UpdatePlayer(
                    request_body['name'].ToString(),
                    request_body['size'].ToString(),
                    request_body['wins'].ToInt(),
                    request_body["id"].ToInt());

                // return bool if insert was successfull or not
                served::response::stock_reply(200, response);
            };
        };
        auto DeletePlayerEndpoint()
        {
            return [&](served::response &response, const served::request &request)
            {
                // read body of request
                json::JSON request_body = json::JSON::Load(request.body());

                // take fields from body needed to create db object
                std::cout << request_body << std::endl;

                // use mySQL_handler.hpp to add to database
                h.DeletePlayer(request_body["id"].ToInt());

                // return bool if insert was successfull or not
                served::response::stock_reply(200, response);
            };
        };

        HttpServer(served::multiplexer multiplexer) :  multiplexer(multiplexer){};

        // MAP ENDPOINT STRINGS TO LAMBDA FUNCTIONS
        void initialize_endpoints()
        {
            multiplexer.handle(k_Create_Endpoint).post(CreatePlayerEndpoint());
            multiplexer.handle(k_Retrieve_Endpoint).get(RetrievePlayerEndpoint());
            multiplexer.handle(k_Update_Endpoint).put(UpdatePlayerEndpoint());
            multiplexer.handle(k_Delete_Endpoint).del(DeletePlayerEndpoint());
        }

        void start_server()
        {
            // server driver code
            std::cout << "RUNNING SERVER \n PORT: " << k_PORT << std::endl;
            served::net::server server(k_IP_Address, k_PORT, multiplexer);
            server.run(k_threads);
        }

    private:
        served::multiplexer multiplexer;
        learning::mySQL_handler h;
    };
}
