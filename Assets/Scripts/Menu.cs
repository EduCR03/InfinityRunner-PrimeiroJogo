using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //armazenadno o nome do player
    [SerializeField]
    private GameObject nameDB;
    public void StartGame()
    {
        //comando para fazer cm q esse nome seja mantido em todas as cenas do projeto
        PlayerPrefs.SetString("PlayerName", nameDB.GetComponent<Text>().text);
        SceneManager.LoadScene(0);

    }

}
