package EdxJavaHomeWork;

public class RedAstronaut extends Player implements Impostor{	
	private String skill;
	
	public RedAstronaut(String name, int susLevel, String skill) {
		super(name, susLevel);
		this.skill = skill;
	}
	
	public RedAstronaut(String name) {		
		super(name, 15);		
		this.skill = "experienced";
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

	@Override
	public void freeze(Player p) {
		// TODO Auto-generated method stub
		if(super.isFrozen() || p.isFrozen()) {			
			return;
		}else {
			Player[] players = Player.getPlayers();
			Player impostor = players[0];
			for(int i = 1; i < players.length; i++) {
				if(impostor.compareTo(players[i]) < 0) {
					impostor = players[i];
				}
			}
			if(p.equals(impostor)) {				
				return;
			}else {
				if(super.getSusLevel() < p.getSusLevel()) {
					p.setFrozen(true);
				}else {
					super.setSusLevel(super.getSusLevel() * 2);
				}	
				super.gameOver();
			} 
		}
		
		
	}

	@Override
	public void sabotage(Player p) {
		// TODO Auto-generated method stub
		if(super.isFrozen() || p.isFrozen()) {
			return;
		}else {
			Player[] players = Player.getPlayers();
			Player impostor = players[0];
			for(int i = 1; i < players.length; i++) {
				if(impostor.compareTo(players[i]) < 0) {
					impostor = players[i];
				}
			}
			if(p.equals(impostor)) {
				return;
			}else {
				if(super.getSusLevel() < 20) {
					p.setSusLevel((int)(p.getSusLevel() * (1 + 0.5)));
				}else {
					p.setSusLevel((int)(p.getSusLevel() * (1 + 0.25)));
				}
			}
		}
	}
	
	public boolean equals(Object o) {
		if (o instanceof RedAstronaut) {
			RedAstronaut r = (RedAstronaut)o;
			if(super.getName().equals(r.getName()) && super.isFrozen() && r.isFrozen() && super.getSusLevel() == r.getSusLevel() && skill.equals(r.getSkill())) {
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
			return ("My name is " + nameFormat + ", and I have a suslevel of " + susLevel + ". I am currently " + frozenFormat + ". I am an " + skill + " player!").toUpperCase();
		}else {
			return "My name is " + nameFormat + ", and I have a suslevel of " + susLevel + ". I am currently " + frozenFormat + ". I am an " + skill + " player!";
		}
		
	}
	
	public String getSkill() {
		return skill;
	}

	public void setSkill(String skill) {
		this.skill = skill;
	}

	
	
	

}
