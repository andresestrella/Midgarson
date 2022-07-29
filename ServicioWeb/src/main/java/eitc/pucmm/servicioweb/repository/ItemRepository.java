package eitc.pucmm.servicioweb.repository;

import eitc.pucmm.servicioweb.classes.Item;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ItemRepository extends JpaRepository<Item, Integer> {
}