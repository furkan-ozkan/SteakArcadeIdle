using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    public void PlayStepSound()
    {
        AudioManager.Instance.PlaySoundOneTime(AudioManager.Instance.audioData.walkSound,1f);
    }
}