package com.elfak.scrumpro.service;

import com.elfak.scrumpro.dto.ProjectDTO;
import com.elfak.scrumpro.model.Company;
import com.elfak.scrumpro.model.Project;
import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.repository.ProjectRepository;
import com.elfak.scrumpro.service.inteface.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class ProjectService {

    @Autowired
    private CompanyService companyService;

    @Autowired
    private ProjectRepository projectRepository;

    @Autowired
    private UserService userService;

    public void createProject(String token, ProjectDTO projectDTO) {
        User me = userService.getUser(userService.getUserIdFromToken(token));

        Company company = companyService.getById(projectDTO.getCompanyId());

        if (company != null && me.getId().equals(company.getBoss().getId())) {
            List<User> users = new ArrayList<>();
            users.add(me);
            Project project = Project.builder().company(company).name(projectDTO.getName()).users(users).build();

            projectRepository.save(project);
        } else {
            throw new RuntimeException();
        }
    }
}