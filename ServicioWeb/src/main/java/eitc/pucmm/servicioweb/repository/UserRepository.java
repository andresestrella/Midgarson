package eitc.pucmm.servicioweb.repository;

import eitc.pucmm.servicioweb.classes.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface UserRepository extends JpaRepository<User, Long> {
    List<User> findTop20ByOrderByPuntajeDesc();

    User findByName(String username);

    //User findById(Long id);
    User findByNameEqualsIgnoreCase(String Name);
}
