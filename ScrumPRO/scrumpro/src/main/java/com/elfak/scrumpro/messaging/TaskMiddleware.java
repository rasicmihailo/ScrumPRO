package com.elfak.scrumpro.messaging;

import com.elfak.scrumpro.model.Project;
import com.elfak.scrumpro.model.Task;
import com.elfak.scrumpro.service.ProjectService;
import com.elfak.scrumpro.service.TaskService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Component
public class TaskMiddleware {
    private Map<Long, List<Task>> tasks = new HashMap<>();

    @Autowired
    private TaskService taskService;

    @Autowired
    private ProjectService projectService;

    @PostConstruct
    private void autoReadData() {
        List<Project> projects = projectService.getAllProjects();
        projects.forEach(project -> tasks.put(project.getId(), taskService.getTasksForProject("superadmin", project.getId())));
    }

    public void add(Long projectId, Task task) {
        tasks.get(projectId).add(task);
    }

    public void edit(Long projectId, Task task) {
        Task foundTask = tasks.get(projectId).get(Integer.valueOf(task.getId().toString()));
        foundTask.setName(task.getName());
        foundTask.setContent(task.getContent());
        foundTask.setState(task.getState());
    }

    public void clear(Long projectId) {
        tasks.get(projectId).clear();
    }

    public List<Task> getAll(Long projectId){
        return tasks.get(projectId);
    }
}
