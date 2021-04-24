using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class SignalRay : MonoBehaviour
{       
    private AudioSource _signalization;
    private AudioSource _backgroundAudio;    
    
    void Start()
    {
        _signalization = GetComponent<AudioSource>();
        _backgroundAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit signalRay;
        Physics.Raycast(transform.position, transform.forward, out signalRay);
        Debug.DrawRay(transform.position, transform.forward * 2f, Color.red);
        if (signalRay.collider.gameObject.name == "theBoss")
        {
            if (_signalization.isPlaying == false) 
            {
                _signalization.volume = 0;
                _backgroundAudio.mute = true;
                _signalization.Play();
            } 
            else 
            {
                 _signalization.volume += Mathf.Lerp(0, 1, Time.deltaTime * 0.1f);
            }                                  
        }
        else 
        {                      
            _signalization.volume -= Mathf.Lerp(0, 1, Time.deltaTime * 0.1f);

            if (_signalization.volume != 0) 
            {
                Debug.Log(_signalization.volume);
            }
                        
            _backgroundAudio.mute = false;
        }        
    }    
}
