using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescManager : MonoBehaviour
{
    public GameObject panelDescAlun;
    [Header("Deskripsi AR")]
    public TrackableAR[] tr;
    public TrackableARAlun trAlun;
    public string namaAlun;
    public string[] nama;
    [TextArea]
    public string deskripsiAlun;
    [TextArea]
    public string[] deskripsi;

    [Header("UI Deskripsi")]
    public TMP_Text txtNama;
    public TMP_Text txtDeskripsi;
    public TMP_Text txtNamaAlun;
    public TMP_Text txtDeskripsiAlun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trAlun.GetMarker())
        {
            panelDescAlun.gameObject.SetActive(true);
            txtNamaAlun.text = namaAlun;
            txtDeskripsiAlun.text = deskripsiAlun;
        }
        else
        {
            panelDescAlun.gameObject.SetActive(false);
        }

        for (int i = 0; i < tr.Length; i++)
        {
            if (tr[i].GetMarker())
            {
                txtNama.text = nama[i];
                txtDeskripsi.text = deskripsi[i];
            }
        }
    }
}
