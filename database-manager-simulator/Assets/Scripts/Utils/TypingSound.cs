using UnityEngine;
using TMPro;

public class TypingSound : MonoBehaviour
{
    private AudioSource audioSource;
    private TMP_InputField inputField;

    // Array to hold two typing sound clips
    public AudioClip[] typingSounds;
    private int currentClipIndex = 0;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        audioSource = gameObject.GetComponent<AudioSource>();

        // Add listener to detect when the input changes
        inputField.onValueChanged.AddListener(PlayTypingSound);
    }

    void PlayTypingSound(string text)
    {
        // Play the next sound in the sequence
        if (typingSounds.Length > 0)
        {
            audioSource.clip = typingSounds[currentClipIndex];
            audioSource.Play();

            // Increment the clip index and reset if it exceeds the array length
            currentClipIndex = (currentClipIndex + 1) % typingSounds.Length;
        }
    }
}
