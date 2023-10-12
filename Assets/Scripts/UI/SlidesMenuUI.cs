using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlidesMenuUI : MonoBehaviour
{
    [SerializeField] private Image currentSlideImage;
    [SerializeField] private Sprite[] slides;
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
    }

    private void Start()
    {
        currentSlideImage.sprite = slides[0];
        _audioSource.clip = audioClips[0];
        _audioSource.Play();
        StartCoroutine(PlayVo());
    }

    IEnumerator PlayVo()
    {
        yield return new WaitForSeconds(_audioSource.clip.length);
        currentSlideImage.sprite = slides[1];
        _audioSource.clip = audioClips[1];
        _audioSource.Play();
        _audioSource.loop = false;
        yield return new WaitForSeconds(_audioSource.clip.length);
        gameObject.SetActive(false);
        GameManager.Instance.SetNewState(GameManager.State.GamePlaying);
    }
}
