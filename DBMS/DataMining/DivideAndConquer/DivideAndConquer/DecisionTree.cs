using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Data;

namespace DivideAndConquer
{
    class DecisionTree
    {
        public List<Node> Nodes = new List<Node>();

        public void BuildDecisionTree(DataTable table, List<Attribute> attributes, Relation relation)
        {
            //для каждой колонки, кроме последней
            for (int c = 0; c < table.Columns.Count - 1; ++c)
            {
                //для каждого атрибута, в котором название совпадает с названием колонки
                foreach (Attribute attribute in attributes.Where(attr => table.Columns[c].Caption == attr.AttributeName))
                {
                    //для каждого рядка таблицы
                    for (int r = 0; r < table.Rows.Count; ++r)
                    {
                        //для каждой опции, в которой название совпадает с содержимим клетки в таблице
                        foreach (Option option in attribute.Options.Where(opt => table.Rows[r][c].ToString() == opt.OptionName))
                        {
                            //если значение столбца Play == Yes для данного рядка
                            if (table.Rows[r].Field<string>(Constants.Play) == Constants.Yes)
                            {
                                //инкрементируем количество Yes
                                ++option.YesAmount;
                            }
                            else
                            {
                                //инкрементируем количество No
                                ++option.NoAmount;
                            }
                        }
                    }

                    //для каждой опции в атрибуте
                    foreach (Option option in attribute.Options)
                    {
                        //считаем ентропию
                        option.setEntropy();

                        //если ентропия == NaN, то она = 0
                        if (double.IsNaN(option.entropy))
                        {
                            option.entropy = 0;
                        }
                    }

                    //устанавливаем усиление
                    attribute.SetGain();
                }
            }

            //выбираем атрибут с найбольшим значением усиления
            Attribute choosenAttribute = attributes.OrderByDescending(attr => attr.Gain).First();

            List<Relation> relations = new List<Relation>();

            DataTable dataTable;

            //для каждой опции в выбраном атрибуте
            foreach (Option option in choosenAttribute.Options)
            {
                if (option.entropy != 0)
                {
                    dataTable = table.Copy();

                    //для каждого рядка в новой таблице
                    for (int r = 0; r < dataTable.Rows.Count;)
                    {
                        //если название опции не совпадает со значением в нужной колонке, то убираем этот рядок
                        if (dataTable.Rows[r].Field<string>(choosenAttribute.AttributeName) != option.OptionName)
                        {
                            dataTable.Rows.Remove(dataTable.Rows[r]);
                            continue;
                        }

                        ++r;
                    }

                    //добавляем новое отношение
                    relations.Add(new Relation(null, option.OptionName, dataTable));
                }
                else
                {
                    string nodeData = "";

                    if (option.YesAmount == 0)
                    {
                        nodeData = Constants.No;
                    }
                    else if (option.NoAmount == 0)
                    {
                        nodeData = Constants.Yes;
                    }

                    relations.Add(new Relation(new Node(nodeData, null, null), option.OptionName, null));
                }
            }

            //создаём список временных атрибутов, которые != выбраному атрибуту
            List<Attribute> tempAttributes = new List<Attribute>();
            tempAttributes.AddRange(attributes.Where(attr => attr != choosenAttribute));

            Node node = new Node(choosenAttribute.AttributeName, relations, tempAttributes);

            Nodes.Add(node);

            if (relation != null)
            {
                relation.ChildNode = node;
            }

            //для каждого атрибута обнуляем количество Да и Нет для каждой опции и усиление
            foreach (Attribute attribute in attributes)
            {
                foreach (Option option in attribute.Options)
                {
                    option.YesAmount = 0;
                    option.NoAmount = 0;
                }

                attribute.Gain = 0;
            }

            //для каждого нового отношения, в котором нет "детей" строим дерево решений
            foreach (Relation newRelation in relations.Where(rel => rel.ChildNode == null))
            {
                BuildDecisionTree(newRelation.Data, node.Attributes, newRelation);
            }
        }

        public void PrintDecisionTree(Node node, string indent)
        {
            WriteLine(indent + node.NodeData);

            node.Relations?.ForEach(rel =>
            {
                WriteLine(indent + new string(' ', 5) + rel.ChildEdge);

                PrintDecisionTree(rel.ChildNode, indent + new string(' ', 10));
            });
        }
    }
}
