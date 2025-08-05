using UnityEngine;

public class TestingCat : MonoBehaviour
{
    private void Start()
    {
        Cat myHouseCat = new Cat();
        Cat myLion = new Cat();

        myHouseCat.MakeSound();
        myLion.MakeSound();
    }
}
