package eitc.pucmm.servicioweb.classes;

import lombok.Getter;
import lombok.Setter;

import javax.persistence.*;

@Entity
@Getter
@Setter
public class Item {
    @Id
    private Integer id;

    @Column(nullable = false)
    private ItemTag tag;

    private Integer count;

    public Item(Integer id, ItemTag tag, Integer count) {
        this.id = id;
        this.tag = tag;
        this.count = count;
    }

    public Item(){}
}
