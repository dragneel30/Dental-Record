using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DentalRecordApplication
{
    class AprioriAlgorithm<T> where T : IComparable
    {

        public static AprioriAlgorithm<T> createInstance(Set<T> iRoot)
        {
            return new AprioriAlgorithm<T>(iRoot);
        }
        private AprioriAlgorithm(Set<T> iRoot)
        {
            root = iRoot;

            pair = 1;
            finishedScanning = false;
            

        }
        public Set<T> root;
        public Set<T> prevScan;
        public Set<T> nextScan()
        {
            if (finishedScanning) return null;
            Item<T> compressedData;
            if (pair == 1)
                compressedData = root.getCompressedData();
            else
                compressedData = prevScan.getCompressedData();
            compressedData.generateCombinatorics(pair, new Data<T>[pair]);
            Set<T> combinatoric = compressedData.Combinatoric;
            if (pair > 1)
                combinatoric.removeNotCompletelyExistFrom(prevScan, pair);
            if (combinatoric.Items.Count == 0) { finishedScanning = true; return null; }
            root.computeSupport(ref combinatoric);
            prevScan = combinatoric;
            return combinatoric;
        }
        public Set<T> finalizeCurrentScan()
        {
            prevScan.cull(2);
            finishedScanning = prevScan.Items.Count == 0;
            if (prevScan.Items.Count == 0) { finishedScanning = true; return null; }
            pair++;
            return prevScan;
        }
        int pair;
        bool finishedScanning;
    }
    class Item<T> where T : IComparable
    {
        public void generateCombinatorics(int pair_count, Data<T>[] possibles, int start = 0, int starting = 0)
        {
            if (start == pair_count)
            {
                return;
            }
            start++;
            for (int a = starting; a < datas.Count; a++)
            {
                possibles[start - 1] = datas[a];
                if (start == pair_count)
                {
                    Item<T> item = new Item<T>();
                    for (int b = 0; b < pair_count; b++)
                    {
                        item.add(possibles[b]);
                    }
                    combinatoric.add(item);
                }
                generateCombinatorics(pair_count, possibles, start, a + 1);
            }

            start--;
        }

        Set<T> combinatoric;

        public Set<T> Combinatoric
        {
            get { return combinatoric; }
        }

        int support;
        public Item()
        {
            combinatoric = new Set<T>();
            datas = new List<Data<T>>();
        }

        public int Support
        {
            get { return support; }
            set { support = value; }
        }

        public void add(Data<T> newData)
        {
            datas.Add(newData);
        }
        List<Data<T>> datas;
        public List<Data<T>> Datas
        {
            get { return datas; }
        }

        public bool isExist(Data<T> data)
        {
            for (int a = 0; a < Datas.Count; a++)
            {
                if (Datas[a].Equals(data))
                {
                    return true;
                }
            }
            return false;
        }
        public bool isExist(Item<T> other)
        {
            for (int a = 0; a < other.Datas.Count; a++)
            {
                if (!isExist(other.Datas[a]))
                {
                    return false;
                }
            }
            return true;
        }
    }
    class Set<T> where T : IComparable
    {
        public Set()
        {
            items = new List<Item<T>>();
        }

        public void computeSupport(ref Set<T> other)
        {
            for (int a = 0; a < other.Items.Count; a++)
            {
                other.Items[a].Support = countOccurence(other.Items[a]);
            }
        }

        public void cull(int min_support)
        {
            for (int a = 0; a < Items.Count; a++)
            {
                if (Items[a].Support < min_support)
                {
                    removeItem(items[a]);
                    a--;
                }
            }
        }
        public Item<T> getCompressedData()
        {
            Item<T> item = new Item<T>();
            for (int a = 0; a < Items.Count; a++)
            {
                for (int b = 0; b < Items[a].Datas.Count; b++)
                {
                    if (!item.isExist(Items[a].Datas[b]))
                    {
                        item.add(Items[a].Datas[b]);
                    }
                }
            }
            return item;
        }

        Set<T> createDuplicate()
        {
            Set<T> duplicate = new Set<T>();

            duplicate.Items = Items;

            return duplicate;
        }
        public void removeNotCompletelyExistFrom(Set<T> other, int currPair)
        {
            for (int a = 0; a < Items.Count; a++)
            {
                Item<T> currItem = Items[a];
                currItem.generateCombinatorics(currPair-1, new Data<T>[currPair-1]);
                Set<T> combinatoric = currItem.Combinatoric;
                for (int b = 0; b < combinatoric.Items.Count; b++)
                {
                    bool existed = false;
                    for (int c = 0; c < other.Items.Count; c++)
                    {
                        if (other.Items[c].isExist(combinatoric.Items[b]))
                        {
                            existed = true;
                            break;
                        }
                    }
                    if (!existed)
                    {
                        Items.Remove(Items[a]);
                        a--;
                        break;
                    }
             
                }
            }

        }

        public void add(Item<T> newItem)
        {
            items.Add(newItem);
        }

        public List<Item<T>> Items
        {
            get { return items; }
            set { items = value; }
        }
        List<Item<T>> items;

        public void removeItem(Item<T> item)
        {
            items.Remove(item);
        }
        public int countOccurence(Item<T> item)
        {
            int c = 0;
            for (int a = 0; a < items.Count; a++)
            {
                if (items[a].isExist(item))
                {
                    c++;
                }
            }
            return c;
        }
    }
    class Data<T> where T : IComparable
    {
        public Data(T iData) { data = iData; }
        T data;

        public T Internal
        {
            get { return data; }
            set { data = value; }
        }
        public override bool Equals(object obj)
        {
            return Internal.CompareTo(((Data<T>)obj).Internal) == 0;
        }

        public override int GetHashCode()
        {
            return Internal.GetHashCode();
        }
    }

}
