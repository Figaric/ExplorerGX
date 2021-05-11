const { contextBridge, ipcRenderer } = require("electron");

contextBridge.exposeInMainWorld(
    "win", {
        minimize: () => {
            ipcRenderer.send("minimize-window");
        },
        expand: () => {
            ipcRenderer.send("expand-window");
        },
        close: () => {
            ipcRenderer.send("close-window");
        }
    }
);