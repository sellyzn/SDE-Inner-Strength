package EdxJavaHomeWork;
//package test;
//import java.util.NoSuchElementException;
//
//public class SinglyLinkedList {
//
//	public class SinglyLinkedListNode{
//        public T data;
//        public SinglyLinkedListNode next;
//        public SinglyLinkedListNode(T data, SinglyLinkedListNode next){
//            this.data = data;
//            this.next = next;
//        }
//    }
//    
//    /*
//     * Do not add new instance variables or modify existing ones.
//     */
//    private SinglyLinkedListNode<T> head;
//    private SinglyLinkedListNode<T> tail;
//    private int size;
//
//    /*
//     * Do not add a constructor.
//     */
//
//    /**
//     * Adds the element to the front of the list.
//     *
//     * Method should run in O(1) time.
//     *
//     * @param data the data to add to the front of the list
//     * @throws java.lang.IllegalArgumentException if data is null
//     */
//    public void addToFront(T data) {
//        // WRITE YOUR CODE HERE (DO NOT MODIFY METHOD HEADER)!
//        if(data == null){
//            throw new IllegalArgumentException("Error: some exception was thrown");
//        }
//        if(head == null){
//            SinglyLinkedListNode<T> cur = new SinglyLinkedListNode<T>(data);
//            head = cur;
//            tail = cur;
//        }else{
//            SinglyLinkedListNode<T> temp = head;
//            head = new SinglyLinkedListNode<T>(data);
//            head.next = temp;            
//        }
//        size++;
//    }
//
//    /**
//     * Adds the element to the back of the list.
//     *
//     * Method should run in O(1) time.
//     *
//     * @param data the data to add to the back of the list
//     * @throws java.lang.IllegalArgumentException if data is null
//     */
//    public void addToBack(T data) {
//        // WRITE YOUR CODE HERE (DO NOT MODIFY METHOD HEADER)!
//        if(data == null){
//            throw new IllegalArgumentException("Error: some exception was thrown");
//        }
//        if(head == null){
//            SinglyLinkedListNode<T> cur = new SinglyLinkedListNode<T>(data);
//            head = cur;
//            tail = cur;
//        }else{
//            SinglyLinkedListNode<T> temp = new SinglyLinkedListNode<T>(data);
//            tail.next = temp;
//            tail = temp;
//        }
//        size++;
//    }
//
//    /**
//     * Removes and returns the first data of the list.
//     *
//     * Method should run in O(1) time.
//     *
//     * @return the data formerly located at the front of the list
//     * @throws java.util.NoSuchElementException if the list is empty
//     */
//    public T removeFromFront() {
//        // WRITE YOUR CODE HERE (DO NOT MODIFY METHOD HEADER)!
//        if(head == null){
//            throw new IllegalArgumentException("Error: some exception was thrown");
//        }
//        SinglyLinkedListNode<T> remove = head;
//        if(head.next == null){
//            head = null;
//            tail = null;
//        }else{            
//            head = head.next;
//            remove.next = null;
//        }
//        size--;
//        return remove.data;
//    }
//
//    /**
//     * Removes and returns the last data of the list.
//     *
//     * Method should run in O(n) time.
//     *
//     * @return the data formerly located at the back of the list
//     * @throws java.util.NoSuchElementException if the list is empty
//     */
//    public T removeFromBack() {
//        // WRITE YOUR CODE HERE (DO NOT MODIFY METHOD HEADER)!
//        if(head == null){
//            throw new IllegalArgumentException("Error: some exception was thrown");
//        }
//        SinglyLinkedListNode<T> remove = tail;
//        if(head.next == null){
//            head = null;
//            tail = null;
//        }else{
//            SinglyLinkedListNode<T> cur = head;
//            while(cur.next.next != null){
//                cur = cur.next;
//            }
//            tail = cur;
//            tail.next = null;
//        }
//        size--;
//        return tail.data;
//    }
//
//    /**
//     * Returns the head node of the list.
//     *
//     * For grading purposes only. You shouldn't need to use this method since
//     * you have direct access to the variable.
//     *
//     * @return the node at the head of the list
//     */
//    public SinglyLinkedListNode<T> getHead() {
//        // DO NOT MODIFY THIS METHOD!
//        return head;
//    }
//
//    /**
//     * Returns the tail node of the list.
//     *
//     * For grading purposes only. You shouldn't need to use this method since
//     * you have direct access to the variable.
//     *
//     * @return the node at the tail of the list
//     */
//    public SinglyLinkedListNode<T> getTail() {
//        // DO NOT MODIFY THIS METHOD!
//        return tail;
//    }
//
//    /**
//     * Returns the size of the list.
//     *
//     * For grading purposes only. You shouldn't need to use this method since
//     * you have direct access to the variable.
//     *
//     * @return the size of the list
//     */
//    public int size() {
//        // DO NOT MODIFY THIS METHOD!
//        return size;
//    }
//	
//	
//	public static void main(String[] args) {
//		// TODO Auto-generated method stub
//
//	}
//
//	
//	
//	
//}
