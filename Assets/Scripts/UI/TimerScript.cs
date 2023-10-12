using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countDownText;
    
    public float currentTime = 10f;
    public float startingTime = 120f;
    
    void Start()
    {
        ResetTimer();
    }
    
    void Update()
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");

            if (currentTime < 0f)
            {
                Wall.Instance.RemoveHealth();
                GameManager.OnWallHpModified?.Invoke();
                ResetTimer();
            }   
        }
    }

    private void ResetTimer()
    {
        currentTime = startingTime;
    }
}
