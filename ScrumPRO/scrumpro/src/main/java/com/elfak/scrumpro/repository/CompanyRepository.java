package com.elfak.scrumpro.repository;

import com.elfak.scrumpro.model.Company;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface CompanyRepository extends CrudRepository<Company, Long> {
}
