# VS CODE EXTENTION PROJECT SETUP
- easy cpp extention 
- CTRL + P ---> "easy cpp"
- select create new project
- choose os system you choose to optamizing project complication in
- make sure to add path to libraries you wish to include



# mySQL Connector Includes in main.cpp
- have mysql cli installed

- have mysql.h in the includes
    - apt-get install libmysqlclient-dev 
    - verify that you have ---> /usr/include/mysql

- now you may add to the includes in main.cpp

run app using
    - g++ main.cpp -o output -L/usr/include/mysql/mysql -lmysqlclient && ./output








# INIT CONTAINER ON UBUNTU
- spin up docker container that runs mongoDB
- write "docker-compose up"




# Run Project (no docker)
- write: "make run"




# setup-mongocss.sh
- bash script to set up "Mongo-Cxx" Library in order to connect a MongoDB instance
- may need to run setup as sudo or give permissions "chmod +x setup-mongocss.sh"



