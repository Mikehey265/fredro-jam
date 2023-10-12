using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FinalSlideUI : MonoBehaviour
{
    public static FinalSlideUI Instance { get; set; }
    
    [SerializeField] private Image currentSlideImage;
    [SerializeField] private Sprite slide;
    [SerializeField] private AudioClip audioClip;
    
    private AudioSource _audioSource;
    
    private void Awake()
    {
        Instance = this;
        
        _audioSource = GetComponent<AudioSource>();
        Hide();
    }

    private void OnEnable()
    {
        currentSlideImage.sprite = slide;
        _audioSource.clip = audioClip;
        _audioSource.Play();
        StartCoroutine(PlayVo());
    }

    public void LaunchFinalSlide()
    {
        Show();
        StartCoroutine(PlayVo());
    }
    
    IEnumerator PlayVo()
    {
        yield return new WaitForSeconds(_audioSource.clip.length);
        Show();
        GameManager.Instance.SetNewState(GameManager.State.GameOver);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
