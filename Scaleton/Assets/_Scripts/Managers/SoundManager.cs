using UnityEngine;

namespace Scaleton
{
    public class SoundManager : MonoBehaviour
    {
        private float _volume = 1f;

        private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
        {
            AudioSource.PlayClipAtPoint(audioClip, position, _volume * volumeMultiplier);
        }

    }

}

