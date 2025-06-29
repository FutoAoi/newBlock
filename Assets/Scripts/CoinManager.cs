using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _CoinText;
    [SerializeField] PaddleMove _PaddleMove;

    private string _HaveCoin;

    private void Start()
    {
        _PaddleMove = GameObject.Find("Paddle").GetComponent<PaddleMove>();
    }
    private void Update()
    {
        if (_HaveCoin != _PaddleMove._HaveCoin.ToString("D4"))
        {
            _HaveCoin = _PaddleMove._HaveCoin.ToString("D4");
            _CoinText.text = $"X{_HaveCoin}";
        }
    }
}
