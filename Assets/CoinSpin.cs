using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.right,2 * speed * Time.deltaTime);
    }
}
