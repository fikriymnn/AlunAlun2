using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button soal1btn, soal2btn, soal3btn, hasilBtn;
    public GameObject panelSoal1, panelSoal2, panelSoal3;
    public GameObject submitBtnSoal2;
    public bool isDisabled1, isDisabled2, isDisabled3;
    public TMP_InputField inputField;
    public TMP_Text question1;
    public GameObject panelJawabanBenar1, panelJawabanSalah1;

    string answer;

    public GameObject[] item;
    public GameObject[] itemDrop;
    public int jarak;
    Vector2[] itemPos = new Vector2[3];

    public List<Image> selectedImages = new List<Image>();
    public Button submitButton;
    public Transform resultPanel;
    public List<Image> correctAnswers;
    public List<Image> duplicatedImages = new List<Image>();
    public Transform duplicateParent;
    private Color selectedColor = new Color(0.5f, 1f, 0.5f, 1f);
    private Color wrongColor = Color.red;
    private Color defaultColor = Color.white;

    public TMP_Text hasilPembelajaran1;

    void Start()
    {
        question1.text = "Pakaian apa yang digunakan anak-anak saat pergi ke alun-alun Bandung?";
        soal1btn.interactable = true;

        for (int i = 0; i < itemPos.Length; i++)
        {
            itemPos[i] = item[i].transform.localPosition;
        }

        submitButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isDisabled1 == true)
        {
            soal1btn.interactable = false;
        }
        else
        {
            soal1btn.interactable = true;
        }
        if (isDisabled2 == true)
        {
            soal2btn.interactable = false;
        }
        else
        {
            soal2btn.interactable = true;
        }

        if (isDisabled3 == true)
        {
            soal3btn.interactable = false;
        }
        else
        {
            soal3btn.interactable = true;
        }

        if (item[0].transform.localPosition == itemDrop[0].transform.localPosition && item[1].transform.localPosition == itemDrop[1].transform.localPosition && item[2].transform.localPosition == itemDrop[2].transform.localPosition)
        {
            submitBtnSoal2.SetActive(true);
        }
        else
        {
            submitBtnSoal2.SetActive(false);
        }

        hasilPembelajaran1.text = answer;

        if (isDisabled1 == true && isDisabled2 == true && isDisabled3 == true)
        {
            hasilBtn.gameObject.SetActive(true);
        }
        else
        {
            hasilBtn.gameObject.SetActive(false);
        }
    }

    public void ShowSoal1()
    {
        panelSoal1.SetActive(true);
    }

    public void ShowSoal2()
    {
        panelSoal2.SetActive(true);
    }

    public void ShowSoal3()
    {
        panelSoal3.SetActive(true);
    }

    public void ShowHasilPembelajaran()
    {
        resultPanel.gameObject.SetActive(true);
    }

    // public void ShowSoal2()
    // {
    //     soal1btn.gameObject.SetActive(false);
    //     soal2btn.gameObject.SetActive(true);
    //     soal3btn.gameObject.SetActive(false);
    // }

    // public void ShowSoal3()
    // {
    //     soal1btn.gameObject.SetActive(false);
    //     soal2btn.gameObject.SetActive(false);
    //     soal3btn.gameObject.SetActive(true);
    // }

    public void hideSoal1()
    {
        panelSoal1.SetActive(false);
        panelSoal2.SetActive(false);
        panelSoal3.SetActive(false);
        resultPanel.gameObject.SetActive(false);
    }


    public void SubmitAnswer1()
    {
        answer = inputField.text.ToLower();
        bool benar = "pakaian olahraga".Contains(answer);
        bool benar2 = "pakaian olah raga".Contains(answer);
        bool benar3 = "baju olahraga".Contains(answer);
        bool benar4 = "olahraga".Contains(answer);
        if (benar || benar2 || benar3 || benar4)
        {
            Debug.Log("Benar");
            isDisabled1 = true;
            panelJawabanBenar1.gameObject.SetActive(true);
            panelJawabanSalah1.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Salah");
            isDisabled1 = false;
            panelJawabanSalah1.gameObject.SetActive(true);
            panelJawabanBenar1.gameObject.SetActive(false);
        }
    }

    public void SubmitAnswer3()
    {
        panelSoal3.SetActive(false);
        isDisabled3 = true;
    }

    public void CobaLagi1()
    {
        panelJawabanSalah1.SetActive(false);
        panelJawabanBenar1.SetActive(false);
        inputField.text = null;
    }

    public void CloseJawabanBenar1()
    {
        panelJawabanSalah1.SetActive(false);
        panelJawabanBenar1.SetActive(false);
        panelSoal1.SetActive(false);
    }

    public void ItemDrag(int number)
    {
        item[number].transform.position = Input.mousePosition;
    }

    public void ItemEndDrag(int number)
    {
        float distance = Vector3.Distance(itemDrop[number].transform.localPosition, item[number].transform.localPosition);

        if (distance < jarak)
        {
            item[number].transform.localPosition = itemDrop[number].transform.localPosition;
        }
        else
        {
            item[number].transform.localPosition = itemPos[number];
        }
    }

    public void SelectImage(Image img)
    {
        if (selectedImages.Contains(img))
        {
            DeselectImage(img);
        }
        else if (selectedImages.Count < 3)
        {
            selectedImages.Add(img);
            img.color = selectedColor; // Ubah warna untuk menandai sudah dipilih
        }

        // Hanya aktifkan tombol submit jika jumlah pilihan pas 3
        submitButton.gameObject.SetActive(selectedImages.Count == 3);
    }

    void DeselectImage(Image img)
    {
        selectedImages.Remove(img);
        img.color = defaultColor; // Kembalikan ke warna semula

        // Hanya aktifkan tombol submit jika masih ada 3 pilihan
        submitButton.gameObject.SetActive(selectedImages.Count == 3);
    }


    public void OnSubmit()
    {
        Debug.Log("Submit Clicked! Selected Images: " + selectedImages.Count);

        // Hapus gambar duplikasi sebelumnya
        foreach (var img in duplicatedImages)
        {
            Destroy(img.gameObject);
        }
        duplicatedImages.Clear();

        // Duplikasi gambar yang dipilih
        foreach (Image img in selectedImages)
        {
            Image newImg = Instantiate(img, duplicateParent); // Duplikasi gambar
            newImg.rectTransform.localPosition = img.rectTransform.localPosition; // Set posisi sesuai gambar asli
            newImg.rectTransform.localScale = img.rectTransform.localScale; // Pastikan ukuran tetap sama
            duplicatedImages.Add(newImg); // Simpan referensi duplikasi

            Button buttonComponent = newImg.GetComponent<Button>();
            if (buttonComponent != null)
            {
                Destroy(buttonComponent); // Remove the Button component
            }

            // Cek apakah gambar termasuk jawaban yang benar
            if (correctAnswers.Contains(img))
            {
                newImg.color = Color.green; // Jawaban benar
            }
            else
            {
                newImg.color = Color.red; // Jawaban salah
            }
        }

        // Reset pilihan sebelumnya
        foreach (Image img in selectedImages)
        {
            img.color = defaultColor; // Reset warna
        }
        selectedImages.Clear();
        submitButton.gameObject.SetActive(false);
        isDisabled2 = true;
        hideSoal1();
    }
}