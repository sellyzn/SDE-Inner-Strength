package EdxJavaHomeWork;
import java.util.*;
import java.io.*;

public class Battleship {
	
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
	    System.out.println("Welcome to Battleship!");	
	    System.out.println();
	    char[][] player1Board = new char[5][5];
	    char[][] player2Board = new char[5][5];
	    char[][] player1HistoryBoard = new char[5][5];
	    char[][] player2HistoryBoard = new char[5][5];
	    // initialization
	    for(int i = 0; i < 5; i++) {
	    	for(int j = 0; j < 5; j++) {
	    		player1Board[i][j] = '-';
	    		player2Board[i][j] = '-';
	    		player1HistoryBoard[i][j] = '-';
	    		player2HistoryBoard[i][j] = '-';
	    	}	    	
	    }
	    
	    
	    System.out.println("PLAYER 1, ENTER YOUR SHIP'S COORDINATES.");
	    // player 1 enter coordinates
	    inputCoordinate(player1Board, input);
	    // print player1's ship locations board
	    printBattleShip(player1Board);
	    
	    // print 100 new lines
	    for(int i = 0; i < 100; i++) {
	    	System.out.printf("\n");
	    }
	    
	    System.out.println("PLAYER 2, ENTER YOUR SHIP'S COORDINATES.");
	    // player 2 enter coordinates
	    inputCoordinate(player2Board, input);
	    // print player2's ship locations board
	    printBattleShip(player2Board);
	    
	    // print 100 new lines
	    for(int i = 0; i < 100; i++) {
	    	System.out.printf("\n");
	    }
	    
	    int player1ShipNumber = 5;
	    int player2ShipNumber = 5;
	    int[] shipNumberArray = new int[2];
	    shipNumberArray[0] = player1ShipNumber;
	    shipNumberArray[1] = player2ShipNumber;
	    
	    do {
	    	// player 1 hit
		    System.out.println("Player 1, enter hit row/column:");
		    battle(1, 2, player2Board, player2HistoryBoard, input, shipNumberArray);	
		    if(shipNumberArray[1] == 0) {
		    	break;
		    }
		    
		    // player 2 hit
		    System.out.println("Player 2, enter hit row/column:");
		    battle(2, 1, player1Board, player1HistoryBoard, input, shipNumberArray);		    
		    
	    }while(shipNumberArray[0] > 0 && shipNumberArray[1] > 0);
	    System.out.println();
	    System.out.println("Final boards:");
	    System.out.println();
	    printBattleShip(player1Board);
	    System.out.println();
		printBattleShip(player2Board);    
	    
	    
    }
	
	private static void battle(int attackerId, int attackedId, char[][] attackedBoard, char[][] attackedHistoryBoard, Scanner input, int[] shipNumberArray) {
		int x = input.nextInt();
		int y = input.nextInt();
		if(!(x >= 0 && x < 5 && y >= 0 && y < 5)) {
			do {
				System.out.println("Invalid coordinates. Choose different coordinates.");
				System.out.println("Player " + attackerId + ", enter hit row/column:");
				x = input.nextInt();
				y = input.nextInt();
			}while(!(x >= 0 && x < 5 && y >= 0 && y < 5));
		}				
		
		if(x >= 0 && x < 5 && y >= 0 && y < 5) {
			if(attackedBoard[x][y] == 'O' || attackedBoard[x][y] == 'X') {
				do {
					System.out.println("You already fired on this spot. Choose different coordinates.");
					System.out.println("Player " + attackerId + ", enter hit row/column:");
					x = input.nextInt();
					y = input.nextInt();
				}while(attackedBoard[x][y] == 'O' || attackedBoard[x][y] == 'X');				
			}			
			
			if(attackedBoard[x][y] == '@') {
				attackedBoard[x][y] = 'X';
				attackedHistoryBoard[x][y] = 'X';
				shipNumberArray[attackedId - 1]--;
				if(shipNumberArray[attackedId - 1] == 0) {
					System.out.println("PLAYER " + attackerId + " WINS! YOU SUNK ALL OF YOUR OPPONENT’S SHIPS!");	    					
				}else {
					System.out.println("PLAYER " + attackerId + " HIT PLAYER " + attackedId + "'s SHIP!");
					printBattleShip(attackedHistoryBoard);
					System.out.println();
				}	    				
			}else if(attackedBoard[x][y] == '-') {
				attackedBoard[x][y] = 'O';
				attackedHistoryBoard[x][y] = 'O';
				System.out.println("PLAYER " + attackerId + " MISSED!");
				printBattleShip(attackedHistoryBoard);
				System.out.println();
			}
		}	
	}
	
	private static void inputCoordinate(char[][] playerBoard, Scanner input) {
		
		for(int i = 1; i <= 5; i++) {
	    	System.out.println("Enter ship " + i + " location:");
	    	if(input.hasNextInt()) {
	    		int x = input.nextInt();
	    		if(input.hasNextInt()) {
	    			int y = input.nextInt();
	    			if(x >= 0 && x < 5 && y >= 0 && y < 5) {
	    				if(playerBoard[x][y] == '-') {
	    					playerBoard[x][y] = '@';
	    				}else {
	    					i--;
	    					System.out.println("You already have a ship there. Choose different coordinates.");
	    				}
	    				
	    			}else {
	    				i--;
	    				System.out.println("Invalid coordinates. Choose different coordinates.");
	    			}	    			
	    		}else {
	    			i--;
	    			System.out.println("Invalid coordinates. Choose different coordinates.");
	    		}
	    	}else {
	    		i--;
	    		System.out.println("Invalid coordinates. Choose different coordinates.");
	    	}
	    	
	    }
		
	}
    
    // Use this method to print game boards to the console.
	private static void printBattleShip(char[][] player) {
		System.out.print("  ");
		for (int row = -1; row < 5; row++) {
			if (row > -1) {
				System.out.print(row + " ");
			}
			for (int column = 0; column < 5; column++) {
				if (row == -1) {
					System.out.print(column + " ");
				} else {
					System.out.print(player[row][column] + " ");
				}
			}
			System.out.println("");
		}
	}
}
