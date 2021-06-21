using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private float _volumeTime;

    private const float _updateTime = 0.1f;
    private float _volumeRunningTime;

    private Coroutine _increaseVolumeSound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       _audioSourse.Play();
       _increaseVolumeSound = StartCoroutine(PlaySong(1));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      _increaseVolumeSound = StartCoroutine(PlaySong(0));
    }

    private IEnumerator PlaySong(int value)
    {
        var time = new WaitForSeconds(_updateTime);

        if (_increaseVolumeSound != null)
        {
            StopCoroutine(_increaseVolumeSound);
            _volumeRunningTime = 0;
        }

        while(_audioSourse.volume != value) 
        { 
            _volumeRunningTime += Time.deltaTime;
            _audioSourse.volume = Mathf.Lerp(_audioSourse.volume, value,_volumeRunningTime/_volumeTime);
            yield return time;
        }
    }
}
