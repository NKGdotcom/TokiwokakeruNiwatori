using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����i�[���镨
/// </summary>
[CreateAssetMenu(fileName = "SoundData", menuName = "Scriptable Objects/SoundData")]
public class SoundList : ScriptableObject
{
    [System.Serializable]
    public class BGMSoundData
    {
        [Header("���̎��")]
        public BGMSource BGMSource;
        [Header("���̃N���b�v")]
        public AudioClip BGMAudioClip;

        public BGMSoundData(BGMSource BGMSource, AudioClip BGMAudioClip)
        {
            this.BGMSource = BGMSource;
            this.BGMAudioClip = BGMAudioClip;
        }
    }
    [System.Serializable]
    public class SESoundData
    {
        [Header("���̎��")]
        public SESource SESource;
        [Header("���̃N���b�v")]
        public AudioClip SEAudioClip;
        public SESoundData(SESource SESource, AudioClip SEAudioClip)
        {
            this.SESource = SESource;
            this.SEAudioClip = SEAudioClip;
        }
    }
    public List<BGMSoundData> bgmSoundDataList = new List<BGMSoundData>();
    public List<SESoundData> seSoundDataList = new List<SESoundData>();

    public BGMSoundData GetBGMData(BGMSource BGMSource)
    {
        foreach (BGMSoundData bgm in bgmSoundDataList)
        {
            if (bgm.BGMSource == BGMSource)
            {
                return new BGMSoundData(bgm.BGMSource, bgm.BGMAudioClip);
            }
        }
        return null;
    }
    public SESoundData GetSEData(SESource SESource)
    {
        foreach (SESoundData se in seSoundDataList)
        {
            if (se.SESource == SESource)
            {
                return new SESoundData(se.SESource, se.SEAudioClip);
            }
        }
        return null;
    }
}
