using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] BlockManager _BlockManager;  //BlockManagerを取得するための箱

    private void Start()
    {
        _BlockManager = GameObject.Find("BlockManager").GetComponent<BlockManager>();
        _BlockManager.AddBlock();  //BlockManagerのAddBlockメソッドを使用
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")  //もしタグが"Ball"のオブジェクトに当たったら
        {
            _BlockManager.BlockDestroyed();  //BlockMnagerのBlockDestroyedメソッドを使用
            Destroy(gameObject);  //自分を消す
        }
    }
}