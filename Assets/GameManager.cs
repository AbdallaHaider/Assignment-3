using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score;
    [SerializeField] private TextMeshProUGUI scoreText;
    private CollectCoin[] coins;

    void Start()
    {
        coins = FindObjectsByType<CollectCoin>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (CollectCoin coin in coins)
        {
            coin.OnCoinContact.AddListener(AddScore);
        }
    }

    private void AddScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
