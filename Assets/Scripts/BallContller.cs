using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float _BollSpeed = 5.0f;  //ボールの速度の変数
    [SerializeField] float _SpeedChanger = 1.01f;  //速度変更の倍率
    [SerializeField] float _SpeedChangeSpan = 5f;  //速度変化の間隔
    [SerializeField] float _MinSpeed = 0.05f;
    [SerializeField] Vector3 _AddX = new Vector3 (0.05f, 0f, 0f);
    [SerializeField] Vector3 _AddY = new Vector3(0f, 0.05f, 0f);

    Rigidbody2D _rb;  //Rigidbodyを取得するための箱
    float _time;  //速度変更してからの経過時間を測る変数

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();  //Rigidbodyを取得
        _rb.velocity = new Vector3(1f, 1f).normalized * _BollSpeed;  //ボールを斜め右に射出
        _time = Time.time;
    }
    private void Update()
    {
        //_time += Time.deltaTime;  //経過時間を測る
        if (Time.time - _time > _SpeedChangeSpan)  //もし経過時間が速度変更の間隔よりも大きくなったら
        {
            _rb.velocity = _rb.velocity * _SpeedChanger;  //ボールの速度に速度変更の倍率をかける
            _time = Time.time;  //経過時間を0にする
        }

        float _SpeedX = Mathf.Abs(_rb.velocity.x);
        float _SpeedY = Mathf.Abs(_rb.velocity.y);

        if (_SpeedX < _MinSpeed)
        {
            _rb.AddForce(_AddX * Mathf.Sign(_rb.velocity.x));
        }

        if (_SpeedY < _MinSpeed)
        {
            _rb.AddForce(_AddY * Mathf.Sign(_rb.velocity.y));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadZone"))  //もしタグが"Ball"のオブジェクトに当たったら
        {
            Destroy(this.gameObject);  //Ballを消す
        }
    }
}
