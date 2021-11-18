using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //vida do player
    public float health;

    //referneciando o rigidibody
    private Rigidbody2D rig;
    //referenciando o animator do personagem
    //tem que seu public pq ele esta no sprite
    public Animator anim;

    //variavel pra saber se o player esta pulando
    private bool isJumping;
    //variavel pra guardar o tempo
    public float timer;

    //refernciando o prefab do tiro(bala)
    public GameObject bulletPrefab;
    //referenciando a posicao de spawn da bala
    public Transform bulletSpawn;
    //referenciando a iamgem da barra ede vida
    public Image lifeBar;

    public int speed;
    public int jumpForce;
    public bool doubleJump;
    public float doubleJumpForce;


    // Start is called before the first frame update
    void Start()
    {
        //passando o componente Rigid Body do player para a referencia do tipo Rigid Body que criamos
        rig = GetComponent<Rigidbody2D>();

    }

    //OBS:
    //Quando for manipular o Rigid Body de maneira geral, é interessando usar o Fixed Update ao inves do Update

    void FixedUpdate() //chamado pela fisica da Unity, nao é nescessariamente chamado a cada frame, meio que foi feito para fisica
    {
        //adicionanado velocidade linear ao personagem
        //para o x positivo, direita (nesse caso)
        //rig.velocity .y -> basicamente nao passa nada, na pratica pega a msm velocidade do proprio corpo
        timer += Time.deltaTime;
        rig.velocity = new Vector2(speed + (timer * 0.01f), rig.velocity.y);

        //contabilizando a pontuacao
        GameManager.instance.totalScore += Time.timeScale;
        GameManager.instance.UpdateScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        //esse codigo pode colocar no Update, pois é apenas um gatilho, funciona apenas qnd apertamos espaco
        //colocando o pulo no personagem ao apertar espaco

        //addFroce -> adiciona um "Tranco" ao personagem semelhante ao pulo q precisamos
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }

        //Lendo se o player apertou uma tecla para atirar
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnShoot();
        }

       lifeBar.fillAmount = health / 3;

    }

    //criando metodos para usar os botoes da tela
    public void OnShoot()
    {
        //crinado o objeto bala, na posicao do game object vazio que eu criei no playere
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    public void OnJump()
    {
        if (isJumping == false)
        {
            //ForceMode2D -> para decidir qual tipo de forca queremos adcionar
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //ativando a animacao
            anim.SetBool("jumping", true);
            isJumping = true;
            doubleJump = true;
        }
        //adicionando pulo duplo
        else
        {
            if(doubleJump == true)
            {
                rig.AddForce(new Vector2(0f, jumpForce * doubleJumpForce), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }

    }
    public void OnHit(int dmg)
    {
        //decrescendo a vida do personagem pelo dano q eu passar
        health -= dmg;
        //verificando se ele tem vida e se nao tiver vou chamar o painel de game over
        if (health <= 0)
        {
            GameManager.instance.ShowGameOver();
        }
    }


    //DETECTANDO SE O PLAYER ENCOSTOU NO CHAO
    //esse metodo detecta todas as vezes que o objeto encostou em outro colisor
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 6)
        {
            //desativando a animacao de pulo pq ele tocou o chao
            anim.SetBool("jumping", false);
            isJumping = false;
        }
    }

   


}
