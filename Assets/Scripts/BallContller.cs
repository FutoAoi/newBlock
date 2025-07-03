using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float _BollSpeed = 5.0f;  //�{�[���̑��x�̕ϐ�
    [SerializeField] float _SpeedChanger = 1.01f;  //���x�ύX�̔{��
    [SerializeField] float _SpeedChangeSpan = 5f;  //���x�ω��̊Ԋu
    [SerializeField] float _MinSpeed = 0.05f;
    [SerializeField] Vector3 _AddX = new Vector3 (0.05f, 0f, 0f);
    [SerializeField] Vector3 _AddY = new Vector3(0f, 0.05f, 0f);

    Rigidbody2D _rb;  //Rigidbody���擾���邽�߂̔�
    float _time;  //���x�ύX���Ă���̌o�ߎ��Ԃ𑪂�ϐ�

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();  //Rigidbody���擾
        _rb.velocity = new Vector3(1f, 1f).normalized * _BollSpeed;  //�{�[�����΂߉E�Ɏˏo
        _time = Time.time;
    }
    private void Update()
    {
        //_time += Time.deltaTime;  //�o�ߎ��Ԃ𑪂�
        if (Time.time - _time > _SpeedChangeSpan)  //�����o�ߎ��Ԃ����x�ύX�̊Ԋu�����傫���Ȃ�����
        {
            _rb.velocity = _rb.velocity * _SpeedChanger;  //�{�[���̑��x�ɑ��x�ύX�̔{����������
            _time = Time.time;  //�o�ߎ��Ԃ�0�ɂ���
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
        if (other.CompareTag("DeadZone"))  //�����^�O��"Ball"�̃I�u�W�F�N�g�ɓ���������
        {
            Destroy(this.gameObject);  //Ball������
        }
    }
}
