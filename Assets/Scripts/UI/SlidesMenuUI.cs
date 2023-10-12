using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidesMenuUI : MonoBehaviour
{
    [SerializeField] private Image currentSlideImage;
    [SerializeField] private Sprite[] slides;
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource _audioSource;
    private float _currentAudioClipLength;

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

    private void OnEnable()
    {
        GameManager.OnGameFinished += PlayLastSlide;
    }

    private void OnDisable()
    {
        GameManager.OnGameFinished -= PlayLastSlide;
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

    private void PlayLastSlide()
    {
        gameObject.SetActive(true);
        StartCoroutine(PlayLastVo());
    }

    IEnumerator PlayLastVo()
    {
        yield return new WaitForSeconds(_audioSource.clip.length);
        currentSlideImage.sprite = slides[2];
        _audioSource.clip = audioClips[2];
        _audioSource.Play();
        gameObject.SetActive(false);
    }
}
