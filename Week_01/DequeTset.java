package Week_01;

import java.util.Deque;
import java.util.LinkedList;

public class DequeTset {

    public void run() {
        final Deque<String> deque = new LinkedList<String>();
        deque.addLast("a");
        deque.addLast("b");
        deque.addLast("c");
        System.out.println(deque);

        String str = deque.peekLast();
        System.out.println(str);
        System.out.println(deque);

        while (!deque.isEmpty()) {
            System.out.println(deque.pollLast());
        }
        System.out.println(deque);
    }
}