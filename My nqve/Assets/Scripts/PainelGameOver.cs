using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelGameOver : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("SAIU");
    }
}
