using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    //referenciando as plataformas usando lista, criando a lista de plataformas
    //lista dos prefabs das plataformas
    public List<GameObject> platforms = new List<GameObject>();

    //criando outra lista para acessar as plataformas clones criadas
    //lista das plataformas criadas na cena
    //private nao vai aparecer na Unity, no inspector 
    private List<Transform> currentPlatforms = new List<Transform>();

    //referenciando o player
    private Transform player;
    //plataform atual do player
    private Transform currentPlatformPoint;
    //valor da plataforma atual (i do for)
    private int platformIndex = 0;

    //variavel para nunca perder o valor do posicionamento das plataformas
    //recebendo sempre o valor atual do i*30
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        //buscando um game object com a tag player e associando a variavel q eu criei, e passando seu transform pra varivel (q pe transform)
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //criando novas plataformas de acordo com a quantidade de plataformas
        for (int i = 0; i < platforms.Count; i++)
        {
            //Instantiate -> preciso passar tres argumentos, nome do objeto q eu quero criar uma copia, uma posicao e uma rotacao 
            //instantiate cria um GameObject e nao um Transform

            //para o objeto ir pro lado eu preciso mudar o x, com plataformas de msm comprimento
            //toda vez que for gerar uma plataforma vou multiplicar por 30 (valor que eu decidi ao testar o posicionamento das plataformas)

            Transform p = Instantiate(platforms[i], new Vector2(i*30, -4.5f), transform.rotation).transform;

            //adicioando os prefabs na lista 
            currentPlatforms.Add(p);

            //toda vez q o for rodar o offset vai ser somado 30
            offset += 30f;

        }

        //passando qual a plataforma atual do player, acessando a lista de plataformas criadas e pegando o Index, q é
        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //checando o tempo todo a diferenca da distancia entre o player e o final da plataforma, com o game object final point
    void Move()
    {
        //subtraindo a posicao x da plataforma atual, a posicao do player
        //salvando a diferenca entre o player e o final point da plataforma atual
        float distance = player.position.x - currentPlatformPoint.position.x;
        
        //verificando se essa distancia for maior q 1
        if (distance >= 1) //se o distance for maior que 1, o codigo recicla a plataforma, chamando o metodo recycle
        {
            //chamando o metodo recycle, e passando para ele a plataforma atual
            Recycle(currentPlatforms[platformIndex].gameObject);
            //somando mais um ao platformIndex, pra adicionar a proxima plataforma
            platformIndex++;

            //corringido o erro de q qnd chegam ao numero de plataformas colocadas ele para de gerar a proxima plataforma
            if(platformIndex > currentPlatforms.Count - 1)
            {
                //sempre que o valor de platformIndex for maior que o o tamanho da lista das plataformas clone, ele vai passar a valer 0
                //podendo assim continuar sem dar o erro de q acabaram as plataformas
                platformIndex = 0;
            }


            //precisamos referenciar o proximo proximo
            //dps q eu passo do final da plataforma eu ja tenho outro final point
            //passando ele aki
            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }
    }

    //logica para reciclagem das plataformas
    public void Recycle(GameObject platform)
    {
        //ele vai pegar a plataforma q eu acabei de passar e vai empurrar pra frente, jogando ela pra ser a proxima plataforma, usando apenas duas plataformas
        //serve pra otimizar projeto
        //utilizo duas ou um pouco mais, no final elas viram milhares

        platform.transform.position = new Vector2(offset, -4.5f);
        //chamar apenas na plataforma que tem um spanw
        if(platform.GetComponent<Platform>().spawnObj != null)
        {
            platform.GetComponent<Platform>().spawnObj.Spawn();
        }
        
        offset += 30;
    }
}
