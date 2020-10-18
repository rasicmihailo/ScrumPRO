package com.elfak.scrumpro.repository;

import com.elfak.scrumpro.model.Task;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface TaskRepository extends CrudRepository<Task, Long> {
    List<Task> findAllByProjectId(Long projectId);
}
