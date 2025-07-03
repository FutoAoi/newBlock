using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _TimeLimit = 100f;
    [SerializeField] PaddleMove _PaddleMove;

    public TextMeshProUGUI TextMeshProUGUI;
    private int _BlockCount = 0;  //ブロックを数える変数
    private int _BallCount = 0;

    private void Start()
    {
        _PaddleMove = GameObject.Find("Paddle").GetComponent<PaddleMove>();
        _PaddleMove._InGame = true;
        _PaddleMove.Shield();
    }

    private void Update()
    {
        _TimeLimit -= Time.deltaTime;
        TextMeshProUGUI.text = _TimeLimit.ToString("f1");

        if (_TimeLimit < 0)
        {
            Invoke("LoadNextScene", 5);
            _TimeLimit = 0;
        }
    }

    public void AddBlock()  //ブロックの数を増やすメソッド
    {
        _BlockCount++;  //ブロックの数を増やす
    }

    public void AddBall()
    {
        _BallCount++;
    }

    public void BlockDestroyed()  //ブロックの数を減らすメソッド
    {
        _BlockCount--;  //ブロックの数を一つ減らす
        _PaddleMove.BreakBlockCount();

        if (_BlockCount <= 0)  //もしブロックの数が0より少ないなら
        {
            LoadNextScene();
        }
    }

    public void BallDestroyed()
    {
        _BallCount--;

        if(_BallCount <= 0)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(1);
        _PaddleMove._InGame = false;
    }
}
