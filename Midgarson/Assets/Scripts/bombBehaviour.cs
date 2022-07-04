using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBehaviour : MonoBehaviour
{
    Vector3 currentSpeed = new Vector3();
    Vector3 _deltaPos = new Vector3();
    int damage = 40;
    float damageRange = 10f;
    public LayerMask enemyLayers;
    string explode;
    bool _shooted;
    private Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (!_shooted)
            return;
        _deltaPos = currentSpeed * Time.deltaTime + Physics.gravity * Mathf.Pow(Time.deltaTime, 2) / 2;
        gameObject.transform.Translate(_deltaPos);
        currentSpeed += Physics.gravity * Time.deltaTime;
    }

    public void Shoot(Vector3 startingSpeed, float shootingAngle)
    {
        currentSpeed = new Vector3(startingSpeed.x * Mathf.Cos(shootingAngle), startingSpeed.y * Mathf.Sin(shootingAngle));
        _shooted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool(explode, true);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, damageRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().takeDamage(damage);
        }
        Destroy(gameObject);
    }
    
}
