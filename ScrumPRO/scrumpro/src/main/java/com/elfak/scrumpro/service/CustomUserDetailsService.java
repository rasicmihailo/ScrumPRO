package com.elfak.scrumpro.service;

import com.elfak.scrumpro.enumeration.RoleEnum;
import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.repository.UserRepository;
import com.elfak.scrumpro.security.JwtTokenProvider;
import com.elfak.scrumpro.service.inteface.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
public class CustomUserDetailsService implements UserDetailsService, UserService {

    private UserRepository userRepository;

    private PasswordEncoder passwordEncoder;

    @Autowired
    private JwtTokenProvider jwtTokenProvider;

    public CustomUserDetailsService(
            final UserRepository userRepository,
            final PasswordEncoder passwordEncoder
    ) {
        this.userRepository = userRepository;
        this.passwordEncoder = passwordEncoder;
    }

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        UserDetails userDetails = this.userRepository.findByUsername(username)
                .orElseThrow(() -> new UsernameNotFoundException("Username: " + username + " not found"));
        return userDetails;
    }

    @Override
    public User createUser(String username, String password) {

        User user = User.builder()
                .username(username)
                .password(passwordEncoder.encode(password))
                .role(RoleEnum.ROLE_USER)
                .build();

        User createdUser = userRepository.save(user);

        return createdUser;
    }

    @Override
    public User getUser(Long id) {
        return userRepository.findById(id).orElseGet(null);
    }

    @Override
    public void updateUser(User user) {
        User foundUser = userRepository.findById(user.getId()).orElseGet(null);

        userRepository.save(foundUser);
    }

    @Override
    public User getUserByUsername(String username) {
        return userRepository.findByUsername(username).orElseGet(null);
    }

    @Override
    public User getUserInfo(String token) {
        return getUser(getUserIdFromToken(token));
    }

    @Override
    public Long getUserIdFromToken(String token) {
        String tokenWithoutBearer = token.substring(7);
        User user = null;
        String username = jwtTokenProvider.getUsername(tokenWithoutBearer);
        if (username != null) {
            user = getUserByUsername(username);
        }
        Long initiatorUserId = null;
        if (user != null) {
            initiatorUserId = user.getId();
        }
        return initiatorUserId;
    }
}
