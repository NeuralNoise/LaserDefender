using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    public AudioClip[] clips;

    private AudioSource music;

    void Awake()
    {
        music = GetComponent<AudioSource>();
        if (instance != null && instance != this)
        {
            Debug.Log("Destroy :" + this.GetHashCode().ToString());
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            OnLevelWasLoaded(0);
        }
    }
    
    void OnLevelWasLoaded(int level)
    {
        if(music && music.isActiveAndEnabled)
        {
            music.Stop();
            try
            {
                music.clip = clips[level];
                music.Play();
            }
            catch
            {
                Debug.Log("No music to load.");
            }
        }
    }
}
