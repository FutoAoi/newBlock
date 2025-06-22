using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    private int _BlockCount = 0;  //�u���b�N�𐔂���ϐ�

    public void AddBlock()  //�u���b�N�̐��𑝂₷���\�b�h
    {
        _BlockCount++;  //�u���b�N�̐��𑝂₷
    }

    public void BlockDestroyed()  //�u���b�N�̐������炷���\�b�h
    {
        _BlockCount--;  //�u���b�N�̐�������炷

        if (_BlockCount <= 0)  //�����u���b�N�̐���0��菭�Ȃ��Ȃ�
        {
            LoadNextStage();
        }
    }
    void LoadNextStage()  //���̃V�[�������[�h���郁�\�b�h
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;  //���̃V�[���̃C���f�b�N�X�ԍ����擾����
        SceneManager.LoadScene(currentSceneIndex + 1);  //���̃C���f�N�X�ԍ��̃V�[���̎��̃V�[����ǂݍ���
    }
}
