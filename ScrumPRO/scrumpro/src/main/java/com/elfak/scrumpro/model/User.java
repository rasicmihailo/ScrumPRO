package com.elfak.scrumpro.model;

import lombok.*;

import javax.persistence.*;
import java.util.List;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Entity
@Table(name = "users", uniqueConstraints = {@UniqueConstraint(columnNames = {"username"})})
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column
    private String username;

    @OneToMany(mappedBy = "user", fetch = FetchType.EAGER)
    private List<Company> companies;

    @ManyToMany(mappedBy = "users")
    private List<Task> tasks;

    @ManyToMany(mappedBy = "users")
    private List<Project> projects;
}
