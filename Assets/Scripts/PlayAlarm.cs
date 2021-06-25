using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private float _volumeTime;

    private const float _updateTime = 0.1f;
    private float _volumeRunningTime = 0;

    private Coroutine _increaseVolumeSound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSourse.Play();
        RunCoroutine(1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RunCoroutine(0);
    }

    private void RunCoroutine(int coriutineState)
    {
        if (_increaseVolumeSound != null)
        {
            StopCoroutine(_increaseVolumeSound);
            _volumeRunningTime = 0;
        }
        _increaseVolumeSound = StartCoroutine(PlaySong(coriutineState));
    }

    private IEnumerator PlaySong(int value)
    {
        var time = new WaitForSeconds(_updateTime);

        while (_audioSourse.volume != value) 
        { 
            _volumeRunningTime += Time.deltaTime;
            _audioSourse.volume =Mathf.MoveTowards(_audioSourse.volume, value,_volumeRunningTime/_volumeTime);
            yield return time;
        }
    }
}
