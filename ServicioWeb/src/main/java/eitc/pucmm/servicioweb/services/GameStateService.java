package eitc.pucmm.servicioweb.services;

import eitc.pucmm.servicioweb.classes.GameState;
import eitc.pucmm.servicioweb.repository.GameStateRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class GameStateService {
    @Autowired
    private GameStateRepository gameStateRepository;

    //Funcion para guardar un estado de juego
    public boolean saveState(GameState gameState){
        return gameStateRepository.save(gameState) != null ? true: false;
    }

    //Funcion para cargar un estado de juego
    public GameState loadGameState(long userId){
        return gameStateRepository.findByUserId(userId);
    }
    //Funcion para borrar un estado de juego
    public void deleteGameState(GameState gameState){
        gameStateRepository.delete(gameState);
    }
}
