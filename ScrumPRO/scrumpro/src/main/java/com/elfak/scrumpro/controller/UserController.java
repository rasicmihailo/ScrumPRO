package com.elfak.scrumpro.controller;

import com.elfak.scrumpro.dto.CompanyDTO;
import com.elfak.scrumpro.dto.UserDTO;
import com.elfak.scrumpro.messaging.UserQueueWriter;
import com.elfak.scrumpro.messaging.UserResponse;
import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.security.JwtTokenProvider;
import com.elfak.scrumpro.service.inteface.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/user")
@RequiredArgsConstructor
@CrossOrigin
public class UserController {

    @Autowired
    UserQueueWriter userQueueWriter;

    @Autowired
    private UserResponse responses;

    @Autowired
    private UserService userService;

    @Autowired
    private AuthenticationManager authenticationManager;

    @Autowired
    private JwtTokenProvider jwtTokenProvider;

    @GetMapping("/info/{id}")
    public UserDTO getUserById(@PathVariable Long id) {

        userQueueWriter.send(id.toString());

        while(responses.getAll().size() == 0) {
        }
        String username = responses.getAll().get(0);
        responses.clear();

        if (username != null) {
            return UserDTO.builder().username(username).build();
        } else {
            return UserDTO.builder().build();
        }
    }

    @PostMapping("/register")
    public Object register(@RequestBody UserDTO userDTO) {
        userService.createUser(userDTO.getUsername(), userDTO.getPassword());

        Map<String,Object> map = new HashMap<>();

        map.put("valid", true);
        map.put("errors", "");
        map.put("value", "success");

        return map;
    }

    @PostMapping("/login")
    public UserDTO login(@RequestBody UserDTO userDTO) {
        String username = userDTO.getUsername();
        String password = userDTO.getPassword();
        authenticationManager.authenticate(new UsernamePasswordAuthenticationToken(username, password));

        User user = userService.getUserByUsername(username);

        String token = "Bearer " + jwtTokenProvider.createToken(username, user.getRole().name());

        return UserDTO.builder().id(user.getId()).username(user.getUsername()).token(token).build();
    }

    @GetMapping("/all")
    public List<UserDTO> getAllUsers(@RequestHeader("Authorization") String token) {
        List<User> users = userService.getAllUsers(token);

        List<UserDTO> userDTOS = new ArrayList<>();

        users.forEach(user -> userDTOS.add(UserDTO.builder().id(user.getId()).username(user.getUsername()).build()));

        return userDTOS;
    }

    @GetMapping("/company")
    public List<UserDTO> getUsersInCompany(@RequestHeader("Authorization") String token, @RequestBody CompanyDTO companyDTO) {
        List<User> users = userService.getUsersInCompany(token, companyDTO);

        List<UserDTO> userDTOS = new ArrayList<>();

        users.forEach(user -> userDTOS.add(UserDTO.builder().id(user.getId()).username(user.getUsername()).build()));

        return userDTOS;
    }
}
