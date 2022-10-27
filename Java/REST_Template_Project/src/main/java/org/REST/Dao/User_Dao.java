package org.REST.Dao;

import org.REST.Entity.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface User_Dao extends JpaRepository<User, Integer> {
}