using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rig;

    //dano da bomba
    public int damage;
    //refernciando o player
    private Player player;

    //vairiaveis para fazer o projeto movimentar em forma de parabola
    //decido seus valores na Unity
    public float xAxis;
    public float yAxis;

    // Start is called before the first frame update
    void Start()
    {
        //colocando a Unity para procurar um objeto player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //verificando se a bomba vai encostar no player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //cahamdno o metodo que tira
            player.OnHit(damage);
        }
    }
}
