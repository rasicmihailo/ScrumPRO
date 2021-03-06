package com.elfak.scrumpro.service;

import com.elfak.scrumpro.dto.CompanyDTO;
import com.elfak.scrumpro.dto.CompanyUserDTO;
import com.elfak.scrumpro.dto.ProjectDTO;
import com.elfak.scrumpro.enumeration.RoleEnum;
import com.elfak.scrumpro.model.Company;
import com.elfak.scrumpro.model.Project;
import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.repository.CompanyRepository;
import com.elfak.scrumpro.repository.ProjectRepository;
import com.elfak.scrumpro.service.inteface.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class CompanyService {

    @Autowired
    private CompanyRepository companyRepository;

    @Autowired
    private UserService userService;

    @Autowired
    private ProjectRepository projectRepository;

    public void createCompany(String token, CompanyDTO companyDTO) {
        User me = userService.getUser(userService.getUserIdFromToken(token));

        List<User> users = new ArrayList<>();
        users.add(me);
        Company company = Company.builder().name(companyDTO.getName()).boss(me).users(users).build();

        companyRepository.save(company);
    }

    public Company getById(Long id) {
        return companyRepository.findById(id).orElseGet(null);
    }

    public void addUser(String token, CompanyUserDTO companyUserDTO) {
        User me = userService.getUser(userService.getUserIdFromToken(token));

        Company company = this.getById(companyUserDTO.getCompanyId());

        if (company != null && me.getId().equals(company.getBoss().getId())) {
            company.getUsers().add(User.builder().id(companyUserDTO.getUserId()).build());

            companyRepository.save(company);

            List<Project> projects = projectRepository.findAllByCompanyId(company.getId());
            projects.forEach(project -> {
                project.getUsers().add(User.builder().id(companyUserDTO.getUserId()).build());
            });

            projectRepository.saveAll(projects);
        } else {
            throw new RuntimeException();
        }
    }

    public List<CompanyDTO> getCompanies(String token) {
        User me = userService.getUser(userService.getUserIdFromToken(token));

        List<Company> companiesBoss = companyRepository.findAllByBossId(me.getId());
        List<Company> companiesEmployee = companyRepository.findAllByUsersContains(me);
        companiesEmployee.removeAll(companiesBoss);

        List<CompanyDTO> companies = new ArrayList<>();
        companiesBoss.forEach(company -> companies.add(CompanyDTO.builder().id(company.getId()).name(company.getName()).role(RoleEnum.ROLE_ADMIN).build()));
        companiesEmployee.forEach(company -> companies.add(CompanyDTO.builder().id(company.getId()).name(company.getName()).role(RoleEnum.ROLE_USER).build()));

        return companies;
    }
}
