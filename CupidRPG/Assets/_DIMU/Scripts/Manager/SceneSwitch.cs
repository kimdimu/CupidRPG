﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    public void SwitchScene(string scenestring)
    {
        SceneManager.LoadScene(scenestring);
    }
}
