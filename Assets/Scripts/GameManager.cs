using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _TimeLimit = 100f;
    [SerializeField] PaddleMove _PaddleMove;

    public TextMeshProUGUI TextMeshProUGUI;
    private int _BlockCount = 0;  //�u���b�N�𐔂���ϐ�

    private void Start()
    {
        _PaddleMove = GameObject.Find("Paddle").GetComponent<PaddleMove>();
        _PaddleMove._InGame = true;
    }

    private void Update()
    {
        _TimeLimit -= Time.deltaTime;
        TextMeshProUGUI.text = _TimeLimit.ToString("f1");

        if (_TimeLimit < 0)
        {
            Invoke("LoadNextScene", 5);
        }
    }

    public void AddBlock()  //�u���b�N�̐��𑝂₷���\�b�h
    {
        _BlockCount++;  //�u���b�N�̐��𑝂₷
    }

    public void BlockDestroyed()  //�u���b�N�̐������炷���\�b�h
    {
        _BlockCount--;  //�u���b�N�̐�������炷

        if (_BlockCount <= 0)  //�����u���b�N�̐���0��菭�Ȃ��Ȃ�
        {
            LoadNextScene(1);
        }
    }

    void LoadNextScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
