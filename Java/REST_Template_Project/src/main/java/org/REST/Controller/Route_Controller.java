package org.REST.Controller;

import org.REST.Entity.User;
import org.REST.Service.MailService;
import org.REST.Service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class Route_Controller {

    @Autowired
    private UserService UserService;

    @Autowired
    private MailService mailService;


    //HOME SCREEN
    @RequestMapping("/")
    public String home(@RequestParam(value = "name", defaultValue = "World") String name) {
        return "Hello " + name + "! Go to localhost:8000/users to check me out!";
    }

    @GetMapping("/users") // GET ALL
    public List<User> displayCourses() {
        return this.UserService.getAllUsers();
    }

    @PostMapping("/users") // ADD
    public User _addCourse(@RequestBody User obj) {
        return this.UserService.addUser(obj);
    }

    @PutMapping("/users") // PUT
    public List<User> _updateCourseByID(@RequestBody User obj) {
        return this.UserService.updateUser(obj);
    }

    @DeleteMapping("/users/{id}") // DELETE
    public List<User> _deleteCourseByID(@PathVariable int id) {
        return this.UserService.deleteUser(id);
    }

    @GetMapping("/users/{id}") // GET ID
    public User _displayCourseByID(@PathVariable String id) {
        return this.UserService.getUserById(Integer.parseInt(id));
    }


    @RequestMapping("/sendmail")
    public String _sendMail(@RequestParam(value = "to") String to_email, @RequestParam(value = "subject") String subject, @RequestParam(value = "body", defaultValue = "null") String body) {
        return "Success: " + this.mailService.send_mail(to_email, subject, body);
    }


}