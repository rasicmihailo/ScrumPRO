package com.elfak.scrumpro.core.repository;

import com.elfak.scrumpro.core.model.Project;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProjectRepository extends CrudRepository<Project, Long> {
}
