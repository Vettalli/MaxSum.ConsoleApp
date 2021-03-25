using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MaxSum.Application
{
    public class MaxSumApplication : ISum
    {
        public string[] GetFile(string path)
        {
            string[] nums = { };

            nums = File.ReadAllLines(path);
              
            return nums;
        }

        public List<Line> GetSumFromStrings(string[] nums)
        {
            List<Line> datas = new List<Line>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                decimal tempSum = 0;
                var lineIsBroken = false;

                string[] lineNums = nums[i].Replace(" ","").Split(',');
                foreach(var n in lineNums)
                {
                    if (decimal.TryParse(n, out decimal outNum))
                    {
                        tempSum += outNum;
                    }
                    else
                    {
                        datas.Add(new Line { LineNumber = i + 1, Sum = null, Broken = true });
                        lineIsBroken = true;
                        break;
                    }
                }

                if (!lineIsBroken)
                {
                    datas.Add(new Line { LineNumber = i + 1, Sum = tempSum, Broken = false });
                }
            }

            return datas;
        }

        public int GetIndexOfMaxSum(List<Line> lines)
        {
            decimal? maxSum = decimal.MinValue;
            int maxIndex=0;
            bool allMinValue = lines.All(item => item.Sum == null);

            if (!allMinValue)
            {
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Sum != null && lines[i].Sum.Value > maxSum)
                    {
                        maxIndex = i+1;
                        maxSum = lines[i].Sum.Value;
                    }
                }
            }
            else
            {
                maxIndex = -1;
            }

            return maxIndex;
        }
    }
}
