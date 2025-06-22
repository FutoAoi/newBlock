using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] BlockManager blockManager;  //BlockManager���擾���邽�߂̔�

    private void Start()
    {
        blockManager = GameObject.Find("BlockManager").GetComponent<BlockManager>();
        blockManager.AddBlock();  //BlockManager��AddBlock���\�b�h���g�p
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")  //�����^�O��"Ball"�̃I�u�W�F�N�g�ɓ���������
        {
            blockManager.BlockDestroyed();  //BlockMnager��BlockDestroyed���\�b�h���g�p
            Destroy(gameObject);  //����������
        }
    }
}