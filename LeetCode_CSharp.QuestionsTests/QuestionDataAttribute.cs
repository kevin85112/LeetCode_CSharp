using System.Reflection;

namespace LeetCode_CSharp.QuestionsTests;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
internal sealed class QuestionDataAttribute(params object?[]? data) : Attribute, ITestDataSource
{
    private readonly DataRowAttribute _dataRowAttribute = new(data);

    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
    {
        if (GetCustomAttribute(methodInfo, typeof(QuestionAttribute)) is QuestionAttribute questionAttribute)
        {
            foreach (object item in Loader.Load(questionAttribute.QuestionType))
            {
                foreach (object?[] items in _dataRowAttribute.GetData(methodInfo))
                {
                    yield return [item, .. items];
                }
            }
        }
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
    {
        return data != null && data.Length > 0 && data[0] != null ? data[0]!.GetType().Name : methodInfo.Name;
    }
}
