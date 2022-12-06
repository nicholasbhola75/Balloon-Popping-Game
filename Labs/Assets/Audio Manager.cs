using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
     [SerializeField] private AudioSource AS;
     [SerializeField] private AudioClip Pop;
     [SerializeField] private AudioClip Ow;
    // Start is called before the first frame update
    private void Awake()
    {
        
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }
      public void PlayCherriesPickup()
  {    
    AS.PlayOneShot(Pop);
  }
}
