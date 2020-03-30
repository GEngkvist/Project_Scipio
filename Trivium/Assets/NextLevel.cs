using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPGM.Gameplay;
using UnityEngine.U2D;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void Town()
    {
        Debug.Log("TO TOWN");
        SceneManager.LoadScene("Town");
    }
}
