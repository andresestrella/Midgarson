package eitc.pucmm.servicioweb.classes;

import lombok.Getter;
import lombok.Setter;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import java.io.Serializable;
@Entity
@Getter
@Setter
public class Enemy implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    private EnemyTag name;
    private int damage;
    private float direction;
    private float life;
    private Boolean isDead = false;
    private float currPosX;
    private float currPosY;

}
