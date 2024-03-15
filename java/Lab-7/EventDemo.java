interface EventListner{
    public void performEvent();
}
interface MouseListener extends EventListner{
    public void mouseClicked(); 
    public void mousePressed(); 
    public void mouseReleased(); 
    public void mouseMoved(); 
    public void mouseDragged(); 
}
interface KeyListener extends EventListner{
    public void keyPressed();
    public void keyReleased();
}
public class EventDemo {
    public static void main(String[] args) {
        
    }
}
