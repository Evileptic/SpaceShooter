using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource EngineAudio;

    void Update()
    {
        EngineAudio.volume = Mathf.Abs(InputManager.Input.magnitude);
    }
}
