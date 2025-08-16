using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SoundManager;

public class TitleButtonData : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AudioSource _seAudioSource;

    [SerializeField] private GameObject _titleUI;
    [SerializeField] private GameObject _startButtonUI;
    [SerializeField] private GameObject _howToPlayButtonUI;
    [SerializeField] private GameObject _howToPlayUI;
    [SerializeField] private GameObject _stageSelectUI;
    [SerializeField] private GameObject _gameSceneUI;
    [SerializeField] private GameObject _methodOfOperation;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _howToPlayButton;

    [SerializeField] private Button _goToTutorial;
    [SerializeField] private Button _goToStage1;
    [SerializeField] private Button _goToStage2;

    [SerializeField] private Button _backToTitle;
    [SerializeField] private Button _goToGameSceneUI;
    [SerializeField] private Button _goToMethodOfOperation;
    [SerializeField] private Button _backToTitleCircle;

    // Start is called before the first frame update
    void Start()
    {
        _titleUI.SetActive(true); 
        _startButtonUI.SetActive(true);
        _howToPlayButtonUI.SetActive(true);
        _howToPlayUI.SetActive(false);
        _stageSelectUI.SetActive(false);
        _gameSceneUI.SetActive(false);
        _methodOfOperation.SetActive(true);

        _startButton.onClick.AddListener(()=>GoToStageSelect());
        _howToPlayButton.onClick.AddListener(()=>GoToHowToPlayUI());

        _goToTutorial.onClick.AddListener(() => SceneManager.LoadScene("Tutorial"));
        _goToStage1.onClick.AddListener(() => SceneManager.LoadScene("Stage1"));
        _goToStage2.onClick.AddListener(() => SceneManager.LoadScene("Stage2"));

        _backToTitle.onClick.AddListener(() =>BackToTitle());
        _goToGameSceneUI.onClick.AddListener(() => GoToGameSceneUI());
        _goToMethodOfOperation.onClick.AddListener(() => GoToMethodOfOperationUI());
        _backToTitleCircle.onClick.AddListener(() => BackToTitle());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GoToStageSelect()
    {
        _startButtonUI.SetActive(false);
        _howToPlayButtonUI.SetActive(false);
        _stageSelectUI.SetActive(true);
    }
    private void BackToTitle()
    {
        _titleUI.SetActive(true);
        _startButtonUI.SetActive(true);
        _howToPlayButtonUI.SetActive(true);
        _stageSelectUI.SetActive(false);
        _howToPlayUI.SetActive(false);
        _gameSceneUI.SetActive(false);
        _gameSceneUI.SetActive(false);
        _methodOfOperation.SetActive(true);
    }
    private void GoToHowToPlayUI()
    {
        _titleUI.SetActive(false);
        _startButtonUI.SetActive(false);
        _howToPlayButtonUI.SetActive(false);
        _howToPlayUI.SetActive(true);
        _gameSceneUI.SetActive(false);
    }
    private void GoToGameSceneUI()
    {
        _gameSceneUI.SetActive(true);
        _methodOfOperation.SetActive(false);
    }
    private void GoToMethodOfOperationUI()
    {
        _methodOfOperation.SetActive(true);
        _gameSceneUI.SetActive(false);
    }
   
}
