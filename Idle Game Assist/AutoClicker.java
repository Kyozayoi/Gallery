import javax.swing.*;
import java.awt.Robot;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.ActionListener;
import java.awt.event.InputEvent;
import java.awt.KeyEventDispatcher;
import java.awt.KeyboardFocusManager;
import java.awt.event.ActionEvent;

public class AutoClicker implements KeyListener {

    public static boolean clicking = false;
    public static int mainDelay = 100;
    public static Robot clickBot;
    public static int button = InputEvent.BUTTON1_DOWN_MASK;
    public static boolean running = true;

    public static int Xsize = 500;
    public static int Ysize = 100;
    public static String title = "Auto Clicker";
    public static JFrame mainFrame = new JFrame();
    public static JPanel mainPanel = new JPanel();
    public static boolean done = false;
    public static JLabel mainText = new JLabel();
    public static JLabel secText = new JLabel();
    public static JCheckBox tournament = new JCheckBox("Tournament");
    public static JButton reFocus = new JButton("Focus");
    public static JButton reSet = new JButton("Reset");

    public static long startTime = System.currentTimeMillis();

    public static void mainClicker() throws Exception {
        if (!done) {
            done = true;

            reFocus.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent evt) {
                    mainFrame.requestFocus();
                }
            });

            reSet.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent evt) {
                    startTime = System.currentTimeMillis();
                }
            });

            mainFrame.setSize(Xsize, Ysize);
            mainFrame.setVisible(true);
            mainFrame.setResizable(false);
            mainFrame.setTitle(title);
            mainFrame.add(mainPanel);
            mainPanel.add(mainText);
            mainPanel.add(secText);
            mainPanel.add(tournament);
            mainPanel.add(reFocus);
            mainPanel.add(reSet);
            mainFrame.addKeyListener(new AutoClicker());

            try {
                clickBot = new Robot();
            } catch (Exception e) {
                e.printStackTrace();
            }

            KeyboardFocusManager manager = KeyboardFocusManager.getCurrentKeyboardFocusManager();
            manager.addKeyEventDispatcher(new KeyEventDispatcher() {
                @Override
                public boolean dispatchKeyEvent(KeyEvent e) {
                    if (e.getID() == KeyEvent.VK_3) {
                        System.out.println("Typed 3 out of bounds");
                    }
                    return false;
                }
            });
            Thread.sleep(100);
            mainFrame.requestFocus();

            while (true) {
                long elapsedTime = System.currentTimeMillis() - startTime;
                secText.setText("Time run: " + elapsedTime);

                if (!tournament.isSelected() && clicking
                        && ((elapsedTime % 600000 <= 5000 && elapsedTime > 5000) || elapsedTime > 700000)) {
                    // Level Up
                    mainText.setText("Levelling Up");
                    clickBot.mouseMove(3265, 330);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(1000);

                    clickBot.mouseMove(2880, 880);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(3000);

                    clickBot.mouseMove(3100, 655);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(1000);

                    clickBot.mouseMove(3080, 350);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(3000);

                    startTime = System.currentTimeMillis();
                }

                if (clicking && elapsedTime % 300000 <= 5000) {
                    // Checking Chest
                    mainText.setText("Checking Chest");

                    clickBot.mouseMove(3210, 785);
                    for (int i = 0; i < 10; i++) {
                        clickBot.mousePress(button);
                        clickBot.mouseRelease(button);
                        clickBot.delay(75);
                    }
                }

                /*
                 * if(elapsedTime > 300000){ System.exit(0); }
                 */

                if (clicking) {
                    mainText.setText("Clicking");
                    // Chair 1
                    clickBot.mouseMove(3090, 590);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 2
                    clickBot.mouseMove(2915, 660);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 3
                    clickBot.mouseMove(2760, 760);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 4
                    clickBot.mouseMove(2950, 510);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 5
                    clickBot.mouseMove(2785, 600);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 6
                    clickBot.mouseMove(2625, 685);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 7
                    clickBot.mouseMove(2810, 430);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 8
                    clickBot.mouseMove(2650, 515);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 9
                    clickBot.mouseMove(2500, 605);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 10
                    clickBot.mouseMove(2520, 440);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    // Chair 11
                    clickBot.mouseMove(2365, 530);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);
                    clickBot.mouseMove(3250, 950);
                    clickBot.mousePress(button);
                    clickBot.mouseRelease(button);
                    clickBot.delay(mainDelay);

                    mainFrame.requestFocus();
                    mainText.setText("Can Pause Here");
                    clickBot.delay(1000);
                } else {
                    mainText.setText("Ready for Clicking");
                }
            }
        }
    }

    @Override
    public void keyPressed(KeyEvent e) {
        if (e.getKeyCode() == KeyEvent.VK_1 && !clicking) {
            clicking = true;
        } else if (e.getKeyCode() == KeyEvent.VK_1 && clicking) {
            clicking = false;
        }

        if (e.getKeyCode() == KeyEvent.VK_2) {
            System.exit(0);
        }
    }

    @Override
    public void keyReleased(KeyEvent e) {
        // TODO Auto-generated method stub

    }

    @Override
    public void keyTyped(KeyEvent e) {
        // TODO Auto-generated method stub

    }

    public AutoClicker() throws Exception {
        mainClicker();
    }

    public static void main(String[] args) throws Exception {
        AutoClicker FC = new AutoClicker();
    }

}