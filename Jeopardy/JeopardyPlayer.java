package Jeopardy;

public class JeopardyPlayer {

    private int score;
    private final String name;
    private boolean winner;

    public JeopardyPlayer(String newName) {
        this.name = newName;
        this.score = 0;
        this.winner = false;
    }

    public void addScore(int pointValue) {
        this.score = this.score + pointValue;
    }

    public int getScore() {
        return this.score;
    }

    public String getName() {
        return this.name;
    }

    public void win() {
        winner = true;
    }
}