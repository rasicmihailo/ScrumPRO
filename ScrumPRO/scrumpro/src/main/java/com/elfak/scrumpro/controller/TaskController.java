package com.elfak.scrumpro.controller;

import com.elfak.scrumpro.dto.ProjectDTO;
import com.elfak.scrumpro.dto.TaskDTO;
import com.elfak.scrumpro.model.Task;
import com.elfak.scrumpro.service.TaskService;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/task")
@RequiredArgsConstructor
@CrossOrigin
public class TaskController {
    @Autowired
    private TaskService taskService;

    @GetMapping("/{projectId}")
    public List<TaskDTO> getTasks(@RequestHeader("Authorization") String token, @PathVariable String projectId) {
        List<Task> tasks = taskService.getTasksForProject(token, Long.valueOf(projectId));

        List<TaskDTO> taskDTOS = new ArrayList<>();
        tasks.forEach(task -> taskDTOS.add(TaskDTO.builder()
                .id(task.getId())
                .name(task.getName())
                .content(task.getContent())
                .state(task.getState())
                .build()));

        return taskDTOS;
    }

    @PostMapping("/create")
    public Object createTask(@RequestHeader("Authorization") String token, @RequestBody TaskDTO taskDTO) {
        taskService.createTask(token, taskDTO);

        Map<String,Object> map = new HashMap<>();

        map.put("valid", true);
        map.put("errors", "");
        map.put("value", "success");

        return map;
    }

    @PostMapping("/edit")
    public Object editTask(@RequestHeader("Authorization") String token, @RequestBody TaskDTO taskDTO) {
        taskService.editTask(token, taskDTO);

        Map<String,Object> map = new HashMap<>();

        map.put("valid", true);
        map.put("errors", "");
        map.put("value", "success");

        return map;
    }
}
