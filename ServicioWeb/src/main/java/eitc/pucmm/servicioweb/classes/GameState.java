package eitc.pucmm.servicioweb.classes;

import lombok.Getter;
import lombok.Setter;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Getter
@Setter
public class GameState implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    private long userId;
    private int level;
    private String dificulty;
    private int playerHealth;
    private int money;
    private String inventory;
    private int currPosX;
    private int currPosY;


    /*
    Se podría guardar un json
    {[
        arma1: {
            tipo: x,
            daño: y,
            precio: z,
            equipado: 1
        },
        casco: {
            tipo: x,
            specialEffect: "",
            precio: z,
            armorValue: y,
            equipado: 1
        }
        arma2: {
            tipo: x,
            daño: y,
            cantidad:w
            precio: z
        }
    ]}
     */


}
