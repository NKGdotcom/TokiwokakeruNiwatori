using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����炷����
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Header("BGM�̃I�[�f�B�I")]
    [SerializeField] private AudioSource bgmAudioSource;
    [Header("SE�̃I�[�f�B�I")]
    [SerializeField] private AudioSource seAudioSource;
    [Header("�T�E���h�f�[�^")]
    [SerializeField] private SoundList soundList;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("SoundManager instance = null. Setting up.");
            Instance = this;
            PlayBGM(BGMSource.BGM);
        }
        else
        {
            Debug.LogError("SoundVolume ScriptableObject��SoundManager�Ɋ��蓖�Ă��Ă��܂���B");
        }
    }
    /// <summary>
    /// BGM�𗬂�
    /// </summary>
    /// <param name="_bgmSource"></param>
    public void PlayBGM(BGMSource _bgmSource)
    {
        SoundList.BGMSoundData bgmData = soundList.GetBGMData(_bgmSource);
        if (bgmData != null && bgmData.BGMAudioClip != null)
        {
            bgmAudioSource.clip = bgmData.BGMAudioClip;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
            Debug.Log($"Playing BGM: {_bgmSource} with volume: {bgmAudioSource.volume}");
        }
        else
        {
            Debug.LogWarning($"BGM {_bgmSource} ��������܂���");
        }
    }
    /// <summary>
    /// SE�𗬂�
    /// </summary>
    /// <param name="_seSource"></param>
    public void PlaySE(SESource _seSource)
    {
        SoundList.SESoundData seData = soundList.GetSEData(_seSource);
        if (seData != null && seData.SEAudioClip != null)
        {
            seAudioSource.PlayOneShot(seData.SEAudioClip);
        }
        else
        {
            Debug.LogWarning($"SE {_seSource} ��������܂���");
        }
    }
}