using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    private int _BlockCount = 0;  //ブロックを数える変数

    public void AddBlock()  //ブロックの数を増やすメソッド
    {
        _BlockCount++;  //ブロックの数を増やす
    }

    public void BlockDestroyed()  //ブロックの数を減らすメソッド
    {
        _BlockCount--;  //ブロックの数を一つ減らす

        if (_BlockCount <= 0)  //もしブロックの数が0より少ないなら
        {
            LoadNextStage();
        }
    }
    void LoadNextStage()  //次のシーンをロードするメソッド
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;  //今のシーンのインデックス番号を取得する
        SceneManager.LoadScene(currentSceneIndex + 1);  //今のインデクス番号のシーンの次のシーンを読み込む
    }
}
