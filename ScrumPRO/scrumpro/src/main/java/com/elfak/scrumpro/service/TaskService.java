package com.elfak.scrumpro.service;

import com.elfak.scrumpro.dto.TaskDTO;
import com.elfak.scrumpro.messaging.TaskQueueWriter;
import com.elfak.scrumpro.model.Project;
import com.elfak.scrumpro.model.Task;
import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.repository.TaskRepository;
import com.elfak.scrumpro.service.inteface.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TaskService {

    @Autowired
    private TaskRepository taskRepository;

    @Autowired
    private UserService userService;

    @Autowired
    private ProjectService projectService;

    @Autowired
    TaskQueueWriter taskQueueWriter;

    public List<Task> getTasksForProject(String token, Long projectId) {
        if (token.equals("superadmin")) {
            return taskRepository.findAllByProjectId(projectId);
        }
        User me = userService.getUser(userService.getUserIdFromToken(token));
        Project project = projectService.getById(projectId);

        if (project != null && project.getUsers().contains(me)) {
            return taskRepository.findAllByProjectId(projectId);
        } else {
            throw new RuntimeException();
        }
    }

    public void createTask(String token, TaskDTO taskDTO) {
        User me = userService.getUser(userService.getUserIdFromToken(token));
        Project project = projectService.getById(taskDTO.getProjectId());
        if (project != null && project.getUsers().contains(me)) {
            taskRepository.save(Task.builder()
                    .name(taskDTO.getName())
                    .content(taskDTO.getContent())
                    .state(taskDTO.getState())
                    .project(project)
                    .build());
        } else {
            throw new RuntimeException();
        }
    }

    public void editTask(String token, TaskDTO taskDTO) {
        User me = userService.getUser(userService.getUserIdFromToken(token));
        Project project = projectService.getById(taskDTO.getProjectId());
        if (project != null && project.getUsers().contains(me)) {
            taskQueueWriter.send(taskDTO);
        } else {
            throw new RuntimeException();
        }
    }

    public void updateFromQueue(TaskDTO taskDTO) {
        taskRepository.save(Task.builder()
                .id(taskDTO.getId())
                .name(taskDTO.getName())
                .content(taskDTO.getContent())
                .state(taskDTO.getState())
                .project(projectService.getById(taskDTO.getProjectId()))
                .build());
    }
}
