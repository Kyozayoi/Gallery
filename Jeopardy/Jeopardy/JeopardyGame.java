package Jeopardy;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class JeopardyGame {

    JFrame mainWindow;

    JeopardyPlayer player1;
    JeopardyPlayer player2;
    JeopardyPlayer player3;

    int topicNumber = 0;
    int questionNumber = 0;
    int answerNumber = 0;

    String[] QuestionTopics = { "Topic 1", "Topic 2", "Topic 3", "Topic 4", "Topic 5" };
    String[] Questions = { "Question 1a", "Question 2a", "Question 3a", "Question 4a", "Question 5a", "Question 1b",
            "Question 2b", "Question 3b", "Question 4b", "Question 5b", "Question 1c", "Question 2c", "Question 3c",
            "Question 4c", "Question 5c", "Question 1d", "Question 2d", "Question 3d", "Question 4d", "Question 5d",
            "Question 1e", "Question 2e", "Question 3e", "Question 4e", "Question 5e", };
    String[] Answers = { "Answer 1a", "Answer 2a", "Answer 3a", "Answer 4a", "Answer 5a", "Answer 1b", "Answer 2b",
            "Answer 3b", "Answer 4b", "Answer 5b", "Answer 1c", "Answer 2c", "Answer 3c", "Answer 4c", "Answer 5c",
            "Answer 1d", "Answer 2d", "Answer 3d", "Answer 4d", "Answer 5d", "Answer 1e", "Answer 2e", "Answer 3e",
            "Answer 4e", "Answer 5e" };

    JPanel panelSetNames;
    JPanel panelJeopardyMain;
    JLabel summoner1;
    JLabel summoner2;
    JLabel summoner3;
    JLabel summoner1Score;
    JLabel summoner2Score;
    JLabel summoner3Score;
    JTextField player1Name;
    JTextField player2Name;
    JTextField player3Name;
    JButton buttonSetNames;
    JButton player1right;
    JButton player2right;
    JButton player3right;
    JButton player1wrong;
    JButton player2wrong;
    JButton player3wrong;
    JButton revealAnswer;

    JLabel TopicLabel;
    JLabel QuestionLabel;
    JLabel AnswerLabel;

    public static void main(String[] args) {
        JeopardyGame Main = new JeopardyGame();
        Main.go();
    }

    public void go() {

        Dimension wSize = new Dimension(1200, 700);

        mainWindow = new JFrame("Jeopardy");
        mainWindow.setSize(wSize);
        mainWindow.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        mainWindow.setLayout(new BorderLayout());

        panelSetNames = new JPanel();
        panelSetNames.setSize(wSize);
        panelSetNames.setLayout(null);

        panelJeopardyMain = new JPanel();
        panelJeopardyMain.setSize(wSize);
        panelJeopardyMain.setLayout(null);

        summoner1 = new JLabel();
        summoner1.setSize(200, 50);
        summoner1Score = new JLabel();
        summoner1Score.setSize(200, 50);

        player1Name = new JTextField();
        player1Name.setSize(200, 50);
        player1Name.setLocation(150, 75);
        player1Name.setText("Player 1");

        summoner2 = new JLabel();
        summoner2.setSize(200, 50);
        summoner2Score = new JLabel();
        summoner2Score.setSize(200, 50);

        player2Name = new JTextField();
        player2Name.setSize(200, 50);
        player2Name.setLocation(500, 75);
        player2Name.setText("Player 2");

        summoner3 = new JLabel();
        summoner3.setSize(200, 50);
        summoner3Score = new JLabel();
        summoner3Score.setSize(200, 50);

        player3Name = new JTextField();
        player3Name.setSize(200, 50);
        player3Name.setLocation(850, 75);
        player3Name.setText("Player 3");

        panelSetNames.add(summoner1);
        panelSetNames.add(summoner2);
        panelSetNames.add(summoner3);
        panelSetNames.add(summoner1Score);
        panelSetNames.add(summoner2Score);
        panelSetNames.add(summoner3Score);

        panelSetNames.add(player1Name);
        panelSetNames.add(player2Name);
        panelSetNames.add(player3Name);

        buttonSetNames = new JButton();
        buttonSetNames.addActionListener(new RollListener());
        buttonSetNames.setSize(400, 40);
        buttonSetNames.setLocation(400, 150);
        buttonSetNames.setText("Set Player Names");
        panelSetNames.add(buttonSetNames);

        mainWindow.add(panelSetNames);
        mainWindow.setVisible(true);
    }

    class RollListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent ae) {

            player1 = new JeopardyPlayer(player1Name.getText());
            player2 = new JeopardyPlayer(player2Name.getText());
            player3 = new JeopardyPlayer(player3Name.getText());

            summoner1.setText(player1Name.getText());
            summoner1.setFont(new Font("Monospaced", Font.BOLD, 14));
            summoner2.setText(player2Name.getText());
            summoner2.setFont(new Font("Monospaced", Font.BOLD, 14));
            summoner3.setText(player3Name.getText());
            summoner3.setFont(new Font("Monospaced", Font.BOLD, 14));
            summoner1Score.setText(player1.getScore() + " IP");
            summoner2Score.setText(player2.getScore() + " IP");
            summoner3Score.setText(player3.getScore() + " IP");

            summoner1.setLocation(150, 75);
            summoner2.setLocation(500, 75);
            summoner3.setLocation(850, 75);
            summoner1Score.setLocation(150, 150);
            summoner2Score.setLocation(500, 150);
            summoner3Score.setLocation(850, 150);

            player1right = new JButton();
            player1right.addActionListener(new RollListener2());
            player1right.setSize(100, 40);
            player1right.setLocation(150, 400);
            player1right.setText("Player 1 Victory");

            player2right = new JButton();
            player2right.addActionListener(new RollListener3());
            player2right.setSize(100, 40);
            player2right.setLocation(500, 400);
            player2right.setText("Player 2 Victory");

            player3right = new JButton();
            player3right.addActionListener(new RollListener4());
            player3right.setSize(100, 40);
            player3right.setLocation(850, 400);
            player3right.setText("Player 3 Victory");

            player1wrong = new JButton();
            player1wrong.addActionListener(new RollListener5());
            player1wrong.setSize(100, 40);
            player1wrong.setLocation(150, 450);
            player1wrong.setText("Player 1 Defeat");

            player2wrong = new JButton();
            player2wrong.addActionListener(new RollListener6());
            player2wrong.setSize(100, 40);
            player2wrong.setLocation(500, 450);
            player2wrong.setText("Player 2 Defeat");

            player3wrong = new JButton();
            player3wrong.addActionListener(new RollListener7());
            player3wrong.setSize(100, 40);
            player3wrong.setLocation(850, 450);
            player3wrong.setText("Player 3 Defeat");

            revealAnswer = new JButton();
            revealAnswer.addActionListener(new RollListener8());
            revealAnswer.setSize(100, 40);
            revealAnswer.setLocation(500, 500);
            revealAnswer.setText("Reveal Answer");

            TopicLabel = new JLabel();
            TopicLabel.setSize(600, 30);
            TopicLabel.setText(QuestionTopics[topicNumber]);
            QuestionLabel = new JLabel();
            QuestionLabel.setSize(600, 30);
            QuestionLabel.setText(Questions[questionNumber]);
            AnswerLabel = new JLabel();
            AnswerLabel.setSize(600, 30);

            TopicLabel.setLocation(500, 200);
            QuestionLabel.setLocation(500, 250);
            AnswerLabel.setLocation(500, 300);

            panelJeopardyMain.add(TopicLabel);
            panelJeopardyMain.add(QuestionLabel);
            panelJeopardyMain.add(AnswerLabel);

            panelJeopardyMain.add(summoner1);
            panelJeopardyMain.add(summoner2);
            panelJeopardyMain.add(summoner3);
            panelJeopardyMain.add(summoner1Score);
            panelJeopardyMain.add(summoner2Score);
            panelJeopardyMain.add(summoner3Score);
            panelJeopardyMain.add(player1right);
            panelJeopardyMain.add(player2right);
            panelJeopardyMain.add(player3right);
            panelJeopardyMain.add(player1wrong);
            panelJeopardyMain.add(player2wrong);
            panelJeopardyMain.add(player3wrong);
            panelJeopardyMain.add(revealAnswer);

            panelSetNames.remove(buttonSetNames);
            panelJeopardyMain.remove(buttonSetNames);

            mainWindow.add(panelJeopardyMain);
            mainWindow.remove(panelSetNames);

        }
    }

    class RollListener2 implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent ae) {

            player1.addScore(100);
            questionNumber++;
            if (questionNumber % 5 == 0) {
                topicNumber++;
            }
            TopicLabel.setText(QuestionTopics[topicNumber]);
            QuestionLabel.setText(Questions[questionNumber]);
            summoner1Score.setText(player1.getScore() + " IP");
            AnswerLabel.setText("");
        }

    }

    class RollListener3 implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent ae) {
            player2.addScore(100);
            questionNumber++;
            if (questionNumber % 5 == 0) {
                topicNumber++;
            }
            TopicLabel.setText(QuestionTopics[topicNumber]);
            QuestionLabel.setText(Questions[questionNumber]);
            summoner2Score.setText(player2.getScore() + " IP");
            AnswerLabel.setText("");
        }

    }

    class RollListener4 implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent ae) {
            player3.addScore(100);
            questionNumber++;
            if (questionNumber % 5 == 0) {
                topicNumber++;
            }
            TopicLabel.setText(QuestionTopics[topicNumber]);
            QuestionLabel.setText(Questions[questionNumber]);
            summoner3Score.setText(player3.getScore() + " IP");
            AnswerLabel.setText("");
        }

    }

    class RollListener5 implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent ae) {
            player1.addScore(-50);
            summoner1Score.setText(player1.getScore() + " IP");
        }

    }

    class RollListener6 implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent ae) {
            player2.addScore(-50);
            summoner2Score.setText(player2.getScore() + " IP");
        }

    }

    class RollListener7 implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent ae) {
            player3.addScore(-50);
            summoner3Score.setText(player3.getScore() + " IP");
        }

    }

    class RollListener8 implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent ae) {

            AnswerLabel.setText(Answers[questionNumber]);

        }

    }
}