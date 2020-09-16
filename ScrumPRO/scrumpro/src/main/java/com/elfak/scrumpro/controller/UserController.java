package com.elfak.scrumpro.controller;

import com.elfak.scrumpro.DTOs.UserDTO;
import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.repository.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

import javax.annotation.PostConstruct;

@RestController
@RequestMapping("/user")
@RequiredArgsConstructor
@CrossOrigin
public class UserController {

    private final UserRepository userRepository;

    @PostConstruct
    private void createUser() {
        User user = User.builder().username("mihailo").build();

        userRepository.save(user);
    }

    @GetMapping("/info/{id}")
    public UserDTO getUserById(@PathVariable Long id) {
        User user = userRepository.findById(id).orElseGet(null);

        if (user != null) {
            return UserDTO.builder().id(user.getId()).username(user.getUsername()).build();
        } else {
            return UserDTO.builder().build();
        }
    }
}
