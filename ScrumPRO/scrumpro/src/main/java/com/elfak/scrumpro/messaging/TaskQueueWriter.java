package com.elfak.scrumpro.messaging;

import com.elfak.scrumpro.dto.TaskDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

import javax.jms.Queue;

@Component
public class TaskQueueWriter {
    @Autowired
    JmsTemplate jmsTemplate;

    @Autowired
    Queue taskQueue;

    public void send(TaskDTO taskDTO){
        jmsTemplate.convertAndSend(taskQueue, taskDTO);
    }
}
