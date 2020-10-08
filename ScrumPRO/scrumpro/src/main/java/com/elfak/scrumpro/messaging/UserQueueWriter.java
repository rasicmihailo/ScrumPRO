package com.elfak.scrumpro.messaging;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

import javax.jms.Queue;

@Component
public class UserQueueWriter {
    @Autowired
    JmsTemplate jmsTemplate;

    @Autowired
    Queue queue;

    public void send(String msg){
        jmsTemplate.convertAndSend(queue, msg);
    }
}
