package com.elfak.scrumpro.config;

import com.fasterxml.jackson.databind.ObjectMapper;
import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.activemq.command.ActiveMQQueue;
import org.apache.activemq.command.ActiveMQTopic;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Primary;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.jms.support.converter.MappingJackson2MessageConverter;
import org.springframework.jms.support.converter.MessageConverter;
import org.springframework.jms.support.converter.MessageType;
import org.springframework.messaging.converter.MessageConversionException;
import org.springframework.stereotype.Component;

import javax.jms.*;

@Configuration
public class ActiveMQConfig {

    @Value("${spring.activemq.broker-url}")
    private String brokerUrl;

//    @Value("${spring.activemq.username}")
//    String userName;
//
//    @Value("${spring.activemq.password}")
//    String password;

    @Bean
    public Queue queue() {
        return new ActiveMQQueue("user-queue");
    }

//    @Bean
//    public Queue trainerQueue() {
//        return new ActiveMQQueue("trainer-queue"); }
//
//    @Bean
//    public Topic trainerServiceTopic() {
//        return new ActiveMQTopic("trainer-service-topic");
//    }
//
//    @Bean
//    public Queue serviceTrainerQueue() {
//        return new ActiveMQQueue("service-trainer-queue");
//    }

    @Bean
    public ActiveMQConnectionFactory activeMQConnectionFactory() {
        ActiveMQConnectionFactory factory = new ActiveMQConnectionFactory();
        factory.setBrokerURL(brokerUrl);
        //factory.setUserName(userName);
        //factory.setPassword(password);
        return factory;
    }

    @Bean
    public JmsTemplate jmsTemplate() {
        return new JmsTemplate(activeMQConnectionFactory());
    }

    @Bean // Serialize message content to json using TextMessage
    public MessageConverter jacksonJmsMessageConverter() {
        MappingJackson2MessageConverter converter = new MappingJackson2MessageConverter();
        converter.setTargetType(MessageType.TEXT);
        converter.setTypeIdPropertyName("_type");
        return converter;
    }

//    /*
//     * Used for Receiving Message
//     */
//    @Bean
//    public JmsListenerContainerFactory<?> jsaFactory(ConnectionFactory connectionFactory,
//                                                     DefaultJmsListenerContainerFactoryConfigurer configurer) {
//        DefaultJmsListenerContainerFactory factory = new DefaultJmsListenerContainerFactory();
//        factory.setMessageConverter(jacksonJmsMessageConverter());
//        configurer.configure(factory, connectionFactory);
//        return factory;
//    }

    @Component
    public class JsonMessageConverter implements MessageConverter {

        @Autowired
        private ObjectMapper mapper;

        // Converts message to JSON
        @Override
        public javax.jms.Message toMessage(Object object, Session session) throws JMSException, MessageConversionException {
            String json;

            try {
                json = mapper.writeValueAsString(object);
            } catch (Exception e) {
                throw new MessageConversionException("Message cannot be parsed. ", e);
            }

            TextMessage message = session.createTextMessage();
            message.setText(json);

            return message;
        }

        // Extracts JSON payload for further processing by JacksonMapper
        @Override
        public Object fromMessage(javax.jms.Message message) throws JMSException, MessageConversionException {
            return ((TextMessage) message).getText();
        }
    }
}
