using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene_text : MonoBehaviour
{
    public void nextLevel()
    {
        SceneManager.LoadScene("0.Tutorial");
    }

    public void TownLevel()
    {
        SceneManager.LoadScene("Town");
    }
}
