using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //referenciando o player
    private Transform player;

    //velocidade da camera
    public int speed;
    public int offset;

    // Start is called before the first frame update
    void Start()
    {
        //fazendo a Unity procurar o player e passar a sua posicao
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //LateUpdate -> Ele é chamado mais suavemente em relacao ao Update
    // Update is called once per frame
    void LateUpdate()
    {
        //Qual sera a direcao que a camera vai seguir
        //player.position.x -> passando o x do player (para a camera seguir o boneco do jogador)
        //0f -> para a camera nao mudar sua altura no eixa y
        //transform.position.z -> passando um valor para a camera nao se alterar no eixo z (rotacionar)
        Vector3 newCamPos = new Vector3(player.position.x - offset , 0f, transform.position.z);
        //passadno para a camera uma movimentacao suave
        //Time.deltaTime -> evita que a movimentacao varie mt, ficando mais lenta ou mais rapida dependendo do fps
        transform.position = Vector3.Slerp(transform.position, newCamPos, speed * Time.deltaTime);

    }
}
