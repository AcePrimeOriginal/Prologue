using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    public void StartNew()
    {
        SceneManager.LoadScene(0);
    }
}
