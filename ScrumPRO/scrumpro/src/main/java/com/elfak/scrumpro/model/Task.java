package com.elfak.scrumpro.model;
import com.elfak.scrumpro.enumeration.TaskEnum;
import lombok.*;

import javax.persistence.*;
import java.util.List;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "tasks")
public class Task {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column
    private String name;

    @Column
    private String content;

    @Column
    private TaskEnum state;

    @ManyToOne
    @JoinColumn(name = "project_id")
    private Project project;
}
