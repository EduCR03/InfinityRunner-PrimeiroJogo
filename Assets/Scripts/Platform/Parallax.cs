using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //criando um ciclo da paisagem de fundo
    //aramazenando a largura do background
    private float length;
    //armazenando a posiciao inical do background
    private float startPos;
    //referenciando a posicao da camera
    public Transform cam;
    //passando uma velocidade para o parallax
    public float parallaxFactor;


    // Start is called before the first frame update
    void Start()
    {
        //aramazenando a posicao inincal do objeto
        //movimentamos apenas no x
        startPos = transform.position.x;
        //salvando sua largura
        //nesse comando eu pego a largura do objeto em pixels, de uma ponta a outra em pixelss
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    //vou usar LteUpdate para deixar a moviemntacao mais suave q o Update
    void LateUpdate()
    {
        //reposicionando o bakcground para ele nao sair da imagem
        //pelo o numero 1 eu consigo alterar a distancia que o background ira se reposicionar
        float reposition = cam.transform.position.x * (1 - parallaxFactor);
        //aramazendnado a posicao x da camera mukltiplicando pela velocidade que eu passar na Unity
        float distance = cam.transform.position.x * parallaxFactor;
        //movendo em x
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        //fazendo a logica para reposicionar
        //startPos + lenght => é a posicao final do background, o seu inicio mais seu comprimento
        if(reposition > startPos + length)
        {
            //qnd isso acontecer eu vou somar a posicao inicial o seu comprimento, fazendo com q ele comece apos o termino do anterior
            startPos += length;
        }

    }
}
