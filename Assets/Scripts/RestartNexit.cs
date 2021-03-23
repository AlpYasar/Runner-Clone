using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartNexit : MonoBehaviour
{

    public void ExitButton()
    {
        Application.Quit();
    }

    public void RestartButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
