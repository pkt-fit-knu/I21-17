using System.Collections.Generic;
using static System.Math;
using System.Data;

namespace DivideAndConquer
{
    class Option
    {
        public string OptionName { get; set; }

        public int YesAmount { get; set; }
        public int NoAmount { get; set; }

        public double entropy { get; set; }

        public Option(string optionName)
        {
            OptionName = optionName;
        }

        public void setEntropy()
        {
            double tempYes = (double)YesAmount / (YesAmount + NoAmount);
            double tempNo = (double)NoAmount / (YesAmount + NoAmount);

            entropy = -(tempYes * Log(tempYes, 2) + tempNo * Log(tempNo, 2));
        }
    }

    class Attribute
    {
        public string AttributeName { get; set; }

        public double Gain { get; set; }

        public List<Option> Options;

        public Attribute(string attributeName, List<Option> options)
        {
            AttributeName = attributeName;

            Options = options;
        }

        public void SetGain()
        {
            int overallYes = 0, overallNo = 0, overallYesNo = 0;

            //считаем количество Да и Нет в опциях атрибута
            foreach (Option option in Options)
            {
                overallYes += option.YesAmount;
                overallNo += option.NoAmount;
            }

            //считаем ентропию атрибута
            double tempYes = (double)overallYes / (overallYes + overallNo);
            double tempNo = (double)overallNo / (overallYes + overallNo);

            double tempEntropy = -(tempYes * Log(tempYes, 2) + tempNo * Log(tempNo, 2));

            double tempResult = 0;

            //считаем усиление атрибута
            foreach (Option option in Options)
            {
                overallYesNo = option.YesAmount + option.NoAmount;
                tempResult += (double)overallYesNo / (overallYes + overallNo) * option.entropy;
            }

            Gain = tempEntropy - tempResult;
        }
    }

    class Relation
    {
        public Node ChildNode;
        public string ChildEdge { get; set; }

        public DataTable Data;

        public Relation(Node childNode, string childEdge, DataTable dataTable)
        {
            ChildNode = childNode;
            ChildEdge = childEdge;

            Data = dataTable;
        }
    }

    class Node
    {
        public string NodeData { get; set; }

        public List<Relation> Relations;
        public List<Attribute> Attributes;

        public Node(string nodeData, List<Relation> relations, List<Attribute> attributes)
        {
            NodeData = nodeData;

            Relations = relations;
            Attributes = attributes;
        }
    }
}
