using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
  public GameObject Camera1;
  public GameObject Camera2;
  public int Manager;

  public void ChangeCamera() {
    GetComponent<Animator>().SetTrigger("Change");
  }

  public void ManageCamera() {
    if (Manager == 0) {
        Cam1();
        Manager = 1;
    } else {
        Cam2();
        Manager = 0;
    }
  }
  

  void Cam1() {
    Camera1.SetActive(true);
    Camera2.SetActive(false);

  }

  void Cam2() {
    Camera1.SetActive(false);
    Camera2.SetActive(true);
  }
}
