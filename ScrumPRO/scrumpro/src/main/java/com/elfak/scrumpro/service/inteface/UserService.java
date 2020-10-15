package com.elfak.scrumpro.service.inteface;

import com.elfak.scrumpro.dto.CompanyDTO;
import com.elfak.scrumpro.model.User;

import java.util.List;

public interface UserService {

    User createUser(String username, String password);

    User getUser(Long id);

    void updateUser(User user);

    User getUserByUsername(String username);

    User getUserInfo(String token);

    Long getUserIdFromToken(String token);

    List<User> getAllUsers(String token);

    List<User> getUsersInCompany(String token, CompanyDTO companyDTO);
}
