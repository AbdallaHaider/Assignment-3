using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Rotate(Vector3.right,2 * speed * Time.deltaTime);
    }
}
