using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject studio;

    public void GoToStudio()
    {
        MainMenu.SetActive(false);
        studio.SetActive(true);
    }
}
