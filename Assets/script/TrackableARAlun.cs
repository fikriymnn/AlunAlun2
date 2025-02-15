using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackableARAlun : DefaultObserverEventHandler
{
    bool marker;
    private AudioSource audioSource;

    void Awake()
    {
        // Ambil komponen AudioSource dari GameObject ini
        audioSource = GetComponent<AudioSource>();

        // Pastikan audioSource tidak null
        if (audioSource == null)
        {
            Debug.LogError("AudioSource tidak ditemukan! Pastikan komponen AudioSource sudah ditambahkan ke GameObject.");
        }
    }

    protected override void OnTrackingFound()
    {
        marker = true;
        base.OnTrackingFound();
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    protected override void OnTrackingLost()
    {
        marker = false;
        base.OnTrackingLost();
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public bool GetMarker()
    {
        return marker;
    }
}
