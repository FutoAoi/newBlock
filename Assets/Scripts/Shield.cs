using UnityEngine;

public class Shield : MonoBehaviour
{
    private int _Counter = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _Counter++;
            if (_Counter == 5)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
