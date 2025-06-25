using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [Header("設定必須")]
    [SerializeField] int SkillNumber;
    [SerializeField] TextMeshProUGUI _LevelText;
    [SerializeField] TextMeshProUGUI _ExplamationText;
    [SerializeField,Multiline(3)] string _Explanation;

    [Header("スピードボタン、スケールボタン用")]
    [SerializeField] float _PaddleSpeedChanger = 1.0f;
    [SerializeField] Vector3 _PaddleScaleChanger = new Vector3(0.1f, 0, 0);

    private string _DefaultText = "コインをためてスキルを強化しよう!!";
    private PaddleMove _PaddleMove;
    private GameObject _Paddle;
    private SpriteRenderer _SpriteRenderer;

    private bool inButton = false;

    private Color _Defaultcolor;

    private void Start()
    {
        _Paddle = GameObject.Find("Paddle");
        _PaddleMove = _Paddle.GetComponent<PaddleMove>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Defaultcolor = _SpriteRenderer.color;
        StatusUpdate();
    }
    private void Update()
    {
        if (inButton == true && Input.GetKeyDown(KeyCode.Space))
        {
            switch (SkillNumber)
            {
                case 0:
                    _PaddleMove._PaddleSpeed += _PaddleSpeedChanger;
                    _PaddleMove._SpeedLevel++;
                    _LevelText.text = _PaddleMove._SpeedLevel.ToString();
                    break;
                case 1:
                    _Paddle.transform.localScale += _PaddleScaleChanger;
                    _PaddleMove._PaddleScaleLevel++;
                    _LevelText.text = _PaddleMove._PaddleScaleLevel.ToString();
                    break;
                case 2:
                    _PaddleMove._canCriate = true;
                    _PaddleMove._CriateSpanLevel++;
                    _LevelText.text = _PaddleMove._CriateSpanLevel.ToString();
                    _ExplamationText.text = $"{6 - _PaddleMove._CriateSpanLevel}個ブロックを壊すごとにボールを生成する";
                    break;
                case 3:
                    _PaddleMove._canShield = true;
                    _PaddleMove._ShieldLevel++;
                    _LevelText.text = _PaddleMove._ShieldLevel.ToString();
                    break;
                case 4:
                    _PaddleMove._canGhost = true;
                    _PaddleMove._GhostLevel++;
                    _LevelText.text = _PaddleMove._GhostLevel.ToString();
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            _SpriteRenderer.color = Color.white;
            inButton = true;
            if (SkillNumber == 2)
            {
                _ExplamationText.text = $"{6 - _PaddleMove._CriateSpanLevel}個ブロックを壊すごとにボールを生成する";
            }
            else
            {
                _ExplamationText.text = _Explanation;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            _SpriteRenderer.color = _Defaultcolor;
            inButton = false;
            _ExplamationText.text = _DefaultText;
        }
    }
    void StatusUpdate()
    {
        switch(SkillNumber)
        {
            case 0:
                _LevelText.text = _PaddleMove._SpeedLevel.ToString();
                break;
            case 1:
                _LevelText.text = _PaddleMove._PaddleScaleLevel.ToString();
                break;
            case 2:
                _LevelText.text = _PaddleMove._CriateSpanLevel.ToString();
                break;
            case 3:
                _LevelText.text = _PaddleMove._ShieldLevel.ToString();
                break;
            case 4:
                _LevelText.text = _PaddleMove._GhostLevel.ToString();
                break;
        }
    }
}