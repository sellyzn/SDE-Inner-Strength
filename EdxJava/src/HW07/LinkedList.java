package HW07;

import java.util.NoSuchElementException;

public class LinkedList<T> implements List<T>{
	private Node<T> head;
	private Node<T> tail;
	private int size;
	
	public LinkedList() {
		this.head = null;
		this.tail = null;
		this.size = 0;
	}

	public Node<T> getHead() {
		return head;
	}	

	public Node<T> getTail() {
		return tail;
	}	
	
	/**
     * Adds the passed in data to the specified index.
     * @param data  the data to add to the List
     * @param index the index to add at
     */
    public void addAtIndex(T data, int index) {
    	if(index < 0 || index > size) {
    		throw new IllegalArgumentException("Your index is out of the list bounds");
    	}else if(data == null) {
    		throw new IllegalArgumentException("You cannot add null data to the list");
    	}else if(head == null){
    		Node<T> addNode = new Node<T>(data);    		
			head = addNode;
			tail = addNode;
			size++;    		
    	}else {
    		Node<T> addNode = new Node<T>(data);    		
    		if(index == 0) {    			
    			addNode.setNext(head);
    			head = addNode;
    		}else if(index == size) {    			
    			tail.setNext(addNode);
    			tail = addNode;
    		}else {
    			Node<T> preNode = head;
    			Node<T> curNode = preNode.getNext();
    			while(index > 1) {
    				preNode = preNode.getNext();
    				curNode = curNode.getNext();
    				index--;
    			}
    			preNode.setNext(addNode);
    			addNode.setNext(curNode);    			
    		}    		
        	size++;
    	}    	
    }

    /**
     * Retrieves the data of the node that's specified.
     * @param index the index of the node whose data we are retrieving
     */
    public T getAtIndex(int index) {
    	if(index < 0 || index > size - 1) {
    		throw new IllegalArgumentException("Your index is out of the list bounds");
    	}else if(head == null){
    		throw new NullPointerException();
    	}else {    		
    		Node<T> curNode = head;
    		while(index > 0) {
    			curNode = curNode.getNext();   
    			index--;
    		}
    		return curNode.getData();
    	}
    }

    /**
     * Removes the data at the specified index and returns the data that was removed.
     * @param index removes the Node at this index
     */
    public T removeAtIndex(int index) {
    	if(index < 0 || index > size - 1) {
    		throw new IllegalArgumentException("Your index is out of the list bounds");
    	}else if(head == null){
    		throw new NullPointerException();
    	}else {
    		T removeData;
    		if(index == 0) {
    			removeData = head.getData();
    			if(head.equals(tail)) {    				
    				head = null;
    				tail = null;
    			}else {
    				head = head.getNext();
    			}  			  			
    		}else if(index == size - 1) {
    			removeData = tail.getData();
    			Node<T> curNode = head;
    			while(curNode.getNext().getNext() != null) {
    				curNode = curNode.getNext();
    			}
    			curNode.setNext(null);
    			tail = curNode;
    		}else {
    			Node<T> preNode = head;
    			Node<T> curNode = preNode.getNext();
    			while(index > 1) {
    				preNode = preNode.getNext();
    				curNode = curNode.getNext();
    				index--;
    			}
    			removeData = curNode.getData();
    			Node<T> nextNode = curNode.getNext();
    			preNode.setNext(nextNode);
    		}    		
        	size--;
        	return removeData;
    	}
    }

    /**
     * Removes the Node with the data passed in if a Node containing the data exists.
     * @param data the data to remove from the List
     */
    public T remove(T data) {
    	if(data == null) {
    		throw new IllegalArgumentException("You cannot remove null data from the list");
    	}else if(head == null){
    		throw new NoSuchElementException("The data is not present in the list.");
    	}else {
    		T removeData = null;
    		if(head == tail) {
    			if(head.getData().equals(data)) {
    				removeData = head.getData();
    				head = null;
    				tail = null;
    				size--;
    			}else {
    				throw new NoSuchElementException("The data is not present in the list.");
    			}
    		}else {
    			if(head.getData().equals(data)) {
    				removeData = head.getData();
    				head = head.getNext();
    				size--;
    			}else {
    				Node<T> preNode = head;
    				Node<T> curNode = head.getNext();
    				int index = 1;
    				
    				while(index < size) {
    					if(curNode.getData().equals(data)) {
    						removeData = curNode.getData();
    						if(index == size - 1) {
    							preNode.setNext(null);
    						}else {
    							preNode.setNext(curNode.getNext());
    						}    						
    						size--;
    						break;
    					}else {
    						preNode = preNode.getNext();
    						curNode = curNode.getNext();
    						index++;
    					}
    				}   				
    				
    	    		if(index == size) {
    	    			throw new NoSuchElementException("The data is not present in the list.");
    	    		}
    			}
    		}
    		return removeData;
    	}
    }

    /**
     * Clears the LinkedList - garbage collection is your friend here.
     * THIS SOLUTION SHOULD CAN BE O(1)
     */
    public void clear() {
    	head = null;
    	size = 0;
    }

    /**
     * Checks whether the LinkedList is empty or not.
     * @return boolean value indicating whether it's empty or not
     */
    public boolean isEmpty() {
    	return head == null;
    }

    /**
     * Returns the size of the List
     * @return integer size of the list
     */
    public int size() {
    	return size;
    }
	
	
	
}
