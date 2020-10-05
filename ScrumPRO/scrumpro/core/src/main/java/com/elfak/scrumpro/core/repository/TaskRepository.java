package com.elfak.scrumpro.core.repository;

import com.elfak.scrumpro.core.model.Task;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface TaskRepository extends CrudRepository<Task, Long> {
}
