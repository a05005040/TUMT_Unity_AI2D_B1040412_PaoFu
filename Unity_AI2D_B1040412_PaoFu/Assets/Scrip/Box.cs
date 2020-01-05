using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public string StartStr = "找到了奇怪的寶箱!";
    public string IngStr = "需要鑰匙才能開...";
    public string EndStr = "恭喜你找到寶藏了!";
    public int countPlayer;
    public int countFinish = 10;
    public float speed = 1.5f;
    public Text Text;
    public GameObject UI,Main;
    public AudioClip Talk;
    AudioSource Myaud;
    public enum state
    {
        start, notComplete, complete
    }
    public state _state;

    // Start is called before the first frame update
    void Start()
    {
        Myaud = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果碰到物件為"player"
        if (collision.name == "Player")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            SayClose();
        if (_state== 0)
        {
            _state = state.notComplete;
            Main.GetComponent<Main>().GetKeyCheck();
        }
    }

    private void Say()
    {
        // 畫布.顯示
        UI.SetActive(true);
        StopAllCoroutines();


        // 判斷式(狀態)
        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDialog(StartStr));      
                
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(IngStr));    
                break;
            case state.complete:
                StartCoroutine(ShowDialog(EndStr));
                Main.GetComponent<Main>().GetKeyFinal();
                Main.GetComponent<Main>().Complete();
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        Text.text = "";                              // 清空文字

        for (int i = 0; i < say.Length; i++)            // 迴圈跑對話.長度
        {
            Text.text += say[i].ToString();          // 累加每個文字
            Myaud.PlayOneShot(Talk);
            yield return new WaitForSeconds(speed);     // 等待
        }
    }


    private void SayClose()
    {
        StopAllCoroutines();
        UI.SetActive(false);
    }
    public void Complete()
    {
        _state = state.complete;
    }

}
