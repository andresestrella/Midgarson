package eitc.pucmm.servicioweb;

import eitc.pucmm.servicioweb.classes.GameState;
import eitc.pucmm.servicioweb.classes.Item;
import eitc.pucmm.servicioweb.classes.ItemTag;
import eitc.pucmm.servicioweb.repository.ItemRepository;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class ServicioWebApplication {

    public static void main(String[] args) {
        SpringApplication.run(ServicioWebApplication.class, args);
    }

    @Bean
    public CommandLineRunner loadData(ItemRepository itemRepository){
        System.out.println("Inicializando los datos.");
        return args -> {
            if(itemRepository.findAll().isEmpty()){
                Item item1 = new Item();
                item1.setId(1);
                item1.setTag(ItemTag.SHIELD);
                item1.setCount(0);
                itemRepository.save(item1);
                System.out.println("==================== item 1 => OK");

                Item item2 = new Item();
                item2.setId(2);
                item2.setTag(ItemTag.KNIFE);
                item2.setCount(0);
                itemRepository.save(item2);
                System.out.println("==================== item 2 => OK");

                Item item3 = new Item();
                item3.setId(3);
                item3.setTag(ItemTag.ARROW);
                item3.setCount(0);
                itemRepository.save(item3);
                System.out.println("==================== item 3 => OK");

                Item item4 = new Item();
                item4.setId(4);
                item4.setTag(ItemTag.BOMB);
                item4.setCount(0);
                itemRepository.save(item4);
                System.out.println("==================== item 4 => OK");
            }
        };

    }

}
