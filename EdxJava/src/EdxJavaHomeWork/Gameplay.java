package EdxJavaHomeWork;

public class Gameplay {
	public static void main(String[] args) {
		BlueAstronaut blue1 = new BlueAstronaut("Bob", 20, 6, 30);
		BlueAstronaut blue2 = new BlueAstronaut("Heath", 30, 3, 21);
		BlueAstronaut blue3 = new BlueAstronaut("Albert", 44, 2, 0);
		BlueAstronaut blue4 = new BlueAstronaut("Angel", 0, 1, 0);
		RedAstronaut red1 = new RedAstronaut("Liam", 19, "experienced");
		RedAstronaut red2 = new RedAstronaut("Suspicious Person", 100, "expert");
		
		// 1. Have RedAstronaut Liam sabotage BlueAstronaut Bob. After the sabotage
		red1.sabotage(blue1);		
		
		// 2. Have RedAstronaut Liam freeze RedAstronaut Suspicious Person:
		red1.freeze(red2);
		
		// 3. Have RedAstronaut Liam freeze BlueAstronaut Albert. After the freeze:
		red1.freeze(blue3);
				
		// 4. Have BlueAstronaut Albert call an emergency meeting:
		blue3.emergencyMeeting();				
		
		// 5. Have RedAstronaut Suspicious Person call an emergency meeting:
		red1.emergencyMeeting();
		
		// 6. Have BlueAstronaut Bob call an emergency meeting:
		blue1.emergencyMeeting();
		
		// 7. Have BlueAstronaut Heath complete tasks:
		blue2.completeTask();
				
		// 8. Have BlueAstronaut Heath complete tasks:
		blue2.completeTask();
				
		// 9. Have BlueAstronaut Heath complete tasks:
		blue2.completeTask();
				
		// 10. Have RedAstronaut Liam freeze Angel:
		red1.freeze(blue4);
		
		// 11. Have RedAstronaut Liam sabotage Bob twice:
		red1.sabotage(blue1);		
		red1.sabotage(blue1);		
		
		// 12. Have RedAstronaut Liam freeze Bob:
		red1.freeze(blue1);		
		
		// 13. Have BlueAstronaut Angel call emergency meeting:
		blue4.emergencyMeeting();
		
		// 14. Have RedAstronaut Liam call sabotage on Heath 5 times:
		red1.sabotage(blue2);
		red1.sabotage(blue2);
		red1.sabotage(blue2);
		red1.sabotage(blue2);
		red1.sabotage(blue2);
		
		// 15. Have RedAstronaut Liam freeze Heath:
		red1.freeze(blue2);		
		
		
	}
}
