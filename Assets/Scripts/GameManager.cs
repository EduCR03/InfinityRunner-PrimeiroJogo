using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//biblioteca que permita manipular scenas
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;
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

    //variavel para contabilizar um score vc tem que parar de criar tanta variavel publica kkkkkk
    public  float totalScore;

    private float totalScoreDB;


    private string PlayerName;

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
        CheckPoints();

    }
    // criar função para verificar a pontuação do banco
    public void CheckPoints() {
        PlayerName = PlayerPrefs.GetString("PlayerName");
        try
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=endless_runner;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select User_Points from usuarios where User_Name = '" + PlayerName + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            totalScoreDB = reader.GetFloat(0);

            if (totalScoreDB <= totalScore)
            {
                Debug.Log(totalScore);
                UpdateScoreDB();
            }
        }
        catch (System.Exception)
        {

            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=endless_runner;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into usuarios (User_Name, User_Points) values ('" + PlayerName + "', '" + totalScore + "')";
            cmd.ExecuteNonQuery();
        }
      

    }


    // criando função para inserir os pontos no banco

    public void UpdateScoreDB()
    {
        try
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=endless_runner;Uid=root;Pwd=;");
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE usuarios SET User_Points = '"+totalScore+"' WHERE User_Name = '"+PlayerName+"'";
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException erro)
        {
            Debug.Log(erro.Message);
           
        }
       

    }
    public void RestartGame()
    {
        //chamando a unica fase que tem o jogo, reiniciando ele
        SceneManager.LoadScene(0);
    }

    public void UpdateScoreText()
    {
        //atualizando o placar do jogo
        scoreText.text = totalScore.ToString();
    }
}
