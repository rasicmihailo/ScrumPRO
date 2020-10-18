package com.elfak.scrumpro.messaging;

import com.elfak.scrumpro.dto.TaskDTO;
import com.elfak.scrumpro.service.TaskService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.annotation.JmsListener;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.stereotype.Component;

@Component
public class TaskQueueReader {
    @Autowired
    private TaskService taskService;

    @JmsListener(destination = "task-queue")
    public void receive(@Payload TaskDTO taskDTO) {
        taskService.updateFromQueue(taskDTO);
    }

}
