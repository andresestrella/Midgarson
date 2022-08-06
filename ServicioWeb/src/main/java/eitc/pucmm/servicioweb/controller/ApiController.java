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
    public boolean validateUser(@RequestBody User user){
        return userService.checkCredentials(user.getName(), user.getPassword());
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
                return gameStateService.saveState(old);
            }
            else {
                /*gameState.getEnemies().stream().map(
                        enemy -> {enemy = gameStateService.saveEnemy(enemy);
                            return enemy;
                        }
                ).collect(Collectors.toList());*/

                return gameStateService.saveState(gameState);
            }
        }catch (EntityNotFoundException e){
            return false;
        }
    }

    @GetMapping("gameState/load/{id}")
    public GameState loadGameState(@PathVariable long id){
        try{
            GameState gameState = gameStateService.loadGameState(id);
            return gameState;
        } catch (EntityNotFoundException e) {
            return null;
        }

    }
}
