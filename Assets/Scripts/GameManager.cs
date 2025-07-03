using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _TimeLimit = 100f;
    [SerializeField] PaddleMove _PaddleMove;
    [SerializeField] TextMeshProUGUI _GameOver;
    [SerializeField] TextMeshProUGUI TextMeshProUGUI;

    private int _BlockCount = 0;  //�u���b�N�𐔂���ϐ�
    private int _BallCount = 0;
    private bool _isGameOver;
    private bool _isGameClear;

    private void Start()
    {
        _PaddleMove = GameObject.Find("Paddle").GetComponent<PaddleMove>();
        _PaddleMove._InGame = true;
        _PaddleMove.Shield();
        _isGameOver = false;
        _isGameClear = false;
    }

    private void Update()
    {
        _TimeLimit -= Time.deltaTime;
        TextMeshProUGUI.text = _TimeLimit.ToString("f1");

        if (_TimeLimit < 0 && _isGameClear == false)
        {
            Invoke("LoadNextScene", 4);
            _GameOver.color = Color.red;
            _GameOver.text = "Game Over";
            _isGameOver = true;
            _TimeLimit = 0;
        }
    }

    public void AddBlock()  //�u���b�N�̐��𑝂₷���\�b�h
    {
        _BlockCount++;  //�u���b�N�̐��𑝂₷
    }

    public void AddBall()
    {
        _BallCount++;
    }

    public void BlockDestroyed()  //�u���b�N�̐������炷���\�b�h
    {
        _BlockCount--;  //�u���b�N�̐�������炷
        _PaddleMove.BreakBlockCount();

        if (_BlockCount <= 0 && _isGameOver == false)  //�����u���b�N�̐���0��菭�Ȃ��Ȃ�
        {
            Invoke("LoadNextScene", 4);
            _GameOver.color = Color.yellow;
            _GameOver.text = "Game Clear";
            _isGameClear = true;
        }
    }

    public void BallDestroyed()
    {
        _BallCount--;

        if(_BallCount <= 0 && _isGameClear == false)
        {
            Invoke("LoadNextScene", 4);
            _GameOver.color = Color.red;
            _GameOver.text = "Game Over";
            _isGameOver = true;
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(1);
        _PaddleMove._breakBlockCount = 0;
        _PaddleMove._InGame = false;
    }
}
