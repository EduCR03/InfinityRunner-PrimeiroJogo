using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    //criando uma lista de inimigos, uma lista de gameObjects
    public List<GameObject> enemiesList = new List<GameObject>();

    //variaveis usadas para criar uma contagem de spawn de inimigos
    private float timerCount;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        //chamando o metodo para criar um inimigo no comeco do jogo
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime retorna segunda da vida real
        //ou seja eu estou passando o tempo q esta demorando no jogo pro timeCount
        timerCount += Time.deltaTime;
        

        //quando esse tempo for maior ou igual ao tempo que eu escolher eu crio um inimigo nesse tempo escolhido
        if(timerCount >= spawnTime)
        {
            //instanciando inimigo
            SpawnEnemy();
            //zero o timerCount para poder criar outro inimigo a cada tempo q eu colocar na Unity
            //reiniciando a contagem
            timerCount = 0f;
        }
    }

    void SpawnEnemy()
    {
        //criando um inimigo na msm posicao do objeto vazio criado na Unity e colocado do lado de fora da cena
        //Instantiate(enemiesList[0], transform.position, transform.rotation);

        //criando um inimigo em lugares aleatorios da tela, no caso variando o eixo y
        //transform.position + new Vector3(0, Random.Range(-1f,3f),0) -> ele soma a posicao do SpawnEnemies um valor aleatorio na margem que eu escolher
        //(-1 e 3) criando o inimigo em alturas variadas na imagem
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0, Random.Range(-3.6f, 2.89f), 0), transform.rotation);
    }


}
