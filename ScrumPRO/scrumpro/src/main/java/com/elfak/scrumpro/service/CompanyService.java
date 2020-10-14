package com.elfak.scrumpro.service;

import com.elfak.scrumpro.dto.CompanyDTO;
import com.elfak.scrumpro.model.Company;
import com.elfak.scrumpro.model.User;
import com.elfak.scrumpro.repository.CompanyRepository;
import com.elfak.scrumpro.service.inteface.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CompanyService {

    @Autowired
    private CompanyRepository companyRepository;

    @Autowired
    private UserService userService;

    public void createCompany(String token, CompanyDTO companyDTO) {
        User me = userService.getUser(userService.getUserIdFromToken(token));

        Company company = Company.builder().name(companyDTO.getName()).boss(me).build();

        companyRepository.save(company);
    }
}
