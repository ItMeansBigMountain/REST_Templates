package org.REST.Service;


import org.REST.Entity.User;

import java.util.List;

public interface UserService {
    List<User> getAllUsers();

    User getUserById(int requested_Course_ID);

    User addUser(User c);

    List<User> updateUser(User c);

    List<User> deleteUser(int id);
}