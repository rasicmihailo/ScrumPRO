package com.elfak.scrumpro.controller;

import com.elfak.scrumpro.dto.CompanyUserDTO;
import com.elfak.scrumpro.dto.ProjectDTO;
import com.elfak.scrumpro.dto.ProjectUserDTO;
import com.elfak.scrumpro.service.ProjectService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/project")
@CrossOrigin
public class ProjectController {
    @Autowired
    private ProjectService projectService;

    @PostMapping("/create")
    public Object register(@RequestHeader("Authorization") String token, @RequestBody ProjectDTO projectDTO) {

        projectService.createProject(token, projectDTO);
        Map<String, Object> map = new HashMap<>();

        map.put("valid", true);
        map.put("errors", "");
        map.put("value", "success");

        return map;
    }

    @PostMapping("/add-user")
    public Object addUser(@RequestHeader("Authorization") String token, @RequestBody ProjectUserDTO projectUserDTO) {

        projectService.addUser(token, projectUserDTO);
        Map<String,Object> map = new HashMap<>();

        map.put("valid", true);
        map.put("errors", "");
        map.put("value", "success");

        return map;
    }
}
