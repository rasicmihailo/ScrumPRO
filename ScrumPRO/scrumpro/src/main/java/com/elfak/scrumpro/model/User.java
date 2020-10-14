package com.elfak.scrumpro.model;

import com.elfak.scrumpro.enumeration.RoleEnum;
import lombok.*;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import javax.persistence.*;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Entity
@Table(name = "users", uniqueConstraints = {@UniqueConstraint(columnNames = {"username"})})
public class User implements UserDetails {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column
    private String username;

    @Column
    private String password;

    @Column
    private RoleEnum role;

    @OneToMany(mappedBy = "boss", fetch = FetchType.LAZY)
    private List<Company> myCompanies;

    @ManyToMany(mappedBy = "users", fetch = FetchType.LAZY)
    private List<Company> companies;

    @ManyToMany(mappedBy = "users", fetch = FetchType.LAZY)
    private List<Task> tasks;

    @ManyToMany(mappedBy = "users", fetch = FetchType.LAZY)
    private List<Project> projects;

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities() {
        return Collections.singletonList(new SimpleGrantedAuthority(role.name()));
    }
    @Override
    public boolean isAccountNonExpired() {
        return true;
    }

    @Override
    public boolean isAccountNonLocked() {
        return true;
    }

    @Override
    public boolean isCredentialsNonExpired() {
        return true;
    }

    @Override
    public boolean isEnabled() {
        return true;
    }
}
