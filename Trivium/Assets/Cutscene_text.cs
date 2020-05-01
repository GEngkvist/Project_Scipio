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

    public void MountainLevel()
    {
        SceneManager.LoadScene("1. Mountain");
    }

    public void ForestLevel()
    {
        SceneManager.LoadScene("2. Forest");
    }

    public void CastleLevel()
    {
        SceneManager.LoadScene("3. Castle");
    }

    public void MenueLevel()
    {
        SceneManager.LoadScene("Menu");
    }
}
