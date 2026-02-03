package model;

public class SimpleNote {

    private int id;
    private String title;
    private String content;
    private int colorId;
    private int userId;

    public SimpleNote() {}

    public int getId() { return id; }
    public void setId(int id) { this.id = id; }

    public String getTitle() { return title; }
    public void setTitle(String title) { this.title = title; }

    public String getContent() { return content; }
    public void setContent(String content) { this.content = content; }

    public int getColorId() { return colorId; }
    public void setColorId(int colorId) { this.colorId = colorId; }

    public int getUserId() { return userId; }
    public void setUserId(int userId) { this.userId = userId; }
}
