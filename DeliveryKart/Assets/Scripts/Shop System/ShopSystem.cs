using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public GameObject[] cars;
    int selectedCar = 0;

    void Start()
    {
        selectedCar = PlayerPrefs.GetInt("SelectedCar", 0);
        foreach (GameObject skin in cars)
        {
            skin.SetActive(false);
        }
        cars[selectedCar].SetActive(true);
    }

    public void ChangeCar(int index)
    {
        cars[selectedCar].SetActive(false);
        selectedCar = index;
        cars[selectedCar].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", index);
    }
}
