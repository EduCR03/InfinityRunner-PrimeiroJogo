using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    //referenciando a bomba
    public GameObject bombPrefab;
    //referenciando o spawn da bomba
    public Transform firePoint;

    //variaveis para fazer um contador
    public float throwTime;
    private float throwCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        throwCount += Time.deltaTime;

        if(throwCount >= throwTime)
        {
            //arremessando uma bomba, apartir de um game object, de um ponto de partida criado na Unity
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            throwCount = 0f;
            
        }
       
    }
    
}
