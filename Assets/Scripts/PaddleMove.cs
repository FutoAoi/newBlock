using System;
using UnityEngine;
public class PaddleMove : MonoBehaviour
{
    [SerializeField] GameObject BallPrehab;
    [SerializeField] GameObject GhostPaddlePrehab;
    [SerializeField] GameObject ShieldPrehab;

    public float _PaddleSpeed = 10f;  //�p�h���X�s�[�h�̕ϐ�
    public int _CoinParcent = 50;
    public int _HaveCoin = 0;
    private float _GhostSpanTime = 10f;
    private float _Time;

    [HideInInspector,Range(0, 5)] public int _SpeedLevel = 0;
    [HideInInspector,Range(0, 5)] public int _PaddleScaleLevel = 0;
    [HideInInspector,Range(0, 5)] public int _CreateSpanLevel = 0;
    [HideInInspector,Range(0, 1)] public int _ShieldLevel = 0;
    [HideInInspector,Range(0, 1)] public int _GhostLevel = 0;

    [HideInInspector] public bool _InGame = false;  //�Q�[�������̔���
    [HideInInspector] public bool _canCreate = false;
    [HideInInspector] public bool _canGhost = false;
    [HideInInspector] public bool _canShield = false;

    private float x;  //���������̏����̒l������ϐ�
    private float y;  //���������̏����̒l������ϐ�
    private float clampedX;  //�N�����v�������X
    private float clampedY;  //�N�����v�������Y
    private float moveX;
    private float moveY;
    private int _breakBlockCount;
    private int _Random;
    private Transform _tf;  //Transform���擾���邽�߂̕ϐ�
    private void Awake()
    {
        DontDestroyOnLoad(this);  //���̃I�u�W�F�N�g���V�[���ڍs�Ŕj�����Ȃ�
        _breakBlockCount = 0;
    }
    void Start()
    {
        Application.targetFrameRate = 60;  //�t���[�����[�g��60�ɌŒ�
        _tf = GetComponent<Transform>();  //Transform���擾
    }
    void Update()
    {
        Move();  //Move()���\�b�h
        CreateBall(_CreateSpanLevel);
        Ghost();
    }
    private void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        moveX = x * _PaddleSpeed * Time.deltaTime;
        clampedX = Mathf.Clamp(_tf.position.x + moveX, -7.5f, 7.5f);
        if (_InGame == false)  //�Q�[��������Ȃ����
        {
            y = Input.GetAxisRaw("Vertical");
            moveY = y * _PaddleSpeed * Time.deltaTime;
            clampedY = Mathf.Clamp(_tf.position.y + moveY, -4.5f, 4.5f);
        }
        else if (_InGame == true)  //�Q�[������������
        {
            clampedY = -4.3f;
        }
        _tf.position = new Vector3(clampedX, clampedY, 0f);
    }
    public void Shield()
    {
        if (!_canShield) return;
        if (!_InGame) return;

        Instantiate(ShieldPrehab,new Vector3(0f, -5.1f, 0f), Quaternion.identity);
    }

    private void Ghost()
    {
        if (!_canGhost) return;
        if (!_InGame) return;
        _Time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && _Time > _GhostSpanTime)
        {
            Instantiate(GhostPaddlePrehab, this.transform.position, Quaternion.identity);
            _Time = 0f;
        }
    }

    private void CreateBall(int createspanrevel)
    {
        if (!_canCreate) return;
        if (_breakBlockCount > 6 - createspanrevel)
        {
            Instantiate(BallPrehab, this.transform.position + new Vector3(0f , 0.1f, 0f), Quaternion.identity);
            _breakBlockCount = 0;
        }
    }

    public void BreakBlockCount()
    {
        _breakBlockCount++;
        Coin();
    }

    public void Coin()
    {
        _Random = UnityEngine.Random.Range(0, 100);

        if (_Random < _CoinParcent)
        {
            _HaveCoin++;
        }
    }
}