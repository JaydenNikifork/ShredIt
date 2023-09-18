using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button play = root.Q<Button>("Play");
        Button quit = root.Q<Button>("Quit");

        play.clicked += Play_clicked;
        quit.clicked += Quit_clicked;
    }

    private void Quit_clicked()
    {
        Application.Quit();
    }

    private void Play_clicked()
    {
        SceneManager.LoadScene("Game");
    }
}
