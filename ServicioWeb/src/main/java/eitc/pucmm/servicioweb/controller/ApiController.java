package eitc.pucmm.servicioweb.controller;

import eitc.pucmm.servicioweb.classes.GameState;
import eitc.pucmm.servicioweb.classes.User;
import eitc.pucmm.servicioweb.services.GameStateService;
import eitc.pucmm.servicioweb.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
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
    @RequestMapping("gameState/save")
    public boolean saveState(@RequestBody GameState gameState) {
        User user = userService.getUserById(gameState.getUserId());
        if (user != null) {
            return gameStateService.saveState(gameState);
        } else {
            return false;
        }
    }

    @RequestMapping("gameState/load")
    public GameState loadGameStatte(@PathParam("id") long id){
        return gameStateService.loadGameState(id);
    }
}
