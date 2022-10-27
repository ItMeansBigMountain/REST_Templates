package org.REST.Service;


import org.REST.Dao.User_Dao;
import org.REST.Entity.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class UserImplementation implements UserService {
    @Autowired
    private User_Dao userDao;


    @Override // GET --> /courses
    public List<User> getAllUsers() {
        return this.userDao.findAll();
    }


    @Override // GET --> /courses/{id}
    public User getUserById(int requested_Course_ID) {
        Optional<User> obj = this.userDao.findById(requested_Course_ID);
        if (obj.isEmpty()) {
            return null;
        }
        return obj.get();
    }


    @Override  // POST --> /courses
    public User addUser(User obj) {
        return this.userDao.save(obj);
    }

    @Override // PUT --> /courses
    public List<User> updateUser(User obj) {
        Optional<User> q = this.userDao.findById(obj.getId());
        if (q.isPresent()) {
            this.userDao.save(obj);
            return this.userDao.findAll();
        }
        return null;
    }

    @Override  // DELETE --> /courses/{id}
    public List<User> deleteUser(int id) {
        this.userDao.deleteById(id);
        return this.userDao.findAll();
    }

}