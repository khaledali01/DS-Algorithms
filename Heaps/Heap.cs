namespace DS_Algorithms.Heaps
{
	public class Heap
	{

		public int[] heapArray;

		private int lastNodeIndex;

		private int currentIndex;

		private int currentNodeParentIndex;

		private int leftChildIndex;

		private int rightChildIndex;

		private int largestChildIndex;

		public Heap()
		{
			heapArray = new int[0];
		}

		public void Insert(int value)
		{
			int[] newArray = new int[heapArray.Length + 1];

			for (int i = 0; i < heapArray.Length; i++)
			{
				newArray[i] = heapArray[i];
			}

			lastNodeIndex = newArray.Length - 1;
			newArray[lastNodeIndex] = value;
			heapArray = new int[newArray.Length];
			heapArray = newArray;

			currentIndex = lastNodeIndex;
			currentNodeParentIndex = GetParentIndex(currentIndex);

			if (currentNodeParentIndex < 0)
			{
				return;
			} else
			{
				CompareWithParent(currentIndex, currentNodeParentIndex);
			}

			return;
			
		}

		public void Remove()
		{
			int temp = heapArray[0];
			heapArray[0] = heapArray[heapArray.Length - 1];
			heapArray[heapArray.Length - 1] = temp;

			int[] newArray = new int[heapArray.Length - 1];

			for (int i = 0; i < heapArray.Length - 1; i++)
			{
				newArray[i] = heapArray[i];
			}

			heapArray = new int[newArray.Length];

			heapArray = newArray;

			currentIndex = 0;

			CheckChildren();

		}


		private void CompareWithParent(int nodeIndex, int parentNodeIndex)
		{
			if (heapArray[nodeIndex] > heapArray[parentNodeIndex])
			{
				int temp = heapArray[currentNodeParentIndex];
				heapArray[currentNodeParentIndex] = heapArray[currentIndex];
				heapArray[currentIndex] = temp;

				currentIndex = currentNodeParentIndex;
				currentNodeParentIndex = GetParentIndex(currentIndex);
				CompareWithParent(currentIndex, currentNodeParentIndex);
			} else
			{
				return;
			}
		}

		private void CompareLeftChildWithCurrentNode(int currentNode, int leftChild)
		{
			if (heapArray[currentNode] < heapArray[leftChild])
			{
				int tempvalue = heapArray[currentIndex];
				heapArray[currentIndex] = heapArray[leftChildIndex];
			}
			else
			{
				return;
			}
		}

		private void CompareLeftChildWithRightChild(int leftChild, int rightChild)
		{
			if (leftChild > rightChild)
			{
				largestChildIndex = leftChildIndex;
			}
			else
			{
				largestChildIndex = rightChildIndex;
			}
		}

		private void CompareLargestChildWithCurrentNode(int currentNode, int largestChild)
		{
			if (largestChild > currentNode)
			{
				int temp = currentNode;
				heapArray[currentIndex] = heapArray[largestChildIndex];
				heapArray[largestChildIndex] = temp;
				currentIndex = heapArray[largestChildIndex];
			} else
			{
				return;
			}
		}

		private void CheckChildren()
		{
			GetLeftChildIndex(currentIndex);
			GetRightChildIndex(currentIndex);
			if (leftChildIndex < heapArray.Length - 1 && rightChildIndex < heapArray.Length - 1)
			{
				CompareLeftChildWithRightChild(heapArray[leftChildIndex], heapArray[rightChildIndex]);
				CompareLargestChildWithCurrentNode(heapArray[currentIndex], heapArray[largestChildIndex]);
				return;
			} else if (leftChildIndex < heapArray.Length - 1)
			{
				CompareLeftChildWithCurrentNode(heapArray[currentIndex], heapArray[leftChildIndex]);
				return;
			} else
			{
				return;
			}

		}

		private int GetParentIndex(int index)
		{
			int parentIndex = (index - 1) / 2;
			return parentIndex;
		}

		private void GetLeftChildIndex(int index)
		{
			leftChildIndex = (index * 2) + 1;
		}

		private void GetRightChildIndex(int index)
		{
			rightChildIndex = (index * 2) + 2;
		}

		
	}
}
