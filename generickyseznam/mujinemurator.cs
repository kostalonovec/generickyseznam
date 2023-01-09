using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;

namespace generickyseznam;

public class mujinemurator<T>: IEnumerator<T>
{
   
    private List<T> items;

    private int currentIndex;

    public mujinemurator(List<T> items)
    {
        this.items = items;
        currentIndex = -1;
    }

    public T Current //vrací součáasný prvek
    {
        get
        {
            return items[currentIndex];
        }
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public bool MoveNext() //posune se na další prvek
    {
        currentIndex++;
        return currentIndex < items.Count;
    }

    public void Reset() //vrací se na počátek
    {
        currentIndex = -1;
    }

    public void Dispose()
    {
        // Zde můžeme uklidit jakékoliv použité zdroje
    }
}