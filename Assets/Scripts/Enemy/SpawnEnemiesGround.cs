using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesGround : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject currentEnemy;

    public List<Transform> points = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        CreateEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //fazendo a logica por reposicionamento de plataforma, chamando esse metodo la na classe SpawnPaltform
    public void Spawn()
    {
        //verificando qnd o currentEnemy for nulo
        //ai eu fico sabendo (checo) q o inimigo foi destruido
        if(currentEnemy == null)
        {
            //aki executa se o inimigo for destruido
            CreateEnemy();
        }
    }

    //logica para criar um inimigo q lanca bomba apenas qnd o antecessor for destruido, para nao aumular mts e reaproveitar o inimigo
    //codigo referente a criacao do inimigo
    void CreateEnemy()
    {
        //sortenado o ponto que o inimigo ira nascer, e armazenando em uma variavel
        int pos = Random.Range(0, points.Count);
        GameObject e = Instantiate(enemyPrefab, points[pos].position, points[pos].rotation);
        //toda vez que gerar um inimigo esse currentEnemy ira armazenar ele
        currentEnemy = e;
    }
}
