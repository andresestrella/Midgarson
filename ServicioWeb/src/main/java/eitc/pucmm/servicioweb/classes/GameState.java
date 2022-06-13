package eitc.pucmm.servicioweb.classes;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import java.io.Serializable;

@Entity
public class GameState implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    private long userId;
    private int level;
    private String dificulty;
    private int playerHealth;
    private int money;
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
    private String inventory;

    public GameState() {
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public long getUserId() {
        return userId;
    }

    public void setUserId(long userId) {
        this.userId = userId;
    }

    public int getLevel() {
        return level;
    }

    public void setLevel(int level) {
        this.level = level;
    }

    public String getDificulty() {
        return dificulty;
    }

    public void setDificulty(String dificulty) {
        this.dificulty = dificulty;
    }

    public int getPlayerHealth() {
        return playerHealth;
    }

    public void setPlayerHealth(int playerHealth) {
        this.playerHealth = playerHealth;
    }

    public int getMoney() {
        return money;
    }

    public void setMoney(int money) {
        this.money = money;
    }

    public String getInventory() {
        return inventory;
    }

    public void setInventory(String inventory) {
        this.inventory = inventory;
    }
}
