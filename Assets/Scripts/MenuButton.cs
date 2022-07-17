using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void LoadScene (string name) {
        // sound!
        FindObjectOfType<AudioManager>().Play("click");

        SceneManager.LoadScene(name);
    }
}
