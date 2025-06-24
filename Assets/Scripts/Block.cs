using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameManager _GameManager;  //BlockManager���擾���邽�߂̔�

    private void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _GameManager.AddBlock();  //BlockManager��AddBlock���\�b�h���g�p
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")  //�����^�O��"Ball"�̃I�u�W�F�N�g�ɓ���������
        {
            _GameManager.BlockDestroyed();  //BlockMnager��BlockDestroyed���\�b�h���g�p
            Destroy(gameObject);  //����������
        }
    }
}