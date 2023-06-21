using DS_Algorithms.Heaps;

Heap heap1 = new();
heap1.Insert(2);
heap1.Insert(5);
heap1.Insert(3);
heap1.Insert(9);
heap1.Insert(11);
heap1.Insert(15);
heap1.Insert(4);
heap1.Remove();

int[] heapArray = heap1.heapArray;


for (int i = 0; i < heapArray.Length; i++)
{
	Console.WriteLine(heapArray[i]);
}



