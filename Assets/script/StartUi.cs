using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUi : MonoBehaviour
{
    public void NewGame() {
        SceneManager.LoadScene(1);

    }

    public void OldGame() {
        SceneManager.LoadScene(1);
    }
}
