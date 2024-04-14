namespace LeetCode_CSharp.QuestionsTests;

public static class Loader
{
    private static HashSet<Type>? _types = null;
    private static HashSet<Type> Types
    {
        get
        {
            if (_types == null)
            {
                _types = [];
                foreach (Type type in Answers.AnswersAssembly.Assembly.GetTypes())
                {
                    _ = _types.Add(type);
                }
            }
            return _types;
        }
    }

    private static Dictionary<Type, HashSet<Type>>? _intefaces = null;
    private static Dictionary<Type, HashSet<Type>> Interfaces
    {
        get
        {
            if (_intefaces == null)
            {
                _intefaces = [];

                foreach (Type type in Types)
                {
                    foreach (Type item in type.GetInterfaces())
                    {
                        if (_intefaces.TryGetValue(item, out HashSet<Type>? value))
                        {
                            _ = value.Add(type);
                        }
                        else
                        {
                            _intefaces.Add(item, [type]);
                        }
                    }
                }
            }
            return _intefaces;
        }
    }

    public static object[] Load(Type targetType)
    {
        List<object> items = [];
        if (Interfaces.TryGetValue(targetType, out HashSet<Type>? value) && value != null)
        {
            foreach (Type type in value)
            {
                try
                {
                    if (Activator.CreateInstance(type) is object item)
                    {
                        items.Add(item);
                    }
                }
                catch
                {
                }
            }
        }
        return [.. items];
    }

    public static T[] Load<T>()
    {
        return Load(typeof(T)).Cast<T>().ToArray();
    }
}
