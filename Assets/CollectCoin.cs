using UnityEngine;
using UnityEngine.Events;

public class CollectCoin : MonoBehaviour
{
    public UnityEvent OnCoinContact = new();
    public bool collected = false;
    private void OnTriggerEnter(Collider triggeredObject)
    {
        if (triggeredObject.CompareTag("Player") && !collected)
        {
            collected = true;
            OnCoinContact?.Invoke();
            Destroy(gameObject);
        }
    }
}
