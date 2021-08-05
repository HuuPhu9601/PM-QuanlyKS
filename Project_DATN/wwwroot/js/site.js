let arrow = document.querySelectorAll(".arrow");
for (var i = 0; i < arrow.length; i++) {
    arrow[i].addEventListener("click", (e) => {
        let arrowParent = e.target.parentElement.parentElement; //selecting main parent of arrow
        arrowParent.classList.toggle("showMenu");
    });
}
let sidebar = document.querySelector(".sidebar");
let sidebarBtn = document.querySelector(".icon");
let closeBtn = document.querySelector("#btn");
let overlay = document.querySelector(".overlay");
let body = document.querySelector("body");
let sidebarMainMenu = document.querySelector("ul.nav-links");
const toogleSidebar = () => {
    sidebar.classList.toggle("close");
    overlay.classList.toggle("opened-menu");
    body.classList.toggle("opened-menu");
    if (sidebarMainMenu.style.display === "none" || homepage != null) {
        sidebarMainMenu.style.display = "block";
    }
    else {
        sidebarMainMenu.style.display = "none";
    }
}
sidebarBtn.addEventListener("click", () => {
    toogleSidebar();
});


overlay.addEventListener("click", function () {
    toogleSidebar();
});
let homepage = document.querySelector(".homepage");
window.addEventListener("load", function () {
    if (homepage == null) {
        sidebarMainMenu.style.display = "none";
    }
});