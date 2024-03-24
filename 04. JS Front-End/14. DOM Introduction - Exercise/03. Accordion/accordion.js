function toggle() {
   document.getElementById("extra").style.display === "block" ? (
    document.getElementById("extra").style.display = "none",
    document.querySelector(".button").textContent = "More"
   ) : (
    document.getElementById("extra").style.display = "block",
    document.querySelector(".button").textContent = "Less"
   );
}