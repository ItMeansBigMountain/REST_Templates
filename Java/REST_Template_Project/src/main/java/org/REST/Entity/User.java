package org.REST.Entity;


import javax.persistence.*;


@Entity
@Table(name = "tbl_Users")
public class User {
    @Id
    @Column(name = "pk")
    @GeneratedValue(strategy = GenerationType.AUTO)
    private int id;
    private String name;
    private String email;


    public User() {

    }

    public User(int id, String email) {
        this.id = id;
        this.email = email;
    }


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }


}