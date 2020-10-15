package com.elfak.scrumpro.service;

import com.elfak.scrumpro.dto.CompanyDTO;
import com.elfak.scrumpro.dto.ProjectDTO;
import com.elfak.scrumpro.dto.ProjectUserDTO;
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

    public Project getById(Long id) {
        return projectRepository.findById(id).orElseGet(null);
    }

    public void addUser(String token, ProjectUserDTO projectUserDTO) {
        User me = userService.getUser(userService.getUserIdFromToken(token));

        Project project = this.getById(projectUserDTO.getProjectId());

        if (project != null && me.getId().equals(project.getCompany().getBoss().getId())) {
            project.getUsers().add(User.builder().id(projectUserDTO.getUserId()).build());

            projectRepository.save(project);
        } else {
            throw new RuntimeException();
        }
    }

    public List<ProjectDTO> getProjects(String token, CompanyDTO companyDTO) {
        User me = userService.getUser(userService.getUserIdFromToken(token));

        Company company = companyService.getById(companyDTO.getId());

        if (company != null && company.getUsers().contains(me)) {
            List<Project> projects = projectRepository.findAllByCompanyIdAndUsersContains(company.getId(), me);

            List<ProjectDTO> projectDTOS = new ArrayList<>();

            projects.forEach(project -> projectDTOS.add(ProjectDTO.builder().id(project.getId()).name(project.getName()).build()));

            return projectDTOS;
        } else {
            throw new RuntimeException();
        }
    }
}
