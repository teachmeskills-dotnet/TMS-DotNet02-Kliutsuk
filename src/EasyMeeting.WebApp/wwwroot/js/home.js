var hiddenElement = document.getElementById("about");
var btn = document.querySelector('.ab');

function handleButtonClick() {
    hiddenElement.scrollIntoView({ block: "center", behavior: "smooth" });
}

btn.addEventListener('click', handleButtonClick);