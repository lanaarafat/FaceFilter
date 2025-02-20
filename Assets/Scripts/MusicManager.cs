using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public GameObject ARDefaultFace;
    public AudioSource backgroundMusic;
    public AudioClip[] filterMusic;

    private GameObject[] filters;
    private GameObject activeFilter;

    void Start()
    {
        int childCount = ARDefaultFace.transform.childCount;
        filters = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            filters[i] = ARDefaultFace.transform.GetChild(i).gameObject;
            filters[i].SetActive(false); // Hide all filters at start
        }
    }

    public void SetActiveFilter(int index)
    {
        // Deactivate previous filter
        if (activeFilter != null)
        {
            activeFilter.SetActive(false);
        }

        // Activate new filter
        activeFilter = filters[index];
        activeFilter.SetActive(true);

        // Change background music
        if (index < filterMusic.Length && filterMusic[index] != null)
        {
            backgroundMusic.clip = filterMusic[index];
            backgroundMusic.Play();
        }
    }
}