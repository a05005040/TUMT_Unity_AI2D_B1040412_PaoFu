using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public int Score;
    public Text KeyCheck,ScoreText;
    public GameObject FinishUI, CompleteText, FaileText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + Score.ToString();
    }

    public void GetCoin()
    {
        Score = Score + 5;
    }
    public void GetKeyFinal()
    {
        Score = Score + 100;
    }
    public void GetKey()
    {
        KeyCheck.text = "KEY(1/1)";
    }
    public void GetKeyCheck()
    {
        KeyCheck.text = "KEY(0/1)";
    }

    public void Complete()
    {
        FinishUI.SetActive(true);
        CompleteText.SetActive(true);

    }
    public void Fail()
    {
        FinishUI.SetActive(true);
        FaileText.SetActive(true);
    }
    public void Again()
    {
        SceneManager.LoadScene("AI2D");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
