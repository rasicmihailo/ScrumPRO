package com.elfak.scrumpro.repository;

import com.elfak.scrumpro.model.Project;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ProjectRepository extends CrudRepository<Project, Long> {
    List<Project> findAllByCompanyId(Long companyId);
}
