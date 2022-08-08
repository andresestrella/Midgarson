package eitc.pucmm.servicioweb.controller;

import eitc.pucmm.servicioweb.classes.GameState;
import eitc.pucmm.servicioweb.classes.User;
import eitc.pucmm.servicioweb.services.GameStateService;
import eitc.pucmm.servicioweb.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityNotFoundException;
import javax.websocket.server.PathParam;
import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/api")
public class ApiController {
    @Autowired
    private UserService userService;

    @Autowired
    private GameStateService gameStateService;


    public ApiController(){};
    //Endpoints referentes a los usuarios
    @RequestMapping("user/scoreBoard")
    public List<User> getScoreboard(){
        return userService.getScoreBoard();
    }

    @RequestMapping(value = "user/modUser", method = RequestMethod.PUT)
    public User modUser(@RequestBody User user){
        return userService.modUser(user);
    }

    @RequestMapping(value = "user/createUser", method = RequestMethod.PUT)
    public User registrarUsuario(@RequestBody User user){
        return userService.registerUser(user);
    }

    @RequestMapping(value = "user/validateUser", method = RequestMethod.PUT)
    public User validateUser(@RequestBody User user){
        try{
            User user1 = userService.findUser(user.getName());
            if(user1.getPassword().equals(user.getPassword())){
                return user1;
            }
            else {
                return null;
            }
        }catch (EntityNotFoundException e){
            return null;
        }

    }

    @RequestMapping(value = "user/deleteUser", method = RequestMethod.DELETE)
    public String deleteUser(@RequestBody User user){
        GameState aux = gameStateService.loadGameState(user.getId());
        if(aux != null)
            gameStateService.deleteGameState(aux);

        userService.delUser(user);
        return "Usuario y estados de juego han sido eliminados";
    }

    //Endpoints para los estados de juego
    @PutMapping("gameState/save")
    public boolean saveState(@RequestBody GameState gameState) {

        try{
            User user = userService.getUserById(gameState.getUserId());
            if(gameStateService.existGameState(user.getId())) {
                GameState old = gameStateService.loadGameState(user.getId());
                old.setCurrLevel(gameState.getCurrLevel());
                old.setDificulty(gameState.getDificulty());
                old.setPlayerHealth(gameState.getPlayerHealth());
                old.setPlayerShield(gameState.getPlayerShield());
                old.setMoney(gameState.getMoney());
                old.setInventory(gameState.getInventory());
                old.setCurrPosX(gameState.getCurrPosX());
                old.setCurrPosY(gameState.getCurrPosY());
                old.setScore(gameState.getScore());
                old.setTime(gameState.getTime());
                old.setScoreL1(gameState.getScoreL1());
                old.setScoreL2(gameState.getScoreL2());
                old.setScoreL3(gameState.getScoreL3());
                old.setScoreL4(gameState.getScoreL4());
                old.setScoreL5(gameState.getScoreL5());
                old.setScoreL6(gameState.getScoreL6());
                /*gameState.getEnemies().stream().map(
                        enemy -> {enemy = gameStateService.saveEnemy(enemy);
                            return enemy;
                        }
                ).collect(Collectors.toList());*/
                old.setEnemies(gameState.getEnemies());
                old.setItem1(gameState.getItem1());
                old.setItem2(gameState.getItem2());
                old.setItem3(gameState.getItem3());
                old.setItem4(gameState.getItem4());
                return gameStateService.saveState(old) != null;
            }
            else {
                /*gameState.getEnemies().stream().map(
                        enemy -> {enemy = gameStateService.saveEnemy(enemy);
                            return enemy;
                        }
                ).collect(Collectors.toList());*/

                return gameStateService.saveState(gameState) != null;
            }
        }catch (EntityNotFoundException e){
            return false;
        }
    }

    @GetMapping("gameState/load/{id}")
    public GameState loadGameState(@PathVariable long id){
        try{
            GameState gameState = gameStateService.loadGameState(id);
            gameState.setIsFirstTime(false);
            return gameState;
        } catch (EntityNotFoundException | NullPointerException e) {
            GameState gameState = new GameState();
            gameState.setUserId(id);
            gameState = gameStateService.saveState(gameState);
            return gameState;
        }

    }
}
