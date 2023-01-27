package EdxJavaHomeWork;

public class test {

	public ListNode mergeTwoLists(ListNode list1, ListNode list2) {
		if(list1 == null || list2 == null) {
			return list1 == null ? list2 : list1;
		}
		ListNode dummy = new ListNode(-1);
		ListNode cur = dummy;
		while(list1 != null && list2 != null) {
			if(list1.val <= list2.val) {
				cur.next = list1;
				list1 = list1.next;
			}else {
				cur.next = list2;
				list2 = list2.next;
			}
			cur = cur.next;
		}
		cur.next = list1 == null ? list2: list1;
		return dummy.next;
	}
	
	//Merge Sort
	//1. merge two sorted arrays
	//2. recursice solve left side, right side, merge two sorted arrays
	public void merge(int[] arr, int[] tmpArr, int left, int right, int rightEnd) {
		int leftEnd = right - 1;
		int tmp = left;
		int numElements = rightEnd - left + 1;
		while(left < leftEnd && right < rightEnd) {
			if(arr[left] < arr[right]) {
				tmpArr[tmp++] = arr[left++];
			}else {
				tmpArr[tmp++] = arr[right++];
			}
		}
		while(left <= leftEnd) {
			tmpArr[tmp++] = arr[left++];
		}
		while(right <= rightEnd) {
			tmpArr[tmp++] = arr[right++];
		}
		for(int i = 0; i < numElements; i++, rightEnd--) {
			arr[rightEnd] = tmpArr[rightEnd];
		}
	}
	public void mSort(int[] arr, int[] tmpArr, int left, int rightEnd) {
		if(left < rightEnd) {
			int center = left + (rightEnd - left) / 2;
			mSort(arr, tmpArr, left, center);
			mSort(arr, tmpArr, center + 1, rightEnd);
			merge(arr, tmpArr, left, center + 1, rightEnd);
		}
	}
	public void mergeSort(int[] arr) {
		if(arr == null || arr.length == 0)
			return;
		var tmpArr = new int[arr.length];
		mSort(arr, tmpArr, 0, arr.length - 1);
	}
	
	
	
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

}
