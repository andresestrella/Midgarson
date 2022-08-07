public static class GameManagement
{
    public static bool music_ON = true;
    public static bool fx_ON = true;    

    //Level info
    //nivel por el que va el jugador - del 1 - 6
    public static int currentLevel = 1;//1er nivel por defecto
    //level 1
    public static int lvl1Score = 0;
    public static string lvl1Title = "Asedio de York"; //- Jorvik
    //level 2
    public static int lvl2Score = 0;
    public static string lvl2Title = "Afueras de York"; //- Jorvik
    //level 3
    public static int lvl3Score = 0;
    public static string lvl3Title = "Ciudad Licoln"; //- Mercia
    //level 4
    public static int lvl4Score = 0;
    public static string lvl4Title = "Costa de Dover";
    //level 5
    public static int lvl5Score = 0;
    public static string lvl5Title = "Ciudad Palermo"; // - Sicilia
    //level 6
    public static int lvl6Score = 0;
    public static string lvl6Title = "Winchester"; // - Wessex

    //public static string dificulad = "Marinero";

    //leif
    public static float resistenciaLeif = 10f;
    public static float damageLeif_givesEspada = 30f;
    public static float damageLeif_givesHacha = 60f;
    public static float damageLeif_givesFlecha = 10f;
    public static float damageLeif_givesCuchillo = 5f;
    public static float damageLeif_givesBomba = 40f;

    //enemies
    public static float basicEnemyAttack_give = 5f;
    public static float basicEnemyAttack_receive = 4f;
    public static float basicEnemyAttack_velocity = 2f;
    //
    public static float heavyEnemyAttack_give = 8f;
    public static float heavyEnemyAttack_receive =  6f;
    public static float heavyEnemyAttack_velocity = 2f;
    //
    public static float archerEnemyAttack_give = 9f;
    public static float archerEnemyAttack_receive = 5f;
    //
    public static float swordmanEnemyAttack_give = 12f;
    public static float swordmanEnemyAttack_receive = 7f;
    public static float swordmanEnemyAttack_velocity = 2f;
    //
    public static float boss1EnemyAttack_give = 14f;
    public static float boss1EnemyAttack_receive = 10f;
    public static float boss1EnemyAttack_velocity = 3f;
    //
    public static float boss5EnemyAttack_give = 17f;
    public static float boss5EnemyAttack_receive = 12f;
    public static float boss5EnemyAttack_velocity = 3f;
    //
    public static float boss6EnemyAttack_give = 20f;
    public static float boss6EnemyAttack_receive = 15f;
    public static float boss6EnemyAttack_velocity = 5f;
    //
    public static float birdEnemyVelocity = 5f;
    public static float birdEnemyRockVelocity = 3f;
    public static float birdEnemySpawnFrecuency = 0.70f;

    public static float dropsProbability = 0.60f;

    //tienda
    public static float coinsEarned;
    public static float vidas;
    public static float vidas_precio;//300    limite de compra: 3
    public static bool vidas_available;
    public static float flechas;
    public static float flechas_precio;
    public static float explosivo;
    public static float explosivo_precio;
    public static float armadura; 
    public static float armadura_precio; //500
    public static bool armadura_available;
    public static float hacha;
    public static float hacha_precio; //1300 2300 3000
    public static bool hacha_available;
    public static float espada;
    public static float espada_precio; //700 800 1500
    public static bool espada_available;
    public static float cuchillo;
    public static float cuchillo_precio; //200
    public static float arco;
    public static float arco_precio; //2300
    public static bool arco_available;
    public static float polvora;
    public static float polvora_precio; //300

    public static void backToDefaultDifficulty(){//marinero
        //leif
        resistenciaLeif = 10f;
        damageLeif_givesEspada = 30f;
        damageLeif_givesHacha = 60f;
        damageLeif_givesFlecha = 10f;
        damageLeif_givesCuchillo = 5f;
        damageLeif_givesBomba = 40f;

        //enemies
        basicEnemyAttack_give = 5f;
        basicEnemyAttack_receive = 4f;
        basicEnemyAttack_velocity = 2f;
        //
        heavyEnemyAttack_give = 8f;
        heavyEnemyAttack_receive =  6f;
        heavyEnemyAttack_velocity = 2f;
        //
        archerEnemyAttack_give = 9f;
        archerEnemyAttack_receive = 5f;
        //
        swordmanEnemyAttack_give = 12f;
        swordmanEnemyAttack_receive = 7f;
        swordmanEnemyAttack_velocity = 2f;
        //
        boss1EnemyAttack_give = 14f;
        boss1EnemyAttack_receive = 10f;
        boss1EnemyAttack_velocity = 3f;
        //
        boss5EnemyAttack_give = 17f;
        boss5EnemyAttack_receive = 12f;
        boss5EnemyAttack_velocity = 3f;
        //
        boss6EnemyAttack_give = 20f;
        boss6EnemyAttack_receive = 15f;
        boss6EnemyAttack_velocity = 5f;
        //
        birdEnemyVelocity = 5f;
        birdEnemyRockVelocity = 3f;
        birdEnemySpawnFrecuency = 0.70f;

        dropsProbability = 0.60f;
    }

    public static void applyDifficultyLeifDamage_Receives(float d){
        resistenciaLeif *= d;
    }

    public static void applyDifficultyLeifDamage_Give(float d){
        damageLeif_givesEspada *= d;
        damageLeif_givesHacha *= d;
        damageLeif_givesFlecha *= d;
        damageLeif_givesCuchillo *= d;
        damageLeif_givesBomba *= d;
    }

    public static void applyDifficultyEnemiesDamage(float d){
        basicEnemyAttack_give *= d;
        basicEnemyAttack_receive *= d;
        //
        heavyEnemyAttack_give *= d;
        heavyEnemyAttack_receive *=  d;
        //
        archerEnemyAttack_give *= d;
        archerEnemyAttack_receive *= d;
        //
        swordmanEnemyAttack_give *= d;
        swordmanEnemyAttack_receive *= d;
        //
        boss1EnemyAttack_give *= d;
        boss1EnemyAttack_receive *= d;
        //
        boss5EnemyAttack_give *= d;
        boss5EnemyAttack_receive *= d;
        //
        boss6EnemyAttack_give *= d;
        boss6EnemyAttack_receive *= d;
        //
        birdEnemySpawnFrecuency *= d;
    }

    public static void applyDifficultyEnemiesVelocity(float d){
        //
        basicEnemyAttack_velocity *= d;
        //
        basicEnemyAttack_velocity *= d;
        //
        swordmanEnemyAttack_velocity *= d;
        //
        boss1EnemyAttack_velocity *= d;
        //
        boss5EnemyAttack_velocity *= d;
        //
        boss6EnemyAttack_velocity *= d;
        //
        birdEnemyVelocity *= d;
        birdEnemyRockVelocity *= d;
    }

    public static void applyDifficultyDrops(float d){
        dropsProbability *= d;
    }
}
