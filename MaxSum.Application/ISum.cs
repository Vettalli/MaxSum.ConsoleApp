using System.Collections.Generic;

namespace MaxSum.Application
{
   public interface ISum
   {
        string[] GetFile(string path);

        List<Line> GetSumFromStrings(string[] nums);

        int GetIndexOfMaxSum(List<Line> lines);
    }
}
