using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;

namespace generickyseznam;

public class Repository<T>: IEnumerable
{
    private List<T> items;
    
    //V T může být úplně cokoliv díky generice. 

    public int Count
    {
        get
        {
            //vrací nám počet prvků v repozitářie
            return items.Count;
        }
    }
    
    public void Create(T item){
        items.Add(item);
    }

    public T Read(int index)
    {
        
        //pokud je index menší než nula a pokud index je větší nebo rovno items.count, tak hoď chybovou hlášku
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        return items[index];
    }

    public void Update(int index, T item)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }
        items[index] = item;
    }

    public void Delete(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }
        items.RemoveAt(index);
    }

    public void Clear()
    {
        items.Clear();
    }

    public T[] AsArray()
    {

        return items.ToArray();
    }


    /*
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    */
    
    public IEnumerator<T> GetEnumerator()
    {
        return new mujinemurator<T>(items);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    
    public T[] Read(int startIndex, int count)
    {
        if (startIndex < 0 || startIndex >= items.Count)
        {
            throw new ArgumentOutOfRangeException("startIndex");
        }
        //šetření, aby uživatel nezadal nějaký interval přes
        if (count < 0 || startIndex + count > items.Count)
        {
            throw new ArgumentOutOfRangeException("count");
        }

        T[] result = new T[count];
        items.CopyTo(startIndex, result, 0, count);
        return result;
    }
}