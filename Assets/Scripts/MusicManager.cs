using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [System.Serializable]
    public class SceneMusic
    {
        public string sceneName;
        public AudioClip music;
    }

    public SceneMusic[] sceneMusic;

    public static MusicManager Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (var sm in sceneMusic)
        {
            if (sm.sceneName == scene.name)
            {
                PlayBackgroundMusic(sm.music);
                break;
            }
        }
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (clip == null || audioSource.clip == clip) return;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PauseBackgroundMusic()
    {
        audioSource.Pause();
  }




}
