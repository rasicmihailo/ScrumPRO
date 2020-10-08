package com.elfak.scrumpro.controller;

import com.elfak.scrumpro.dto.UserDTO;
import com.elfak.scrumpro.messaging.UserQueueWriter;
import com.elfak.scrumpro.messaging.UserResponse;
import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.repository.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import javax.annotation.PostConstruct;

@RestController
@RequestMapping("/user")
@RequiredArgsConstructor
@CrossOrigin
public class UserController {

    @Autowired
    UserQueueWriter userQueueWriter;

    @Autowired
    private UserResponse responses;

    @PostConstruct
    private void createUser() {
        // User user = User.builder().username("mihailo").build();

        // userRepository.save(user);
    }

    @GetMapping("/info/{id}")
    public UserDTO getUserById(@PathVariable Long id) {

        userQueueWriter.send(id.toString());

        while(responses.getAll().size() == 0) {
        }
        String username = responses.getAll().get(0);
        responses.clear();

        if (username != null) {
            return UserDTO.builder().id(id).username(username).build();
        } else {
            return UserDTO.builder().build();
        }
    }
}
