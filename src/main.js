const { app, BrowserWindow, ipcMain } = require('electron');
const path = require("path");

console.log(path.join(__dirname, "preload.js"));

let mainWindow;

if (require('electron-squirrel-startup')) {
  app.quit();
}

const createWindow = () => {
  mainWindow = new BrowserWindow({
    width: 800,
    height: 450,
    frame: false,
    webPreferences: {
      nodeIntegration: false, // is default value after Electron v5
      contextIsolation: true, // protect against prototype pollution
      enableRemoteModule: false, // turn off remote
      preload: path.join(__dirname, "preload.js") // use a preload script
    }
  });

  mainWindow.loadFile("src\\index.html");

  mainWindow.webContents.openDevTools();
};

app.on('ready', createWindow);

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit();
  }
});

app.on('activate', () => {
  if (BrowserWindow.getAllWindows().length === 0) {
    createWindow();
  }
});

ipcMain.on("expand-window", () => {

  if(mainWindow.isNormal()) {
    mainWindow.maximize();
  }
  else {
    mainWindow.restore();
  }

});

ipcMain.on("minimize-window", () => {

  mainWindow.minimize();
});

ipcMain.on("close-window", () => {
  mainWindow.close();
});