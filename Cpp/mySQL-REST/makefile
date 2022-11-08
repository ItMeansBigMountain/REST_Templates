CXX := g++
CXX_FLAGS := -Wall -Wextra -std=c++17 -ggdb
INCLUDE	:= -Iinclude -Ilib


BIN := bin
SRC := src/*.cpp $(shell find $(lib) -name *.cpp)




LIB := /usr/include/mysql/mysql
LIBRARIES := -lmysqlclient
EXECUTABLE := main

all: $(BIN)/$(EXECUTABLE)

run: clean all
	clear
	./$(BIN)/$(EXECUTABLE)

$(BIN)/$(EXECUTABLE): $(SRC)
	$(CXX) $(CXX_FLAGS) $(INCLUDE) -L$(LIB) $^ -o $@ $(LIBRARIES)


clean:
	-rm $(BIN)/*