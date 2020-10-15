package com.elfak.scrumpro.controller;

import com.elfak.scrumpro.dto.CompanyDTO;
import com.elfak.scrumpro.dto.CompanyUserDTO;
import com.elfak.scrumpro.service.CompanyService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/company")
@CrossOrigin
public class CompanyController {

    @Autowired
    private CompanyService companyService;

    @PostMapping("/create")
    public Object create(@RequestHeader("Authorization") String token, @RequestBody CompanyDTO companyDTO) {

        companyService.createCompany(token, companyDTO);
        Map<String,Object> map = new HashMap<>();

        map.put("valid", true);
        map.put("errors", "");
        map.put("value", "success");

        return map;
    }

    @PostMapping("/add-user")
    public Object addUser(@RequestHeader("Authorization") String token, @RequestBody CompanyUserDTO companyUserDTO) {

        companyService.addUser(token, companyUserDTO);
        Map<String,Object> map = new HashMap<>();

        map.put("valid", true);
        map.put("errors", "");
        map.put("value", "success");

        return map;
    }
}
