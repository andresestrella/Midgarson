package eitc.pucmm.servicioweb.repository;

import eitc.pucmm.servicioweb.classes.GameState;
import org.springframework.data.jpa.repository.JpaRepository;

public interface GameStateRepository extends JpaRepository<GameState, Long> {
    GameState findByUserId(long userId);
}
