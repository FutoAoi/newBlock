using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] BlockManager _BlockManager;  //BlockManager���擾���邽�߂̔�

    private void Start()
    {
        _BlockManager = GameObject.Find("BlockManager").GetComponent<BlockManager>();
        _BlockManager.AddBlock();  //BlockManager��AddBlock���\�b�h���g�p
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")  //�����^�O��"Ball"�̃I�u�W�F�N�g�ɓ���������
        {
            _BlockManager.BlockDestroyed();  //BlockMnager��BlockDestroyed���\�b�h���g�p
            Destroy(gameObject);  //����������
        }
    }
}