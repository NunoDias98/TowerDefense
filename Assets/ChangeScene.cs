using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void escolhaNiveis()
    {
        SceneManager.LoadScene("EscolhaNivel");
    }
    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
