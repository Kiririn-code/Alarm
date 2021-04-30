using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourse;

    private Coroutine _coroutine;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       _audioSourse.Play();
       _coroutine = StartCoroutine(PlaySong(1));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      _coroutine = StartCoroutine(PlaySong(0));
    }

    private IEnumerator PlaySong(int value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        var time = new WaitForSeconds(0.05f);
        while(_audioSourse.volume != value) 
        { 
            _audioSourse.volume = Mathf.MoveTowards(_audioSourse.volume, value, 0.005f);
            yield return time;
        }
    }
}
