package controller;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;

public class NoteController {

    @FXML
    private TextField txtTitle;

    @FXML
    private TextArea txtContent;

    @FXML
    private void saveNote(ActionEvent event) {
        // mesma lógica do FrmNote.cs
    }
}
