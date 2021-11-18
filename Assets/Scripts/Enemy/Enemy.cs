using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    //metodo que eu posso reescrever
    public virtual void ApplyDamage(int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    //virtual para reescrever
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Se for um objeto com a tag bullet que enconstar no inimigo é pq é a bala que esta batendo
        if(collision.CompareTag("Bullet"))
        {
            int dmg =  collision.GetComponent<Projectile>().damage;
            //desrtuindo a bala apos tocar no inimido
            collision.GetComponent<Projectile>().OnHit();
            ApplyDamage(dmg);
        }

        if (collision.CompareTag("Player"))
        {
            //cahamdno o metodo que tira a vida de player
            collision.GetComponent<Player>().OnHit(damage);
        }
    }
}
