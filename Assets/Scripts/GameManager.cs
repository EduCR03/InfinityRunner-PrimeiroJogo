using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//biblioteca que permita manipular scenas
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //manipulando o texto dentro da Unity
    public Text scoreText;

    //refenciando o painel de game over
    public GameObject gameOverPanel;
    //para acessar qualquer metodo ou variavel dessa classe usando instance. alguma coisa
    //"variavel global"
    public static GameManager instance;

    //variavel para contabilizar um score
    public float totalScore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //todas as vezes que o GameManager for lido ele vai mudar o timeScale para 1, deixando o tempo do jogo padrao
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //criando uma funcao para ativar a tela de game over
    public void ShowGameOver()
    {
        //comando para ativar o painel
        gameOverPanel.SetActive(true);
        //parando o jogo apos o personagem morrer
        //timeScale -> tempo de execucao do jogo, 0 pauso o jogo
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        //chamando a unica fase que tem o jogo, reiniciando ele
        SceneManager.LoadScene(1);
    }

    public void UpdateScoreText()
    {
        //atualizando o placar do jogo
        scoreText.text = totalScore.ToString();
    }
}
