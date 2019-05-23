using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audioFade : MonoBehaviour
{
    [SerializeField]
    private int m_FadeInTime = 10;
    private AudioSource m_AudioSource;


    /* When this object is created, grabs the existing audio component from the object */
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    /* Updates the volume every frame until it reaches 1 */
    private void Update()
    {
        if (m_AudioSource.volume < 1)
        {
            m_AudioSource.volume = m_AudioSource.volume + (Time.deltaTime / (m_FadeInTime + 1));
        }
        else
        {
            Destroy(this);
        }
    }
}
