using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Pig :  Weakanimal
{
    protected override void Re()
    {
        base.Re();
        RandomAction();

    }

    private void RandomAction()
    {
        RandomSound();

        isAction = true;

        int _random = Random.Range(0, 4);

        if (_random == 0)
        {
            Wait();
        }
        else if (_random == 1)
        {
            Eat();
        }
        else if (_random == 2)
        {
            Peek();
        }
        else if (_random == 3)
        {
            TryWalk();
        }
    }

    private void Wait()
    {
        currentTime = waitTime;
    }
    private void Eat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
    }
    private void Peek()
    {
        currentTime = waitTime;
        anim.SetTrigger("Peek");
    }

}
