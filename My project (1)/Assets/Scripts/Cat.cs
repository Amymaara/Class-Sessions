using UnityEngine;

public class Cat : MonoBehaviour
{
   public virtual void MakeSound()
    {
        Debug.Log("Made a sound");
    }
}

public class HouseCat : Cat
{
    public override void MakeSound()
    {
        Debug.Log("Meow");
    }
}

public class Lion : Cat
{
    public override void MakeSound()
    {
        Debug.Log("Roar");
    }
}