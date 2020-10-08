package com.elfak.scrumpro.messaging;

import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Component;

@Component
public class UserQueueReader {

    @Autowired
    UserResponse responses;

    @Autowired
    UserRepository userRepository;

    @JmsListener(destination = "user-queue")
    public void receive(String task) {
        User user = userRepository.findById(Long.valueOf(task)).orElseGet(null);
        if (user != null)
            responses.add(user.getUsername());
    }
}
