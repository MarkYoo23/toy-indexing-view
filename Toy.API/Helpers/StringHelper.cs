namespace Toy.API.Helpers;

public static class StringHelper
{
    public static string[] StringToArrayConverter(string input)
    {
        return input.Split(',').ToArray();
    }
}