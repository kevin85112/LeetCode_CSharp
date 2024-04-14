using LeetCode_CSharp.QuestionsTests;

namespace LeetCode_CSharp.Questions.Tests;

[TestClass()]
public class Tests
{
    [TestMethod()]
    [Question(typeof(IQuestions_4_Median_of_Two_Sorted_Arrays))]
    [QuestionData(null, null, 20.0)]
    public void Questions_4(IQuestions_4_Median_of_Two_Sorted_Arrays item, int[] nums1, int[] nums2, double answer)
    {
        Assert.AreEqual(answer, item.FindMedianSortedArrays(nums1, nums2));
    }
}