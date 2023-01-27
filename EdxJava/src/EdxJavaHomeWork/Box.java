package EdxJavaHomeWork;

public class Box {
	int length;
    int breadth;
    int height;

    public Box() {
        length = 10;
        breadth = 20;
        height = 30;
    }

    public Box(int length, int breadth) {
        this.length = length;
        this.breadth = breadth;
        height = 30;
    }

    public Box(int length, int breadth, int height) {
        this.length = length;
        this.breadth = breadth;
        this.height = height;
    }
}
