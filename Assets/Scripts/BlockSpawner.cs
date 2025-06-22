using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject _BlockPrehab;  //�u���b�N�̃v���n�u

    public int _Height = 5;  //�c
    public int _Width = 8;   //��
    public float _spacing = 0.1f;  //�u���b�N�̊Ԋu

    Vector2 _BlockSize;  //�u���b�N�̃T�C�Y
    Vector2 _StartPos;  //�u���b�N��u���n�߂�ʒu
    Vector2 _Pos;  //�u���b�N��u���ʒu
    void Start()
    {
        SpawnBlock();  //�Q�[���J�n���Ƀu���b�N��u��
    }
    void SpawnBlock()  //�u���b�N�̃X�|�[������
    {
        _BlockSize = _BlockPrehab.GetComponent<SpriteRenderer>().bounds.size;  //�u���b�N�̃T�C�Y���擾(�v���n�u��)
        _StartPos = new Vector2(-((_Width - 1) * (_BlockSize.x + _spacing)) / 2, 4f);  //�u���b�N��u���n�߂�ʒu�̌v�Z
        for (int wid = 0; wid < _Width; wid++)  //���̐������J��Ԃ�
        {
            for (int hei = 0; hei < _Height; hei++)  //�c�̐������J��Ԃ�
            {
                _Pos = new Vector2(_StartPos.x + wid * (_BlockSize.x + _spacing), _StartPos.y - hei * (_BlockSize.y + _spacing));
                Instantiate(_BlockPrehab, _Pos, Quaternion.identity);  //�u���b�N�𐶐�����
            }
        }
    }
}
