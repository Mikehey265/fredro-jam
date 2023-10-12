using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuotesTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quotesText;
    [SerializeField] private string[] quotes;

    private void Start()
    {
        Hide();
        GameManager.OnBrickPickedUp += ShowQuote;
    }

    private void OnDestroy()
    {
        Hide();
        GameManager.OnBrickPickedUp -= ShowQuote;
    }

    private void ShowQuote()
    {
        Show();
        quotesText.text = quotes[Random.Range(0, quotes.Length)];
    }

    private void Show()
    {
        gameObject.SetActive(true);
        Invoke("Hide", 5f);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
