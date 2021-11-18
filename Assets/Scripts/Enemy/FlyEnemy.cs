using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mono behavior ja esta sendo "Herdado" na classe inimigo
public class FlyEnemy : Enemy
{
    private Rigidbody2D rig;
    public int speed;
    //refernciando o player
    //private Player player;

    // Start is called before the first frame update
    void Start()
    {
        //colocando a Unity para procurar um objeto player
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        //Vector2.left -> passa o valor de x = -1 e y = 0
        //sempre movendo para a esquerda
        rig.velocity = Vector2.left * speed;
    }

    ////verificando se eles vao encostar no player, usando o metodo pronto na classe enemy
    //protected override void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        //cahamdno o metodo que tira a vida de player
    //        player.OnHit(damage);
    //    }
    //}
}
