package eitc.pucmm.servicioweb.services;

import eitc.pucmm.servicioweb.classes.User;
import eitc.pucmm.servicioweb.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class UserService {
    @Autowired
    private UserRepository userRepository;

    public UserService(){}

    //Funcion para obtener a los 10 usuarios con el score mas alto para generear el scoreBoard
    public List<User> getScoreBoard(){
        return userRepository.findTop20ByOrderByPuntajeDesc();
    }

    //Funcion para registra un usuario
    public User registerUser(User user){
        user = userRepository.save(user);
        return user;
    }

    //Funcion para modificar las credenciales de un usuario
    public User modUser(User user){
        return userRepository.save(user);
    }

    //Funcino para eliminar un usuario
    public void delUser(User user){
        userRepository.delete(user);
    }

    public User findUser(String username) {
        return userRepository.findByName(username);
    }

    public User getUserById(Long id){
        return userRepository.findById(id).get();
    }
}
