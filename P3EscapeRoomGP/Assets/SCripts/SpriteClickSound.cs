using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundEntry
    {
        public string soundName;
        public AudioClip audioClip;
    }

    public SoundEntry[] sounds;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
        audioSource.volume = 1f;
    }

    public void PlaySound(string soundName)
    {
        Debug.Log("Looking for sound: " + soundName);

        foreach (SoundEntry sound in sounds)
        {
            if (sound.soundName.Trim().ToLower() == soundName.Trim().ToLower())
            {
                if (sound.audioClip != null)
                {
                    audioSource.PlayOneShot(sound.audioClip);
                    Debug.Log("Playing sound: " + sound.soundName);
                }
                else
                {
                    Debug.LogWarning("Audio clip is missing!");
                }

                return;
            }
        }

        Debug.LogWarning("Could not find sound: " + soundName);
    }
}