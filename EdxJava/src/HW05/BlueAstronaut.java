package HW05;

public class BlueAstronaut extends Player implements Crewmate{	
	private int numTasks;
	private int taskSpeed;
	
	public BlueAstronaut(String name, int susLevel, int numTasks, int taskSpeed) {
		super(name, susLevel);		
		this.numTasks = numTasks;
		this.taskSpeed = taskSpeed;
	}
	
	public BlueAstronaut(String name) {
		super(name, 15);
		this.numTasks = 6;
		this.taskSpeed = 10;
	}
	
	public void emergencyMeeting() {
		if(super.isFrozen()) {
			return;
		}
		Player[] players = Player.getPlayers();
		int index = 0;
		while(index < players.length && players[index].isFrozen()) {
			index++;
		}
		if(index < players.length) {
			Player impostor = players[index];
			int hiCount = 1;
			for(int i = index + 1; i < players.length; i++) {
				if(!players[i].isFrozen()) {
					if(impostor.compareTo(players[i]) == 0) {
						hiCount++;
					}else if(impostor.compareTo(players[i]) < 0) {
						impostor = players[i];
						hiCount = 1;
					}
				}			
			}
			if(hiCount == 1) {
				impostor.setFrozen(true);
			}
		}
		super.gameOver();
	}
	
	public void completeTask() {
		if(super.isFrozen()) {
			return;
		}else {
			
			if(taskSpeed > 20) {
				if(numTasks == 2 || numTasks == 1) {
					System.out.println("I have completed all my tasks"); // Print out “I have completed all my tasks”
					super.setSusLevel((int)(super.getSusLevel() / 2));  // reduce BlueAstronaut’s susLevel by 50% (round down)
					
				}
				numTasks -= 2;				
			}else {
				numTasks--;
				// After BlueAstronaut is done with their tasks, meaning numTasks is equal to 0 (only for the first time),
				if(numTasks == 0) {
					System.out.println("I have completed all my tasks"); // Print out “I have completed all my tasks”
					super.setSusLevel((int)(super.getSusLevel() / 2));  // reduce BlueAstronaut’s susLevel by 50% (round down)
					
				}
			}
			// If numTasks falls below 0, set it to 0
			if(numTasks < 0) {
				numTasks = 0;
			}	
			
		}
	}
	
	public boolean equals(Object o) {		
		if (o instanceof BlueAstronaut) {
			BlueAstronaut b = (BlueAstronaut)o;
			if(super.getName().equals(b.getName()) && super.isFrozen() && b.isFrozen() && super.getSusLevel() == b.getSusLevel() && numTasks == b.getNumTasks() && taskSpeed == b.getTaskSpeed()) {
				return true;
			}
        }
        return false;
	}

	@Override
	public String toString() {
		String nameFormat = super.getName();
		int susLevel = super.getSusLevel();
		String frozenFormat = "";
		if(super.isFrozen())
			frozenFormat = "frozen";
		else
			frozenFormat = "not frozen";
		if(susLevel > 15) {
			return ("My name is " + nameFormat + ", and I have a suslevel of " + susLevel + ". I am currently " + frozenFormat + ". I have " + numTasks + " leftover.").toUpperCase();
		}else {
			return "My name is " + nameFormat + ", and I have a suslevel of " + susLevel + ". I am currently " + frozenFormat + ". I have " + numTasks + " leftover.";
		}
		
	}	

	public int getNumTasks() {
		return numTasks;
	}

	public void setNumTasks(int numTasks) {
		this.numTasks = numTasks;
	}

	public int getTaskSpeed() {
		return taskSpeed;
	}

	public void setTaskSpeed(int taskSpeed) {
		this.taskSpeed = taskSpeed;
	}
	
	
	
}
