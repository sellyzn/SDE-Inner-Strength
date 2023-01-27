package EdxJavaHomeWork;

public class Automobile {
    private String make;
    private String model;

    public Automobile(String make, String model) {
        this.make = make;
        this.model = model;
    }
    public String toString() {
        return "Make: " + make + " Model: " + model;
    }
    public void wash() {
        System.out.println("wash, dry, wax");
    }
}
