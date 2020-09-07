function copyLink() {
    var copyText = document.getElementById("calendar");
    copyText.select();
    document.execCommand("copy");
}