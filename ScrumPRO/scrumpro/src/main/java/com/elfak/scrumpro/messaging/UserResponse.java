package com.elfak.scrumpro.messaging;

import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class UserResponse {
    private List<String> tasks = new ArrayList<>();

    public void add(String task) {
        tasks.add(task);
    }

    public void clear() {
        tasks.clear();
    }

    public List<String> getAll(){
        return tasks;
    }
}
