using UnityEngine;
using UnityEngine.UI;

public class FaceFilterManager : MonoBehaviour
{
    public GameObject ARDefaultFace;
    public Button[] filterButtons;
    public Button[] colorButtons;
    public Color[] colors;

    private GameObject[] filters; // Filters inside ARDefaultFace
    private GameObject activeFilter; // Currently active filter

    void Start()
    {
        if (ARDefaultFace == null)
        {
            Debug.LogError("ARDefaultFace is not assigned!");
            return;
        }

        // Gets all filter objects inside ARDefaultFace
        int childCount = ARDefaultFace.transform.childCount;
        filters = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            filters[i] = ARDefaultFace.transform.GetChild(i).gameObject;
            filters[i].SetActive(false); // Disable all filters at start
        }

        for (int i = 0; i < filterButtons.Length; i++)
        {
            int index = i;
            filterButtons[i].onClick.AddListener(() => SetActiveFilter(index));
        }

        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            colorButtons[i].onClick.AddListener(() => ChangeFilterColor(index));
        }
    }

    public void SetActiveFilter(int index)
    {
        // Deactivate previous filter
        if (activeFilter != null)
        {
            activeFilter.SetActive(false);
        }

        // Activate the new filter
        activeFilter = filters[index];
        activeFilter.SetActive(true);
    }

    void ChangeFilterColor(int colorIndex)
    {
        if (activeFilter != null && colorIndex >= 0 && colorIndex < colors.Length)
        {
            Renderer renderer = activeFilter.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colors[colorIndex];
            }
        }
    }
}
