using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
public partial class StringVector
{
    public static implicit operator StringVector(List<string> strings)
    {
        var stringVector = new StringVector();
        foreach (var @string in strings)
        {
            stringVector.Add(@string);
        }
        return stringVector;
    }

    public static implicit operator StringVector(string[] strings)
    {
        var stringVector = new StringVector(strings.Length);
        foreach (var @string in strings)
        {
            stringVector.Add(@string);
        }
        return stringVector;
    }

    public static explicit operator List<string>(StringVector stringVector)
    {
        return stringVector.ToArray().ToList();
    }

    public static explicit operator string[](StringVector stringVector)
    {
        return stringVector.ToArray();
    }
}