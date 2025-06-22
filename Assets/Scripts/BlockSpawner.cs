using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject _BlockPrehab;  //ブロックのプレハブ

    public int _Height = 5;  //縦
    public int _Width = 8;   //横
    public float _spacing = 0.1f;  //ブロックの間隔

    Vector2 _BlockSize;  //ブロックのサイズ
    Vector2 _StartPos;  //ブロックを置き始める位置
    Vector2 _Pos;  //ブロックを置く位置
    void Start()
    {
        SpawnBlock();  //ゲーム開始時にブロックを置く
    }
    void SpawnBlock()  //ブロックのスポーン処理
    {
        _BlockSize = _BlockPrehab.GetComponent<SpriteRenderer>().bounds.size;  //ブロックのサイズを取得(プレハブの)
        _StartPos = new Vector2(-((_Width - 1) * (_BlockSize.x + _spacing)) / 2, 4f);  //ブロックを置き始める位置の計算
        for (int wid = 0; wid < _Width; wid++)  //横の数だけ繰り返す
        {
            for (int hei = 0; hei < _Height; hei++)  //縦の数だけ繰り返す
            {
                _Pos = new Vector2(_StartPos.x + wid * (_BlockSize.x + _spacing), _StartPos.y - hei * (_BlockSize.y + _spacing));
                Instantiate(_BlockPrehab, _Pos, Quaternion.identity);  //ブロックを生成する
            }
        }
    }
}
