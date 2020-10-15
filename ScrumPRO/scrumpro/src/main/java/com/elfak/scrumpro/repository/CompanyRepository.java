package com.elfak.scrumpro.repository;

import com.elfak.scrumpro.model.Company;
import com.elfak.scrumpro.model.User;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface CompanyRepository extends CrudRepository<Company, Long> {
    List<Company> findAllByBossId(Long bossId);
    List<Company> findAllByUsersContains(User user);
}
