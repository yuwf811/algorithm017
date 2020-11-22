public class MyComparer2 : IComparer<int[]>
{
    public int Compare(int[] arr1, int[]arr2)
    {
        return arr1[0] != arr2[0] ? arr1[0] - arr2[0] : arr1[1] - arr2[1];
    }
}