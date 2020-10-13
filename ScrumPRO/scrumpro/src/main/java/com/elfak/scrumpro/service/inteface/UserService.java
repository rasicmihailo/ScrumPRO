package com.elfak.scrumpro.service.inteface;

import com.elfak.scrumpro.model.User;

public interface UserService {

    User createUser(String username, String password);

    User getUser(Long id);

    void updateUser(User user);

    User getUserByUsername(String username);

    User getUserInfo(String token);

    Long getUserIdFromToken(String token);
}
