package eitc.pucmm.servicioweb.services;

import eitc.pucmm.servicioweb.classes.User;
import eitc.pucmm.servicioweb.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserService {
    @Autowired
    private UserRepository userRepository;

    public UserService(){}

    //Funcion para obtener a los 10 usuarios con el score mas alto para generear el scoreBoard
    public List<User> getScoreBoard(){
        return userRepository.findTop20ByOrderByPuntajeDesc();
    }

    //Funcion para revisar las credenciales de un usuario
    public boolean checkCredentials(String name, String password){
        return userRepository.findByNameEqualsIgnoreCaseAndPasswordEqualsIgnoreCase(name,password) != null ? true : false;
    }

    public User getUser(String user){
        return userRepository.findByNameEqualsIgnoreCase(user);
    }

    //Funcion para registra un usuario
    public User registerUser(User user){
        if(userRepository.findByNameEqualsIgnoreCase(user.getName()) != null){
            return null;
        }else{
            user.setPuntaje(0);
            return userRepository.save(user);
        }
    }

    //Funcion para modificar las credenciales de un usuario
    public User modUser(User user){
        return userRepository.save(user);
    }

    //Funcino para eliminar un usuario
    public void delUser(User user){
        userRepository.delete(user);
    }

    public User getUserById(long userId) {
        return userRepository.getById(userId);
    }
}
