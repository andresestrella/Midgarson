package eitc.pucmm.servicioweb.controller;

import eitc.pucmm.servicioweb.classes.GameState;
import eitc.pucmm.servicioweb.classes.User;
import eitc.pucmm.servicioweb.services.GameStateService;
import eitc.pucmm.servicioweb.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.websocket.server.PathParam;
import java.util.List;

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

    @RequestMapping("user")
    public User getUser(@RequestParam(name = "user")String user){
        return userService.getUser(user);
    }
    @RequestMapping(value = "user/updateScore", method = RequestMethod.PUT)
    public User updateScore(@RequestBody User user){return userService.modUser(user);
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
        User user = userService.getUserById(gameState.getUserId());
        if (user != null) {
            if(gameStateService.existGameState(user.getId())) {
                GameState old = gameStateService.loadGameState(user.getId());
                old.setLevel(gameState.getLevel());
                old.setDificulty(gameState.getDificulty());
                old.setPlayerHealth(gameState.getPlayerHealth());
                old.setPlayerShield(gameState.getPlayerShield());
                old.setMoney(gameState.getMoney());
                old.setInventory(gameState.getInventory());
                old.setCurrPosX(gameState.getCurrPosX());
                old.setCurrPosY(gameState.getCurrPosY());
                return gameStateService.saveState(old);
            }
            else {
                return gameStateService.saveState(gameState);
            }

        } else {
            return false;
        }
    }

    @GetMapping("gameState/load/{id}")
    public GameState loadGameState(@PathVariable long id){
        GameState gameState = gameStateService.loadGameState(id);
        return gameState;
    }
}
