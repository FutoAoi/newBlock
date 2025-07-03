using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] PaddleMove _PaddleMove;
    [SerializeField] TextMeshProUGUI[] _Leveltext;

    private void Start()
    {
        _PaddleMove = GameObject.Find("Paddle").GetComponent<PaddleMove>();
        _Leveltext[0].text = $"{_PaddleMove._SpeedLevel}";
        _Leveltext[1].text = $"{_PaddleMove._PaddleScaleLevel}";
        _Leveltext[2].text = $"{_PaddleMove._CreateSpanLevel}";
        _Leveltext[3].text = $"{_PaddleMove._ShieldLevel}";
        _Leveltext[4].text = $"{_PaddleMove._GhostLevel}";
    }
}
