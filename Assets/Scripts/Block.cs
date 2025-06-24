using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameManager _GameManager;  //BlockManagerを取得するための箱

    private void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _GameManager.AddBlock();  //BlockManagerのAddBlockメソッドを使用
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")  //もしタグが"Ball"のオブジェクトに当たったら
        {
            _GameManager.BlockDestroyed();  //BlockMnagerのBlockDestroyedメソッドを使用
            Destroy(gameObject);  //自分を消す
        }
    }
}