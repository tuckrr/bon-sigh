using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button buttonQuit;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(delegate { GoToScene("Tree1"); });
        button2.onClick.AddListener(delegate { GoToScene("Tree2"); });
        button3.onClick.AddListener(delegate { GoToScene("Tree3"); });
        buttonQuit.onClick.AddListener(Application.Quit);
    }

    void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
