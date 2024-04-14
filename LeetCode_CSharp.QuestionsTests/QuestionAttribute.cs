namespace LeetCode_CSharp.QuestionsTests;

[AttributeUsage(AttributeTargets.Method)]
internal sealed class QuestionAttribute(Type questionType) : Attribute
{
    public Type QuestionType = questionType;
}
