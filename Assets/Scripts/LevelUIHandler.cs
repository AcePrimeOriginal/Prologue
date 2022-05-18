using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIHandler : MonoBehaviour
{
    public void StartNew()
    {
        SceneManager.LoadScene(2);
    }
}
