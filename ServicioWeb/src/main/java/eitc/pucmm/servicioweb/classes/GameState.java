package eitc.pucmm.servicioweb.classes;

import lombok.Builder;
import lombok.Getter;
import lombok.NonNull;
import lombok.Setter;
import org.springframework.beans.factory.annotation.Value;

import javax.persistence.*;
import java.io.Serializable;
import java.util.Set;

@Entity
@Getter
@Setter
public class GameState implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    private long userId;
    private int currLevel = 1;
    private String dificulty;
    private int playerHealth;
    private int playerShield;
    private int money;
    private String inventory;
    private float currPosX;
    private float currPosY;
    private int score;
    private float time;
    @OneToMany(cascade=CascadeType.ALL,fetch=FetchType.LAZY)
    @JoinColumn(name = "id_enemy")
    private Set<Enemy> enemies;

    @ManyToOne()
    private Item item1 = new Item(1,ItemTag.SHIELD,1);

    @ManyToOne()
    private Item item2 = new Item(2,ItemTag.KNIFE,1);

    @ManyToOne()
    private Item item3= new Item(3,ItemTag.ARROW,0);

    @ManyToOne()
    private Item item4 = new Item(4,ItemTag.BOMB,5);

}
