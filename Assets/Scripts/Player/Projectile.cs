using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed;
    public int damage;
    //referenciando o rigidbody do projetil
    private Rigidbody2D rig;

    public GameObject expPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //passando o componente rigidbody 2d
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 0.3f);
    }

    //Usar o Fixed Update qnd se trata de RigidBody
    // Update is called once per frame
    void FixedUpdate()
    {
        //passando uma velocidade/direcao pro projetil, .right pq ele vai sempre pra direita
        rig.velocity = Vector2.right * speed;
    }

    //instaciando o efeito de explosao e dps destruindo a bala
    public void OnHit()
    {
        GameObject dam = Instantiate(expPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(dam, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            OnHit();
        }
    }

}
