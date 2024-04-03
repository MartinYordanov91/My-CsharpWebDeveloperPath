function create(words) {
  const divPerentElement = document.getElementById("content");

  words.forEach((element) => {
    let div = document.createElement("div");
    let p = document.createElement("p");
    p.textContent = element;
    p.style.display = "none";
    div.addEventListener("click", onClick);
    div.appendChild(p);
    divPerentElement.appendChild(div);

    function onClick(e) {
      p.style.display = p.style.display === "block" ? "none" : "block";
    }
  });
}
