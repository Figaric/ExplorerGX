const minimizeBtn = document.getElementById("minimize");
const expandBtn = document.getElementById("expand");
const closeBtn = document.getElementById("close");

minimizeBtn.addEventListener("click", () => {
    window.win.minimize();
});

expandBtn.addEventListener("click", () => {
    window.win.expand();
});

closeBtn.addEventListener("click", () => {
    window.win.close();
});