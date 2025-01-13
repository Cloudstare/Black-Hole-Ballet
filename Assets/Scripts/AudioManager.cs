using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip[] tracks; // Array for storing 36 music tracks

    private int currentTrackIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartMusicPlaylist();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void StartMusicPlaylist()
    {
        if (tracks.Length == 0)
        {
            Debug.LogWarning("No music tracks assigned to AudioManager.");
            return;
        }

        // Start with a random track
        currentTrackIndex = Random.Range(0, tracks.Length);
        PlayCurrentTrack();
    }

    private void PlayCurrentTrack()
    {
        musicSource.clip = tracks[currentTrackIndex];
        musicSource.Play();

        // Schedule the next track after the current one finishes
        Invoke(nameof(PlayNextTrack), musicSource.clip.length);
    }

    private void PlayNextTrack()
    {
        // Move to the next track, loop back if at the end
        currentTrackIndex = (currentTrackIndex + 1) % tracks.Length;
        PlayCurrentTrack();
    }

    public void StopMusic()
    {
        musicSource.Stop();
        CancelInvoke(nameof(PlayNextTrack));
    }
}
