function ClientFileDialogControl(name) {
    //Private fields
    this.name = name;
    this.popup = null;
    this.fileManager = null;
    this.txFileName = null;
    this.buttonOk = null;
    this.validationCallback = null;

    this.dialogMode = null;
    this.openFunction = null;
    this.saveFunction = null;

    //Event handlers
    this.fileManager_SelectionChanged = function (s, e) {
        if (e.isSelected) {
            this.txFileName.SetText(e.item.name);
        }
    };
    this.buttonOk_Click = function () {
        this.validationCallback.PerformCallback(this.dialogMode + '|' + this.GetFileName());
    };
    this.buttonCancel_Click = function () {
        this.popup.Hide();
    };
    this.validationCallback_CallbackComplete = function (s, e) {
        if (e.result === "") {
            this.popup.Hide();
            switch (this.dialogMode) {
                case "OPEN":
                    if (this.openFunction != null) {
                        this.openFunction(this.GetFileName());
                    }
                    break;
                case "SAVE":
                    if (this.saveFunction != null) {
                        this.saveFunction(this.GetFileName());
                    }
                    break;
            }
        }
        else {
            alert(e.result);
        }
    };

    //Private methods
    this.InitializeDialog = function () {
        switch (this.dialogMode) {
            case "OPEN":
                this.popup.SetHeaderText("Open Report");
                this.buttonOk.SetText("Open");
                break;
            case "SAVE":
                this.popup.SetHeaderText("Save Report");
                this.buttonOk.SetText("Save");
                break;
        }
        this.txFileName.SetText("");
        this.fileManager.Refresh();
        this.popup.Show();
    }
    this.GetFileName = function () {
        return "~\\" + this.fileManager.GetCurrentFolderPath() + "\\" + this.txFileName.GetText();
    };

    //Public methods
    this.ShowOpenFileDialog = function (openDialogResultFunction) {
        this.dialogMode = "OPEN";
        this.openFunction = openDialogResultFunction;
        this.InitializeDialog();
    };
    this.ShowSaveFileDialog = function (saveDialogResultFunction) {
        this.dialogMode = "SAVE";
        this.saveFunction = saveDialogResultFunction;
        this.InitializeDialog();
    };
}